USE [SmartBankDB]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_ScheduleTransfer]
(
    @UserInActionID INT,
    @FromAccountID INT,
    @ToAccountID INT,
    @Amount DECIMAL(18,2),
    @Description NVARCHAR(250),
    @ScheduledDate DATETIME,
    @NewTransactionID INT OUTPUT
)
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRANSACTION

            DECLARE @BalanceBefore DECIMAL(18,2);
            SELECT @BalanceBefore = Balance FROM Accounts WHERE AccountID = @FromAccountID;

            INSERT INTO Transactions (AccountID, TransactionType, Amount,
                                      RelatedAccountID, Description, TransactionDate,
                                      ProcessedByUserID, IsScheduled, BalanceBefore, BalanceAfter)
            VALUES (@FromAccountID, 'Transfer_In', @Amount, @ToAccountID, @Description,
                    @ScheduledDate, @UserInActionID, 1, @BalanceBefore, @BalanceBefore);

            SET @NewTransactionID = SCOPE_IDENTITY();

            IF @NewTransactionID IS NULL
                THROW 52003, 'Scheduled transfer insertion failed.', 1;

            INSERT INTO AuditLog (UserID, Action, EntityType, EntityID, OldValue, NewValue, Timestamp)
            VALUES (@UserInActionID, 'TRANSFER_SCHEDULED', 'Transactions', @NewTransactionID,
                    'Pending', CAST(@ScheduledDate AS NVARCHAR), GETDATE());

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

CREATE PROCEDURE [dbo].[sp_ProcessScheduledTransfers]
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