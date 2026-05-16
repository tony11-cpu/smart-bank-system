USE [SmartBankDB]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER PROCEDURE [dbo].[sp_ReopenFraudFlag]
(
    @UserInActionID INT,
    @FlagID INT,
    @IsUpdated BIT OUTPUT
)
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRANSACTION

            UPDATE FraudFlags
            SET IsResolved = 0,
                ResolvedByUserID = NULL,
                ResolvedDate = NULL
            WHERE FlagID = @FlagID AND IsResolved = 1;

            IF @@ROWCOUNT = 0
                THROW 53004, 'Fraud flag not found or already unresolved.', 1;

            INSERT INTO AuditLog (UserID, Action, EntityType, EntityID, OldValue, NewValue, Timestamp)
            VALUES (@UserInActionID, 'FRAUD_FLAG_REOPENED', 'FraudFlags', @FlagID, '1', '0', GETDATE());

            SET @IsUpdated = 1;
        COMMIT TRANSACTION
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;

        SET @IsUpdated = 0;
        THROW;
    END CATCH
END;
GO

