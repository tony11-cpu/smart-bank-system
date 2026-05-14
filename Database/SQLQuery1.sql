USE [SmartBankDB]
GO

Delete From LoginAttempts
DBCC CHECKIDENT ('LoginAttempts', RESEED, 0);
go
Delete From AuditLog
DBCC CHECKIDENT ('AuditLog', RESEED, 0);
go
Delete From Accounts
DBCC CHECKIDENT ('Accounts', RESEED, 0);
go
Delete From Transactions
DBCC CHECKIDENT ('Transactions', RESEED, 0);
go
Delete From Customers
DBCC CHECKIDENT ('Customers', RESEED, 0);

Delete From Users
Where UserID <> 1
DBCC CHECKIDENT ('Users', RESEED, 1)
GO
