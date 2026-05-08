USE [SmartBankDB]
GO

ALTER PROCEDURE [dbo].[sp_ProcessScheduledTransfers]
(
    @ProcessedCount INT OUTPUT
)
AS
BEGIN
    SET NOCOUNT ON;
    SET @ProcessedCount = 0;

    DECLARE @TransactionID INT, @FromAccountID INT, @ToAccountID INT, @Amount DECIMAL(18,2), @Description NVARCHAR(250), @NewTransactionID INT;
    DECLARE @NewBalance DECIMAL(18,2);

    WHILE 1 = 1
    BEGIN
        SELECT TOP 1 @TransactionID = TransactionID, @FromAccountID = AccountID, @ToAccountID = RelatedAccountID,
                      @Amount = Amount, @Description = Description
        FROM Transactions
        WHERE IsScheduled = 1 AND BalanceBefore = BalanceAfter AND TransactionDate <= GETDATE();

        IF @@ROWCOUNT = 0 BREAK;

        BEGIN TRY
            EXEC sp_Transfer @UserInActionID = 1, @FromAccountID = @FromAccountID,
                             @ToAccountID = @ToAccountID, @Amount = @Amount,
                             @Description = @Description, @NewTransactionID = @NewTransactionID OUTPUT;

            IF @NewTransactionID > 0
            BEGIN
                SELECT @NewBalance = Balance FROM Accounts WHERE AccountID = @FromAccountID;
                UPDATE Transactions SET BalanceAfter = @NewBalance WHERE TransactionID = @TransactionID;
                SET @ProcessedCount = @ProcessedCount + 1;
            END
        END TRY
        BEGIN CATCH
            THROW;
        END CATCH
    END
END;