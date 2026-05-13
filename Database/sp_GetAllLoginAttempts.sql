USE [SmartBankDB]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAllLoginAttempts]    Script Date: 5/13/2026 8:15:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER PROCEDURE [dbo].[sp_GetAllLoginAttempts]
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        la.AttemptID,
        la.UserID,
        Username = u.Username,
        la.AttemptDate,
        la.WasSuccessful
    FROM LoginAttempts la
    LEFT JOIN Users u ON u.UserID = la.UserID
    ORDER BY la.AttemptDate DESC;
END;
GO
