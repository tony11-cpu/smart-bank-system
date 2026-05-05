-- Update sp_Deposit to store balance values
ALTER PROCEDURE [dbo].[sp_Deposit]
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

        SELECT @BalanceBefore = Balance FROM Accounts WHERE AccountID = @AccountID;
        SET @BalanceAfter = @BalanceBefore + @Amount;

        UPDATE Accounts SET Balance = @BalanceAfter WHERE AccountID = @AccountID;

        IF @@ROWCOUNT = 0
            THROW 52001, 'Account update failed.', 1;

        INSERT INTO Transactions (AccountID, TransactionType, Amount, RelatedAccountID, Description, TransactionDate, ProcessedByUserID, IsScheduled, BalanceBefore, BalanceAfter)
        VALUES (@AccountID, 'Deposit', @Amount, NULL, @Description, GETDATE(), @UserInActionID, 0, @BalanceBefore, @BalanceAfter);

        SET @NewTransactionID = SCOPE_IDENTITY();

        IF @NewTransactionID IS NULL
            THROW 52002, 'Deposit transaction insertion failed.', 1;

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

-- Update sp_Withdraw to store balance values
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

        SELECT @BalanceBefore = Balance FROM Accounts WHERE AccountID = @AccountID;
        SET @BalanceAfter = @BalanceBefore - @Amount;

        UPDATE Accounts SET Balance = @BalanceAfter WHERE AccountID = @AccountID;

        IF @@ROWCOUNT = 0
            THROW 52001, 'Account update failed.', 1;

        INSERT INTO Transactions (AccountID, TransactionType, Amount, RelatedAccountID, Description, TransactionDate, ProcessedByUserID, IsScheduled, BalanceBefore, BalanceAfter)
        VALUES (@AccountID, 'Withdrawal', @Amount, NULL, @Description, GETDATE(), @UserInActionID, 0, @BalanceBefore, @BalanceAfter);

        SET @NewTransactionID = SCOPE_IDENTITY();

        IF @NewTransactionID IS NULL
            THROW 52002, 'Withdrawal transaction insertion failed.', 1;

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

-- Update sp_Transfer to store balance values
ALTER PROCEDURE [dbo].[sp_Transfer]
(
    @UserInActionID   INT,
    @FromAccountID    INT,
    @ToAccountID     INT,
    @Amount          DECIMAL(18,2),
    @Description     NVARCHAR(250),
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

        SELECT @FromBalanceBefore = Balance FROM Accounts WHERE AccountID = @FromAccountID;
        SELECT @ToBalanceBefore = Balance FROM Accounts WHERE AccountID = @ToAccountID;

        SET @FromBalanceAfter = @FromBalanceBefore - @Amount;
        SET @ToBalanceAfter = @ToBalanceBefore + @Amount;

        UPDATE Accounts SET Balance = @FromBalanceAfter WHERE AccountID = @FromAccountID;
        
        IF @@ROWCOUNT = 0
            THROW 52004, 'Source account update failed.', 1;
        
        UPDATE Accounts SET Balance = @ToBalanceAfter WHERE AccountID = @ToAccountID;
        
        IF @@ROWCOUNT = 0
            THROW 52005, 'Destination account update failed.', 1;

        INSERT INTO Transactions (AccountID, TransactionType, Amount, RelatedAccountID, Description, TransactionDate, ProcessedByUserID, IsScheduled, BalanceBefore, BalanceAfter)
        VALUES (@FromAccountID, 'Transfare', @Amount, @ToAccountID, @Description, GETDATE(), @UserInActionID, 0, @FromBalanceBefore, @FromBalanceAfter);

        SET @NewTransactionID = SCOPE_IDENTITY();

        IF @NewTransactionID IS NULL
            THROW 52003, 'Transfer transaction insertion failed.', 1;

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