USE [SmartBankDB]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[sp_Transfer]
(
    @UserInActionID   INT,
    @FromAccountID    INT,
    @ToAccountID      INT,
    @Amount           DECIMAL(18,2),
    @Description      NVARCHAR(250),
    @NewTransactionID INT OUTPUT
)
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRANSACTION

            DECLARE @FromBalanceBefore DECIMAL(18,2);
            DECLARE @FromBalanceAfter DECIMAL(18,2);
            DECLARE @ToBalanceBefore DECIMAL(18,2);
            DECLARE @ToBalanceAfter DECIMAL(18,2);

            SELECT @FromBalanceBefore = Balance,
                   @FromBalanceAfter = Balance - @Amount
            FROM Accounts
            WHERE AccountID = @FromAccountID;

            SELECT @ToBalanceBefore = Balance,
                   @ToBalanceAfter = Balance + @Amount
            FROM Accounts
            WHERE AccountID = @ToAccountID;

            UPDATE Accounts
            SET Balance = @FromBalanceAfter
            WHERE AccountID = @FromAccountID;

            IF @@ROWCOUNT = 0
                THROW 52004, 'Source account update failed.', 1;

            UPDATE Accounts
            SET Balance = @ToBalanceAfter
            WHERE AccountID = @ToAccountID;

            IF @@ROWCOUNT = 0
                THROW 52005, 'Destination account update failed.', 1;

            INSERT INTO Transactions (AccountID, TransactionType, Amount,
                                      RelatedAccountID, Description, TransactionDate,
                                      ProcessedByUserID, IsScheduled, BalanceBefore, BalanceAfter)
            VALUES (@FromAccountID, 'Transfare', @Amount, @ToAccountID, @Description, GETDATE(),
                    @UserInActionID, 0, @FromBalanceBefore, @FromBalanceAfter);

            SET @NewTransactionID = SCOPE_IDENTITY();

            IF @NewTransactionID IS NULL
                THROW 52003, 'Transfer transaction insertion failed.', 1;

            INSERT INTO AuditLog (UserID, Action, EntityType, EntityID, OldValue, NewValue, Timestamp)
            VALUES (@UserInActionID, 'TRANSFER', 'Accounts', @FromAccountID,
                    CAST(@FromAccountID AS NVARCHAR) + ' -> ' + CAST(@ToAccountID AS NVARCHAR),
                    CAST(@FromBalanceAfter AS NVARCHAR), GETDATE());

        COMMIT TRANSACTION
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;

        SET @NewTransactionID = -1;
        THROW;
    END CATCH
END;
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[sp_ProcessScheduledTransfers]
(
    @ProcessedCount INT OUTPUT
)
AS
BEGIN
    SET NOCOUNT ON;
    SET @ProcessedCount = 0;

    DECLARE @TransactionID INT,
            @FromAccountID INT,
            @ToAccountID INT,
            @Amount DECIMAL(18,2),
            @Description NVARCHAR(250),
            @FromBalanceBefore DECIMAL(18,2),
            @FromBalanceAfter DECIMAL(18,2),
            @ToBalanceBefore DECIMAL(18,2),
            @ToBalanceAfter DECIMAL(18,2);

    WHILE 1 = 1
    BEGIN
        SELECT TOP 1 @TransactionID = TransactionID,
                     @FromAccountID = AccountID,
                     @ToAccountID = RelatedAccountID,
                     @Amount = Amount,
                     @Description = Description
        FROM Transactions
        WHERE IsScheduled = 1
          AND BalanceBefore = BalanceAfter
          AND TransactionDate <= GETDATE()
        ORDER BY TransactionDate, TransactionID;

        IF @@ROWCOUNT = 0
            BREAK;

        BEGIN TRY
            BEGIN TRANSACTION

                SELECT @FromBalanceBefore = Balance,
                       @FromBalanceAfter = Balance - @Amount
                FROM Accounts
                WHERE AccountID = @FromAccountID;

                SELECT @ToBalanceBefore = Balance,
                       @ToBalanceAfter = Balance + @Amount
                FROM Accounts
                WHERE AccountID = @ToAccountID;

                IF @FromBalanceBefore IS NULL OR @ToBalanceBefore IS NULL
                    THROW 52008, 'Source or destination account was not found.', 1;

                UPDATE Accounts
                SET Balance = @FromBalanceAfter
                WHERE AccountID = @FromAccountID;

                IF @@ROWCOUNT = 0
                    THROW 52004, 'Source account update failed.', 1;

                UPDATE Accounts
                SET Balance = @ToBalanceAfter
                WHERE AccountID = @ToAccountID;

                IF @@ROWCOUNT = 0
                    THROW 52005, 'Destination account update failed.', 1;

                UPDATE Transactions
                SET TransactionType = 'Transfer_Out',
                    Description = ISNULL(@Description, Description),
                    TransactionDate = GETDATE(),
                    ProcessedByUserID = 1,
                    IsScheduled = 0,
                    BalanceBefore = @FromBalanceBefore,
                    BalanceAfter = @FromBalanceAfter
                WHERE TransactionID = @TransactionID
                  AND IsScheduled = 1
                  AND BalanceBefore = BalanceAfter;

                IF @@ROWCOUNT = 0
                    THROW 52009, 'Scheduled transfer row update failed.', 1;

                INSERT INTO AuditLog (UserID, Action, EntityType, EntityID, OldValue, NewValue, Timestamp)
                VALUES (1, 'SCHEDULED_TRANSFER_EXECUTED', 'Transactions', @TransactionID,
                        CAST(@FromAccountID AS NVARCHAR) + ' -> ' + CAST(@ToAccountID AS NVARCHAR),
                        CAST(@FromBalanceAfter AS NVARCHAR), GETDATE());

                SET @ProcessedCount = @ProcessedCount + 1;

            COMMIT TRANSACTION
        END TRY
        BEGIN CATCH
            IF @@TRANCOUNT > 0
                ROLLBACK TRANSACTION;
            THROW;
        END CATCH
    END
END;
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[sp_GetProcessedScheduledDebitTransactions]
(
    @FromDate DATETIME,
    @ToDate DATETIME
)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT DISTINCT t.TransactionID,
           t.AccountID,
           t.Amount,
           t.TransactionDate
    FROM Transactions t
    INNER JOIN AuditLog a ON a.EntityType = 'Transactions'
                         AND a.EntityID = t.TransactionID
                         AND a.Action = 'SCHEDULED_TRANSFER_EXECUTED'
    WHERE t.TransactionType = 'Transfer_Out'
      AND t.IsScheduled = 0
      AND a.Timestamp >= @FromDate
      AND a.Timestamp <= @ToDate;
END;
GO
