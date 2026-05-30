# Smart Bank System

![.NET Framework](https://img.shields.io/badge/.NET%20Framework-4.7.2-512BD4)
![WinForms](https://img.shields.io/badge/UI-Windows%20Forms-0078D4)
![SQL Server](https://img.shields.io/badge/Database-SQL%20Server-CC2927)
![ADO.NET](https://img.shields.io/badge/Data%20Access-ADO.NET-2E7D32)
![Architecture](https://img.shields.io/badge/Architecture-UI%20%7C%20BLL%20%7C%20DAL%20%7C%20Service-111827)

Smart Bank System is a full Windows desktop banking management system built with C#, Windows Forms, SQL Server, pure ADO.NET, stored procedures, SQL functions, and a Windows Service for background scheduled-transfer processing.

This project is designed as a real operational banking workflow, not a simple CRUD demo. It includes customers, accounts, deposits, withdrawals, transfers, scheduled transfers, users, role-based permissions, audit logging, fraud detection, CSV exports, system configuration, encrypted remember-me login, and a production-style monitoring service.

---

## Table of Contents

- [Overview](#overview)
- [Main Features](#main-features)
- [Tech Stack](#tech-stack)
- [Architecture](#architecture)
- [Project Structure](#project-structure)
- [Database](#database)
- [Security Model](#security-model)
- [Scheduled Transfer Service](#scheduled-transfer-service)
- [Setup From Zero](#setup-from-zero)
- [Install The Windows Service](#install-the-windows-service)
- [Run The Application](#run-the-application)
- [Default Admin Login](#default-admin-login)
- [Usage Guide](#usage-guide)
- [Troubleshooting](#troubleshooting)
- [Verification Checklist](#verification-checklist)

---

## Overview

Smart Bank System manages the core workflow of a bank branch:

- Register and maintain customer profiles.
- Open savings and checking accounts.
- Deposit, withdraw, transfer, and schedule transfers.
- Enforce account status rules: `Active`, `Frozen`, and `Closed`.
- Enforce user roles and permission-based UI visibility.
- Track every important database action in an audit log.
- Detect suspicious debit behavior and create fraud flags.
- Run scheduled transfers automatically in the background through a Windows Service.
- Export customers, accounts, users, transactions, fraud flags, and audit logs to CSV.

The system is split into four projects so each responsibility stays clear:

| Project | Purpose |
|---|---|
| `SmartBank_UI` | Windows Forms desktop application and user workflows |
| `SmartBank_BLL` | Business rules, validation, security, permissions, and domain models |
| `SmartBack_DAL` | SQL Server access through ADO.NET, stored procedures, and SQL functions |
| `SmartBank_MonituringServices` | Windows Service that processes scheduled transfers and triggers fraud checks |

---

## Main Features

| Area | Feature |
|---|---|
| Dashboard | Live banking overview, recent transactions, fraud flags, active accounts, and pending scheduled transfers |
| Customers | Add, update, activate, deactivate, search, view short profile, upload customer image, and export CSV |
| Accounts | Open accounts, update account metadata, freeze, unfreeze, close, view account details, and export CSV |
| Transactions | Deposit, withdraw, transfer, schedule future transfers, view history, filter scheduled records, and export CSV |
| Scheduled Transfers | Pending transfers are stored in SQL and processed automatically by a Windows Service |
| Fraud Detection | Flags large withdrawals and rapid debit activity using configurable thresholds |
| Fraud Management | View, resolve, reopen, filter, and export fraud flags |
| Users | Add/update users, activate/deactivate users, lock/unlock users, view login attempts, assign roles, and export CSV |
| Permissions | Built-in Admin, Manager, Teller, and Custom role support using bitmask permissions |
| Audit Log | Tracks customer, account, transaction, user, fraud, and configuration actions |
| System Config | Edit fraud thresholds, max login attempts, scheduled-transfer retry count, and service interval |
| Security | Salted SHA-256 password hashing, AES encrypted remember-me password storage, and Windows Registry session cache |
| Logging | Windows Event Viewer logging plus scheduled-transfer service logs under `C:\SmartBank` |

---

## Tech Stack

| Technology | Role |
|---|---|
| C# | Main programming language |
| .NET Framework 4.7.2 | Runtime target for all projects |
| Windows Forms | Desktop UI |
| SQL Server | Main relational database |
| ADO.NET | Direct database access without an ORM |
| Stored Procedures | Core write operations and single-record lookups |
| SQL Functions | List/read views for grids and reports |
| Windows Service | Background scheduled-transfer processor |
| Windows Registry | Remember-me user cache |
| Windows Event Viewer | Application/system error logging |
| CSV Export | Operational reports from the UI |

### Why Pure ADO.NET?

This project intentionally uses direct ADO.NET instead of Entity Framework:

- Every database call is visible.
- Stored procedures can use output parameters cleanly.
- SQL Server remains the source of truth for transactional banking operations.
- Parameterized commands reduce SQL injection risk.
- No ORM abstraction hides what happens inside money-moving workflows.

---

## Architecture

```text
+-----------------------------------------------------------+
| SmartBank_UI                                              |
| Windows Forms screens, validation messages, grids, exports |
+-------------------------------+---------------------------+
                                |
+-------------------------------v---------------------------+
| SmartBank_BLL                                             |
| Business rules, permissions, fraud detection, security     |
+-------------------------------+---------------------------+
                                |
+-------------------------------v---------------------------+
| SmartBack_DAL                                             |
| ADO.NET, SqlConnection, SqlCommand, procedures/functions   |
+-------------------------------+---------------------------+
                                |
+-------------------------------v---------------------------+
| SQL Server: SmartBankDB                                   |
| Tables, stored procedures, scalar functions, table funcs   |
+-----------------------------------------------------------+

+-----------------------------------------------------------+
| SmartBank_MonituringServices                              |
| Windows Service that processes scheduled transfers         |
+-----------------------------------------------------------+
```

### Important Patterns

| Pattern | Where it appears |
|---|---|
| Layered Architecture | UI calls BLL, BLL calls DAL, DAL calls SQL Server |
| Repository-style DAL | `clsAccounts_DAL`, `clsCustomers_DAL`, `clsUsers_DAL`, `clsTransactions_DAL` |
| Active Record-style BLL | `clsAccounts`, `clsCustomers`, `clsUsers`, `clsFraudFlags` |
| Factory Find Methods | `FindAsync(...)` methods load domain objects from database DTOs |
| Permission Bitmask | `clsPermissions` maps roles and individual permissions to integer flags |
| Service Worker | `HandlingSchedualedTransfaresService` runs timed scheduled-transfer processing |
| Audit Trail | SQL procedures insert records into `AuditLog` after sensitive actions |

---

## Project Structure

```text
Smart_Bank_Proejct/
+-- Database/
|   +-- SmartBankDB.bak
+-- SmartBank_App/
    +-- SmartBank_UI.slnx
    +-- SmartBank_UI/
    |   +-- Accounts/
    |   +-- Audit Log/
    |   +-- Customers/
    |   +-- Dashboard/
    |   +-- Fraud Flags/
    |   +-- Main Forms/
    |   +-- Resources/
    |   +-- System Config/
    |   +-- Transaction/
    |   +-- Users/
    |   +-- App.config
    |   +-- Program.cs
    +-- SmartBank_BLL/
    |   +-- clsAccounts.cs
    |   +-- clsCustomers.cs
    |   +-- clsUsers.cs
    |   +-- clsPerformTransaction.cs
    |   +-- clsFraudDetectionService.cs
    |   +-- clsPermissions.cs
    |   +-- clsConfigurations.cs
    +-- SmartBack_DAL/
    |   +-- clsAccounts_DAL.cs
    |   +-- clsCustomers_DAL.cs
    |   +-- clsUsers_DAL.cs
    |   +-- clsTransactions_DAL.cs
    |   +-- clsFraudFlags_DAL.cs
    |   +-- clsAuditLog_DAL.cs
    |   +-- clsConfigurations_DAL.cs
    |   +-- clsDB_Util.cs
    +-- SmartBank_MonituringServices/
        +-- HandlingSchedualedTransfaresService.cs
        +-- ProjectInstaller.cs
        +-- App.config
        +-- Program.cs
```

---

## Database

The database backup is:

```text
Database/SmartBankDB.bak
```

The application expects the restored database name to be exactly:

```text
SmartBankDB
```

Both the UI and service use this connection string by default:

```xml
Server=.;Database=SmartBankDB;Trusted_Connection=True;
```

That means the system expects SQL Server on the local machine using Windows Authentication.

### Main Tables

The backup contains the operational schema for:

| Table | Purpose |
|---|---|
| `Customers` | Customer identity, contact data, image path, active status |
| `Accounts` | Bank accounts, type, balance, minimum balance, status, open/close dates |
| `Transactions` | Deposits, withdrawals, transfers, scheduled transfers, balance snapshots |
| `Users` | Application users, password hash/salt, role permissions, active/locked status |
| `LoginAttempts` | Successful and failed login attempt history |
| `AuditLog` | System-wide audit trail for sensitive actions |
| `FraudFlags` | Generated and manually managed fraud alerts |
| `SystemConfig` | Runtime-configurable thresholds and service settings |

### Stored Procedures Found In The Backup

The DAL and backup reference these SQL procedures:

```text
sp_CreateCustomer
sp_UpdateCustomer
sp_ActivateCustomer
sp_DeactivateCustomer
sp_GetCustomerByID
sp_GetCustomerByNationalID

sp_CreateAccount
sp_UpdateAccount
sp_FreezeAccount
sp_UnfreezeAccount
sp_CloseAccount
sp_GetAccountByID
sp_GetAccountByAccountNumber

sp_Deposit
sp_Withdraw
sp_Transfer
sp_ScheduleTransfer
sp_ProcessScheduledTransfers
sp_GetTransactionByID
sp_GetLatestTransactionByAccountID
sp_GetPostedDebitCountByAccountWithinWindow
sp_GetProcessedScheduledDebitTransactions

sp_CreateUser
sp_UpdateUser
sp_ActivateUser
sp_DeactivateUser
sp_LockUser
sp_UnlockUser
sp_GetUserByUsername
sp_GetUserByUserID
sp_RecordLoginAttempt
sp_GetAllLoginAttempts

sp_CreateFraudFlag
sp_GetFraudFlagByID
sp_ResolveFraudFlag
sp_ReopenFraudFlag

sp_GetAuditLogByAuditID
sp_GetAuditLogList

sp_GetConfigByID
sp_GetAllConfig
sp_UpdateSystemConfig
sp_ResetConfigToDefault
```

### SQL Functions Found In The Backup

```text
fn_GetAllCustomers
fn_GetAllAccounts
fn_GetAllUsers
fn_GetAllUserLoginAttempt
fn_GetAllTransactions
fn_GetAllFraudFlags
fn_GetUnresolvedFraudFlags
IsCustomerExistsByID
IsCustomerExistsByNationalID
IsAccountExistsByID
IsAccountExistsByNumber
IsUserExistByUsername
IsUserExistByID
IsFraudFlagExistsByID
```

---

## Security Model

### Roles

| Role | Permission Level |
|---|---|
| Teller | Deposit, withdraw, transfer, schedule transfer, open account, view statement |
| Manager | Teller permissions plus freeze/close accounts, fraud flags, audit logs, customer national ID, customer activation |
| Admin | Manager permissions plus user management, unlock users, change permissions, and edit system config |
| Custom | Any non-standard bitmask combination |

### Authentication And Passwords

- Passwords are salted and hashed with SHA-256.
- Each user has a stored password salt.
- Login attempts are recorded in SQL.
- Users can be locked after repeated failed login attempts.
- The max login attempt count is configurable in `SystemConfig`.

### Remember Me

The remember-me feature stores the username and encrypted password under:

```text
HKEY_CURRENT_USER\SOFTWARE\SmartBank_User
```

The password value is encrypted with AES before it is written to the registry.

---

## Scheduled Transfer Service

The Windows Service project is:

```text
SmartBank_App/SmartBank_MonituringServices
```

Service identity:

| Setting | Value |
|---|---|
| Service name | `HandlingSchedualedTransfaresService` |
| Display name | `Handling Schedualed Transfares Service in Smart Bank System` |
| Startup type | Automatic delayed start |
| Runtime account | `LocalSystem` |
| Default SQL dependency | `MSSQLSERVER` |
| Log file | `C:\SmartBank\SchedualTransfareLogs\service_logs.txt` |

Important: the service installer is currently configured to depend on the default SQL Server service name, `MSSQLSERVER`. The easiest setup is to install SQL Server as a default instance. If you use SQL Server Express as `.\SQLEXPRESS`, update the service dependency in `ProjectInstaller.cs` to `MSSQL$SQLEXPRESS` before building/installing the service.

### What The Service Does

1. Starts automatically with Windows.
2. Reads `ScheduledTransferCheckIntervalSeconds` from `SystemConfig`.
3. Runs scheduled-transfer processing on a timer.
4. Calls `sp_ProcessScheduledTransfers`.
5. Retries failed processing using `MaxScheduledTransferRetries`.
6. Finds processed scheduled debit transactions.
7. Runs fraud checks for large withdrawals and rapid transactions.
8. Logs each processing result to `C:\SmartBank\SchedualTransfareLogs\service_logs.txt`.

### Important Behavior

Scheduled transfers start as pending rows where `BalanceBefore` equals `BalanceAfter`. After the service processes them, the scheduled row is updated and the completed transfer behavior is reflected in the transaction/audit history.

---

## Setup From Zero

Follow these steps in order.

### 1. Install Required Software

Install:

| Requirement | Version |
|---|---|
| Windows | Windows 10 or Windows 11 |
| Visual Studio | 2022 recommended |
| .NET Framework Developer Pack | 4.7.2 |
| SQL Server | SQL Server Express, Developer, or higher |
| SQL Server Management Studio | Latest stable version |

During Visual Studio installation, include:

- `.NET desktop development`
- `.NET Framework 4.7.2 targeting pack`
- Windows Forms designer support

### 2. Clone The Repository

```bash
git clone https://github.com/tony11-cpu/smart-bank-system.git
cd smart-bank-system
```

### 3. Restore The Database

1. Open SQL Server Management Studio.
2. Connect to your local SQL Server.
3. Right-click `Databases`.
4. Choose `Restore Database`.
5. Select `Device`.
6. Add this file:

```text
Database\SmartBankDB.bak
```

7. Set the database name to:

```text
SmartBankDB
```

8. Click `OK` and wait for restore to finish.

### 4. Confirm The Connection String

Open both files:

```text
SmartBank_App\SmartBank_UI\App.config
SmartBank_App\SmartBank_MonituringServices\App.config
```

Default:

```xml
<add name="SmartBankDB"
     connectionString="Server=.;Database=SmartBankDB;Trusted_Connection=True;"
     providerName="System.Data.SqlClient" />
```

If you use SQL Server Express named instance, change `Server=.;` to:

```text
Server=.\SQLEXPRESS;
```

Make the same change in both config files.

### 5. Give The Service SQL Permission

The Windows Service runs as `LocalSystem`, so SQL Server must allow `NT AUTHORITY\SYSTEM` to access `SmartBankDB`.

Run this in SSMS:

```sql
USE [master];
GO

IF NOT EXISTS (
    SELECT 1
    FROM sys.server_principals
    WHERE name = N'NT AUTHORITY\SYSTEM'
)
BEGIN
    CREATE LOGIN [NT AUTHORITY\SYSTEM] FROM WINDOWS;
END
GO

USE [SmartBankDB];
GO

IF NOT EXISTS (
    SELECT 1
    FROM sys.database_principals
    WHERE name = N'NT AUTHORITY\SYSTEM'
)
BEGIN
    CREATE USER [NT AUTHORITY\SYSTEM] FOR LOGIN [NT AUTHORITY\SYSTEM];
END
GO

ALTER ROLE [db_owner] ADD MEMBER [NT AUTHORITY\SYSTEM];
GO
```

For a production environment, replace `db_owner` with least-privilege execute/read/write permissions. For local setup and graduation/demo use, `db_owner` is the simplest working option.

### 6. Create Runtime Folders

Run Command Prompt as Administrator:

```bat
mkdir C:\SmartBank
mkdir C:\SmartBank\SmartBankCustomers_Images
mkdir C:\SmartBank\SchedualTransfareLogs
```
These folders are used for customer images and service logs.
note: folders "C:\SmartBank\SmartBankCustomers_Images" & "C:\SmartBank\SchedualTransfareLogs" will be created automatically after the execution of the app

### 7. Open The Solution

Open:

```text
SmartBank_App\SmartBank_UI.slnx
```

If Visual Studio asks to trust the solution, trust it.

### 8. Build The Projects

Build in this order:

1. `SmartBack_DAL`
2. `SmartBank_BLL`
3. `SmartBank_MonituringServices`
4. `SmartBank_UI`

Or build the whole solution in `Release` mode.

---

## Install The Windows Service

The service must be installed after you build the solution.

### 1. Build Release

In Visual Studio:

1. Set configuration to `Release`.
2. Build the full solution.
3. Confirm this file exists:

```text
SmartBank_App\SmartBank_MonituringServices\bin\Release\SmartBank_MonituringServices.exe
```

### 2. Open Admin Developer Command Prompt

Open:

```text
Developer Command Prompt for Visual Studio
```

Run it as Administrator.

### 3. Install The Service

From the repository root:

```bat
InstallUtil.exe SmartBank_App\SmartBank_MonituringServices\bin\Release\SmartBank_MonituringServices.exe
```

### 4. Confirm Service Installation

```bat
sc.exe query HandlingSchedualedTransfaresService
sc.exe qc HandlingSchedualedTransfaresService
```

### 5. Start The Service

```bat
sc.exe start HandlingSchedualedTransfaresService
```

### 6. Configure Auto Restart On Failure

Run Command Prompt as Administrator:

```bat
sc.exe failure HandlingSchedualedTransfaresService reset= 86400 actions= restart/60000/restart/60000/restart/60000
sc.exe failureflag HandlingSchedualedTransfaresService 1
```

Important: `sc.exe` requires the space after `reset=` and `actions=`.

### 7. Optional Watchdog With Task Scheduler

This creates a Windows scheduled task that checks the service every 5 minutes and starts it if it is stopped.

Run PowerShell as Administrator:

```powershell
$Action = New-ScheduledTaskAction -Execute "powershell.exe" -Argument "-NoProfile -ExecutionPolicy Bypass -Command `"if ((Get-Service HandlingSchedualedTransfaresService).Status -ne 'Running') { Start-Service HandlingSchedualedTransfaresService }`""
$Trigger = New-ScheduledTaskTrigger -Once -At (Get-Date).AddMinutes(1) -RepetitionInterval (New-TimeSpan -Minutes 5)
$Principal = New-ScheduledTaskPrincipal -UserId "SYSTEM" -RunLevel Highest
Register-ScheduledTask -TaskName "SmartBank Service Watchdog" -Action $Action -Trigger $Trigger -Principal $Principal
```

### 8. Check Service Logs

Open:

```text
C:\SmartBank\SchedualTransfareLogs\service_logs.txt
```

You should see messages like:

```text
Service started successfully.
Service check interval set to 60 seconds.
0 scheduled transfers processed.
```

### 9. Uninstall The Service

Run as Administrator:

```bat
%WINDIR%\Microsoft.NET\Framework64\v4.0.30319\InstallUtil.exe /u SmartBank_App\SmartBank_MonituringServices\bin\Release\SmartBank_MonituringServices.exe
```

---

## Run The Application

### From Visual Studio

1. Set `SmartBank_UI` as the startup project.
2. Make sure SQL Server is running.
3. Make sure `SmartBankDB` exists.
4. Press `F5`.

### From The Executable

After building Release:

```text
SmartBank_App\SmartBank_UI\bin\Release\SmartBank_UI.exe
```

Run it normally. Run as Administrator only if your environment blocks registry, folder, or Event Viewer access.

---

## Default Admin Login

Use this account to start working with the system:

| Field | Value |
|---|---|
| Username | `Admin` |
| Password | `123123asd` |

After login, use the Admin account to create real users, assign roles, test permissions, and configure system thresholds.

---

## Usage Guide

| Task | Where To Go |
|---|---|
| See system summary | Dashboard |
| Add customer | Customers -> Add Customer |
| Edit customer | Customers -> Select Customer -> Update |
| Activate/deactivate customer | Customers -> Select Customer -> Activate/Deactivate |
| Open account | Accounts -> Open Account |
| Deposit money | Dashboard or Transactions -> New Deposit |
| Withdraw money | Dashboard or Transactions -> New Withdrawal |
| Transfer money | Dashboard or Transactions -> New Transfer |
| Schedule transfer | Transactions -> New Transfer -> Schedule |
| View transactions | Transactions screen |
| Filter scheduled transfers | Transactions screen scheduled filter |
| Freeze/unfreeze account | Accounts screen |
| Close account | Accounts screen, only when balance is zero |
| Review fraud flags | Fraud Flags screen |
| Resolve/reopen fraud flag | Fraud Flags screen |
| View audit history | Audit Log screen |
| Export records | Use the Export button on each grid |
| Add user | Users -> Add User |
| Lock/unlock user | Users screen |
| Change user permissions | Users -> Permissions |
| Edit thresholds | System Config |
| Check DB/service health | System Config |

---

## Business Rules

### Accounts

- Accounts can be `Savings` or `Checking`.
- Accounts can be `Active`, `Frozen`, or `Closed`.
- Only active accounts can normally send/receive transactions.
- Manager/Admin users can override some frozen-account flows.
- Accounts can close only when balance is zero.
- Minimum balance is enforced for normal users.

### Transactions

- Deposit amount must be greater than zero.
- Withdrawal amount must be greater than zero.
- Transfer amount must be greater than zero.
- Transfer source and destination cannot be the same account.
- Scheduled transfer date must be in the future.
- Empty transaction descriptions fall back to `No Description`.

### Fraud Detection

Fraud detection is configured by `SystemConfig`:

| Config Key | Default |
|---|---:|
| `LargeWithdrawalThreshold` | `10000` |
| `MaxLoginAttempts` | `5` |
| `MaxScheduledTransferRetries` | `3` |
| `RapidTransactionMaxCount` | `5` |
| `RapidTransactionWindowMinutes` | `10` |
| `ScheduledTransferCheckIntervalSeconds` | `60` |

The system creates fraud flags for:

- Debit transactions above the large withdrawal threshold.
- Too many debit transactions inside the rapid transaction window.

---

## Troubleshooting

### Login Fails Immediately

Check:

1. Database restored as `SmartBankDB`.
2. Connection string points to the correct SQL instance.
3. SQL Server service is running.
4. The admin account exists in the restored backup.

### Cannot Connect To Database

Open `System Config` in the app or test the database in SSMS.

If using SQL Express, update both config files:

```xml
Server=.\SQLEXPRESS;Database=SmartBankDB;Trusted_Connection=True;
```

### Service Does Not Start

Check:

```bat
sc.exe query HandlingSchedualedTransfaresService
sc.exe qc HandlingSchedualedTransfaresService
```

Then check:

```text
C:\SmartBank\SchedualTransfareLogs\service_logs.txt
```

If the service says SQL login failed, run the `NT AUTHORITY\SYSTEM` SQL permission script in this README.

### Service Installed But Never Processes Transfers

Check:

1. The service is running.
2. `ScheduledTransferCheckIntervalSeconds` is greater than zero.
3. Scheduled transfer date has passed.
4. Source account has enough balance.
5. Source and destination accounts are active or allowed by role/business rules.
6. SQL Server Agent is not required; this project uses its own Windows Service timer.

### InstallUtil Not Found

Use the full path:

```bat
%WINDIR%\Microsoft.NET\Framework64\v4.0.30319\InstallUtil.exe
```

If that file does not exist, install the .NET Framework 4.7.2 Developer Pack or Visual Studio .NET desktop workload.

### Build Fails In Command Line But Works In Visual Studio

This is a .NET Framework Windows Forms project. Visual Studio 2022 with the .NET desktop workload is the expected build environment. If `dotnet build` fails on WinForms resources, build from Visual Studio or full MSBuild from Developer Command Prompt.

---

## Verification Checklist

After setup, verify every item:

- [ ] `SmartBankDB` exists in SQL Server.
- [ ] UI and service config files point to the same SQL instance.
- [ ] `C:\SmartBank\SmartBankCustomers_Images` exists.
- [ ] `C:\SmartBank\SchedualTransfareLogs` exists.
- [ ] `SmartBank_UI` builds successfully.
- [ ] `SmartBank_MonituringServices` builds successfully.
- [ ] Login works with `Admin` / `123123asd`.
- [ ] Dashboard loads without database errors.
- [ ] A customer can be created.
- [ ] An account can be opened.
- [ ] Deposit creates a transaction.
- [ ] Withdrawal enforces minimum balance.
- [ ] Transfer blocks same source/destination account.
- [ ] Scheduled transfer appears as pending.
- [ ] Windows Service is running.
- [ ] Scheduled transfer is processed after its scheduled time.
- [ ] Service log file updates.
- [ ] Fraud flag appears after a configured suspicious transaction.
- [ ] Audit Log records user/account/transaction/config actions.
- [ ] CSV export works from the main grids.

---

## What This Project Demonstrates

- Three-tier desktop application architecture.
- SQL Server stored procedure driven data access.
- Pure ADO.NET without ORM dependency.
- Banking transaction validation and balance-state tracking.
- Windows Service background processing.
- Configurable fraud detection rules.
- Role-based access control with bitmask permissions.
- Password hashing, salts, encrypted registry remember-me storage.
- Audit logging for sensitive business operations.
- Practical deployment thinking: database restore, service installation, service recovery, logs, and health checks.
