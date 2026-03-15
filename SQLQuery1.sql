
CREATE OR ALTER FUNCTION IsUserExist (@Username NVARCHAR(100))
RETURNS BIT
AS
BEGIN
    DECLARE @Result BIT = 0;

    IF EXISTS (SELECT 1 FROM Users WHERE Username = @Username)
        SET @Result = 1;

    RETURN @Result;
END;
go

CREATE OR ALTER FUNCTION IsUserExistByID (@UserID INT)
RETURNS BIT
AS
BEGIN
    DECLARE @Result BIT = 0;

    IF EXISTS (SELECT 1 FROM Users WHERE Users.UserID = @UserID)
        SET @Result = 1;

    RETURN @Result;
END;
go

CREATE OR ALTER PROCEDURE sp_CreateUser (@UserInActionID int , @Username NVARCHAR(100), @HashedPassword NVARCHAR(256),
                                         @Salt NVARCHAR(256), @Permissions INT, @FullName NVARCHAR(200),
                                         @IsActive Bit , @IsLocked Bit, @NewUserID INT Output)
AS
BEGIN
    Set NOCOUNT On;
    Begin Try
	  Begin Transaction
	    Insert Into Users (Username,PasswordHash,PasswordSalt,
		                   Permissions,FullName,IsActive,
						   IsLocked,CreatedDate,LastLoginDate)
		Values (@Username , @HashedPassword , @Salt , @Permissions 
		      , @FullName , @IsActive , @IsLocked , GETDATE() , null);
	  
	    Set @NewUserID = SCOPE_IDENTITY();
		IF @NewUserID IS NULL
           THROW 50001, 'User insertion failed.', 1;
		
		Insert Into AuditLog(UserID , Action , EntityType , EntityID , Timestamp)
	    Values (@UserInActionID , 'USER_CREATED' , 'Users' , @NewUserID , GetDate());
	  Commit
	End Try   
	Begin Catch
	  if(@@TRANCOUNT  > 0)
	     Rollback Transaction

      Set @NewUserID = -1;
	  throw;
	End Catch
END;
go

CREATE OR ALTER PROCEDURE sp_GetUserByUsername
    @Username NVARCHAR(100),
    @UserID INT OUTPUT,
    @PasswordHash NVARCHAR(300) OUTPUT,
    @PasswordSalt NVARCHAR(200) OUTPUT,
    @Permissions INT OUTPUT,
    @FullName NVARCHAR(200) OUTPUT,
    @IsActive BIT OUTPUT,
    @IsLocked BIT OUTPUT,
	@CreationDate DateTime Output,
	@LastLoginDate DateTime Output
AS
BEGIN
    SET NOCOUNT ON;
    SELECT
        @UserID = UserID,
        @PasswordHash = PasswordHash,
        @PasswordSalt = PasswordSalt,
        @Permissions = Permissions,
        @FullName = FullName,
        @IsActive = IsActive,
        @IsLocked = IsLocked,
	    @CreationDate = CreatedDate,
		@LastLoginDate = LastLoginDate
    FROM Users
    WHERE Username = @Username;
END;
GO

Create Or Alter Procedure sp_RecordLoginAttempt @Username NVARCHAR(100), @WasSuccessful BIT
As
Begin
    Set NOCOUNT ON;

    Insert Into LoginAttempts (Username , AttemptDate , WasSuccessful)
	Values (@Username , GetDate() , @WasSuccessful)
End
go 

Create Or Alter Procedure sp_LockUser @UserID Int
As 
BEGIN
   Set NOCOUNT ON
   Begin Try
      Begin Transaction
	    Update Users
		Set IsLocked = 1
		Where UserID = @UserID And IsLocked = 0;

		IF @@ROWCOUNT = 0
           THROW 51102, 'User not found or already locked.', 1;

		Insert Into AuditLog(UserID , Action , EntityType , EntityID , OldValue , NewValue, Timestamp)
	    Values (@UserID , 'LOCK_USER' , 'Users' , null , '0' , '1' , GetDate());
	  Commit 
   End Try  
   Begin Catch  
     if(@@TRANCOUNT > 0)
        Rollback Transaction  

	throw;
   End Catch
END  
go

Create Or Alter Procedure sp_UnlockUser (@TargetUserID INT, @AdminUserID INT)
As 
BEGIN
   Set NOCOUNT ON
   Begin Try
      Begin Transaction
	    Update Users
		Set IsLocked = 0
		Where UserID = @TargetUserID And IsLocked = 1;

		IF @@ROWCOUNT = 0
           THROW 51101, 'User not found or already unlocked.', 1;

		Insert Into AuditLog(UserID , Action , EntityType , EntityID , OldValue , NewValue, Timestamp)
	    Values (@AdminUserID , 'UNLOCK_USER' , 'Users' , @TargetUserID , '1' , '0' , GetDate());
	  Commit 
   End Try  
   Begin Catch  
     if(@@TRANCOUNT > 0)
        Rollback Transaction  

	throw;
   End Catch
END  
go

CREATE OR ALTER PROCEDURE sp_DeactivateUser @TargetUserID INT, @AdminUserID INT
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRANSACTION
            UPDATE Users
            SET IsActive = 0
            WHERE UserID = @TargetUserID AND IsActive = 1;

            IF @@ROWCOUNT = 0
                THROW 51001, 'User not found or already inactive.', 1;

            INSERT INTO AuditLog (UserID, Action, EntityType, EntityID, OldValue, NewValue, Timestamp)
            VALUES (@AdminUserID, 'USER_DEACTIVATED', 'Users', @TargetUserID, '1', '0', GETDATE());
        COMMIT TRANSACTION
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;

        THROW;
    END CATCH
END;
GO
