USE [SmartBankDB]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER FUNCTION [dbo].[IsFraudFlagExistsByID](@FlagID INT)
RETURNS BIT
AS
BEGIN
    DECLARE @IsExists BIT = 0;

    IF EXISTS (SELECT 1 FROM FraudFlags WHERE FlagID = @FlagID)
        SET @IsExists = 1;

    RETURN @IsExists;
END;
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER PROCEDURE [dbo].[sp_CreateFraudFlag]
(
    @UserInActionID INT,
    @AccountID      INT,
    @FlagType       NVARCHAR(50),
    @Details        NVARCHAR(500),
    @NewFlagID      INT OUTPUT
)
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRANSACTION

            INSERT INTO FraudFlags (AccountID, FlagType, FlaggedDate, Details, IsResolved, ResolvedByUserID, ResolvedDate)
            VALUES (@AccountID, @FlagType, GETDATE(), @Details, 0, NULL, NULL);

            SET @NewFlagID = SCOPE_IDENTITY();

            IF @NewFlagID IS NULL
                THROW 53001, 'Fraud flag insertion failed.', 1;

            INSERT INTO AuditLog (UserID, Action, EntityType, EntityID, NewValue, Timestamp)
            VALUES (@UserInActionID, 'FRAUD_FLAG_CREATED', 'FraudFlags', @NewFlagID, @FlagType, GETDATE());

        COMMIT TRANSACTION
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;

        SET @NewFlagID = -1;
        THROW;
    END CATCH
END;
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER PROCEDURE [dbo].[sp_GetFraudFlagByID]
(
    @FlagID            INT,
    @AccountID         INT OUTPUT,
    @FlagType          NVARCHAR(50) OUTPUT,
    @FlaggedDate       DATETIME OUTPUT,
    @Details           NVARCHAR(500) OUTPUT,
    @IsResolved        BIT OUTPUT,
    @ResolvedByUserID  INT OUTPUT,
    @ResolvedDate      DATETIME OUTPUT
)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        @AccountID        = AccountID,
        @FlagType         = FlagType,
        @FlaggedDate      = FlaggedDate,
        @Details          = Details,
        @IsResolved       = IsResolved,
        @ResolvedByUserID = ResolvedByUserID,
        @ResolvedDate     = ResolvedDate
    FROM FraudFlags
    WHERE FlagID = @FlagID;
END;
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER PROCEDURE [dbo].[sp_ResolveFraudFlag]
(
    @UserInActionID INT,
    @FlagID         INT,
    @IsUpdated      BIT OUTPUT
)
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRANSACTION

            UPDATE FraudFlags
            SET IsResolved = 1,
                ResolvedByUserID = @UserInActionID,
                ResolvedDate = GETDATE()
            WHERE FlagID = @FlagID AND IsResolved = 0;

            IF @@ROWCOUNT = 0
                THROW 53002, 'Fraud flag not found or already resolved.', 1;

            INSERT INTO AuditLog (UserID, Action, EntityType, EntityID, OldValue, NewValue, Timestamp)
            VALUES (@UserInActionID, 'FRAUD_FLAG_RESOLVED', 'FraudFlags', @FlagID, '0', '1', GETDATE());

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

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER FUNCTION [dbo].[fn_GetAllFraudFlags]()
RETURNS TABLE
AS
RETURN
(
    SELECT
        FlagID,
        AccountID,
        FlagType,
        FlaggedDate,
        Details,
        IsResolved,
        ResolvedByUserID,
        ResolvedDate
    FROM FraudFlags
);
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER FUNCTION [dbo].[fn_GetUnresolvedFraudFlags]()
RETURNS TABLE
AS
RETURN
(
    SELECT
        FlagID,
        AccountID,
        FlagType,
        FlaggedDate,
        Details,
        IsResolved,
        ResolvedByUserID,
        ResolvedDate
    FROM FraudFlags
    WHERE IsResolved = 0
);
GO
