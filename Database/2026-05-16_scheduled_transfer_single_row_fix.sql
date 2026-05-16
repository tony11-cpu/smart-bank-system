USE [SmartBankDB]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[sp_Transfer]
(
    @UserInActionID         INT,
    @FromAccountID          INT,
    @ToAccountID            INT,
    @Amount                 DECIMAL(18,2),
    @Description            NVARCHAR(250),
    @NewTransactionID       INT OUTPUT,
    @IsScheduledExecution   BIT = 0,
    @ScheduledTransactionID INT = NULL
)
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        BEGIN TRANSACTION

            DECLARE @FromBalanceBefore DECIMAL(18,2);
            DECLARE @FromBalanceAfter  DECIMAL(18,2);
            DECLARE @ToBalanceBefore   DECIMAL(18,2);
            DECLARE @ToBalanceAfter    DECIMAL(18,2);
            DECLARE @ScheduledDetails  NVARCHAR(250);

            IF (@Amount <= 0)
                THROW 52001, 'Transfer amount must be greater than zero.', 1;

            -- Scheduled execution branch: mutate the original scheduled row, do not insert a new row.
            IF (@IsScheduledExecution = 1)
            BEGIN
                IF (@ScheduledTransactionID IS NULL)
                    THROW 52006, 'ScheduledTransactionID is required for scheduled execution.', 1;

                SELECT @ScheduledDetails = t.Description
                FROM Transactions t WITH (UPDLOCK, HOLDLOCK, ROWLOCK)
                WHERE t.TransactionID = @ScheduledTransactionID
                  AND t.IsScheduled = 1
                  AND t.AccountID = @FromAccountID
                  AND t.RelatedAccountID = @ToAccountID
                  AND t.TransactionDate <= GETDATE()
                  AND t.BalanceBefore = t.BalanceAfter;

                IF (@ScheduledDetails IS NULL)
                    THROW 52007, 'Scheduled transfer not found or already processed.', 1;

                SELECT @FromBalanceBefore = Balance,
                       @FromBalanceAfter = Balance - @Amount
                FROM Accounts WITH (UPDLOCK, ROWLOCK)
                WHERE AccountID = @FromAccountID;

                SELECT @ToBalanceBefore = Balance,
                       @ToBalanceAfter = Balance + @Amount
                FROM Accounts WITH (UPDLOCK, ROWLOCK)
                WHERE AccountID = @ToAccountID;

                IF (@FromBalanceBefore IS NULL OR @ToBalanceBefore IS NULL)
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
                    Description = ISNULL(@Description, @ScheduledDetails),
                    TransactionDate = GETDATE(),
                    ProcessedByUserID = @UserInActionID,
                    IsScheduled = 0,
                    BalanceBefore = @FromBalanceBefore,
                    BalanceAfter = @FromBalanceAfter
                WHERE TransactionID = @ScheduledTransactionID
                  AND IsScheduled = 1;

                IF @@ROWCOUNT = 0
                    THROW 52009, 'Scheduled transfer row update failed.', 1;

                SET @NewTransactionID = @ScheduledTransactionID;

                INSERT INTO AuditLog (UserID, Action, EntityType, EntityID, OldValue, NewValue, Timestamp)
                VALUES (@UserInActionID, 'SCHEDULED_TRANSFER_EXECUTED', 'Transactions', @ScheduledTransactionID,
                        CAST(@FromAccountID AS NVARCHAR) + ' -> ' + CAST(@ToAccountID AS NVARCHAR),
                        CAST(@FromBalanceAfter AS NVARCHAR), GETDATE());

                COMMIT TRANSACTION;
                RETURN;
            END

            -- Normal transfer branch: existing behavior (insert a new row).
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

    DECLARE @TransactionID INT, @FromAccountID INT,
            @ToAccountID INT, @Amount DECIMAL(18,2),
            @Description NVARCHAR(250), @NewTransactionID INT;

    WHILE 1 = 1
    BEGIN
        SELECT TOP 1
               @TransactionID = t.TransactionID,
               @FromAccountID = t.AccountID,
               @ToAccountID = t.RelatedAccountID,
               @Amount = t.Amount,
               @Description = t.Description
        FROM Transactions t WITH (UPDLOCK, READPAST, ROWLOCK)
        WHERE t.IsScheduled = 1
          AND t.BalanceBefore = t.BalanceAfter
          AND t.TransactionDate <= GETDATE()
        ORDER BY t.TransactionDate, t.TransactionID;

        IF @@ROWCOUNT = 0
            BREAK;

        BEGIN TRY
            EXEC sp_Transfer
                @UserInActionID = 1,
                @FromAccountID = @FromAccountID,
                @ToAccountID = @ToAccountID,
                @Amount = @Amount,
                @Description = @Description,
                @NewTransactionID = @NewTransactionID OUTPUT,
                @IsScheduledExecution = 1,
                @ScheduledTransactionID = @TransactionID;

            IF @NewTransactionID = @TransactionID
                SET @ProcessedCount = @ProcessedCount + 1;
        END TRY
        BEGIN CATCH
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
    @ToDate   DATETIME
)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT DISTINCT
        t.TransactionID,
        t.AccountID,
        t.Amount,
        t.TransactionDate
    FROM Transactions t
    INNER JOIN AuditLog a
        ON a.EntityType = 'Transactions'
       AND a.EntityID = t.TransactionID
       AND a.Action = 'SCHEDULED_TRANSFER_EXECUTED'
    WHERE t.TransactionType = 'Transfer_Out'
      AND t.IsScheduled = 0
      AND a.Timestamp >= @FromDate
      AND a.Timestamp <= @ToDate;
END;
GO
