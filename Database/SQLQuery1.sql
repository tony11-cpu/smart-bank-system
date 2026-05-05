USE [SmartBankDB]
GO

ALTER TABLE Transactions ADD BalanceBefore DECIMAL(18,2) NULL;
ALTER TABLE Transactions ADD BalanceAfter DECIMAL(18,2) NULL;
GO

UPDATE t
SET t.BalanceBefore = a.Balance,
    t.BalanceAfter = a.Balance
FROM Transactions t
JOIN Accounts a ON t.AccountID = a.AccountID
WHERE t.BalanceBefore IS NULL;
GO



USE [SmartBankDB]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[sp_Deposit]
(
    @UserInActionID   INT,
    @AccountID       INT,
    @Amount           DECIMAL(18,2),
    @Description      NVARCHAR(250),
    @NewTransactionID INT OUTPUT
)
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRANSACTION

            DECLARE @BalanceBefore DECIMAL(18,2);
            DECLARE @BalanceAfter DECIMAL(18,2);

            SELECT @BalanceBefore = Balance,
                   @BalanceAfter = Balance + @Amount
            FROM Accounts
            WHERE AccountID = @AccountID;

            UPDATE Accounts
            SET Balance = @BalanceAfter
            WHERE AccountID = @AccountID;
            
            IF @@ROWCOUNT = 0
                THROW 52001, 'Account update failed.', 1;

            INSERT INTO Transactions (AccountID, TransactionType, Amount,
                                      RelatedAccountID, Description, TransactionDate,
                                      ProcessedByUserID, IsScheduled, BalanceBefore, BalanceAfter)
            VALUES (@AccountID, 'Deposit', @Amount,
                    NULL, @Description, GETDATE(),
                    @UserInActionID, 0, @BalanceBefore, @BalanceAfter);

            SET @NewTransactionID = SCOPE_IDENTITY();

            IF @NewTransactionID IS NULL
                THROW 52002, 'Deposit transaction insertion failed.', 1;

            INSERT INTO AuditLog (UserID, Action, EntityType, EntityID, OldValue, NewValue, Timestamp)
            VALUES (@UserInActionID, 'DEPOSIT', 'Accounts', @AccountID,
                    CAST(@BalanceBefore AS NVARCHAR), CAST(@BalanceAfter AS NVARCHAR), GETDATE());

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



USE [SmartBankDB]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[sp_Withdraw]
(
    @UserInActionID   INT,
    @AccountID       INT,
    @Amount          DECIMAL(18,2),
    @Description     NVARCHAR(250),
    @NewTransactionID INT OUTPUT
)
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRANSACTION

            DECLARE @BalanceBefore DECIMAL(18,2);
            DECLARE @BalanceAfter DECIMAL(18,2);

            SELECT @BalanceBefore = Balance,
                   @BalanceAfter = Balance - @Amount
            FROM Accounts
            WHERE AccountID = @AccountID;

            UPDATE Accounts
            SET Balance = @BalanceAfter
            WHERE AccountID = @AccountID;

            IF @@ROWCOUNT = 0
               THROW 52004, 'account update failed.', 1;

            INSERT INTO Transactions (AccountID, TransactionType, Amount,
                                      RelatedAccountID, Description, TransactionDate,
                                      ProcessedByUserID, IsScheduled, BalanceBefore, BalanceAfter)
            VALUES (@AccountID, 'Withdrawal', @Amount,
                    NULL, @Description, GETDATE(),
                    @UserInActionID, 0, @BalanceBefore, @BalanceAfter);

            SET @NewTransactionID = SCOPE_IDENTITY();

            IF @NewTransactionID IS NULL
                THROW 52002, 'Withdrawal transaction insertion failed.', 1;

            INSERT INTO AuditLog (UserID, Action, EntityType, EntityID, OldValue ,NewValue, Timestamp)
            VALUES (@UserInActionID, 'WITHDRAWAL', 'Accounts', @AccountID, CAST(@BalanceBefore AS NVARCHAR),
            CAST(@BalanceAfter AS NVARCHAR), GETDATE());

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
            VALUES (@FromAccountID, 'Transfare', @Amount, @ToAccountID , @Description, GETDATE() , @UserInActionID, 0, @FromBalanceBefore, @FromBalanceAfter);

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