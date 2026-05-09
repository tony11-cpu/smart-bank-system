# Smart Bank Project - Complete Documentation

## Overview
Smart Bank is a Windows Forms desktop banking application built with C# (.NET). The project follows a 3-tier architecture with a Business Logic Layer (BLL), Data Access Layer (DAL), and User Interface (UI). It also includes a Windows Service for scheduled transfers.

## Project Structure
```
Smart_Bank_Project/
├── SmartBank_App/
│   ├── SmartBank_BLL/          # Business Logic Layer
│   ├── SmartBack_DAL/          # Data Access Layer
│   ├── SmartBank_UI/           # Windows Forms UI
│   └── SmartBank_MonituringServices/  # Scheduled Transfer Windows Service
└── Database/                   # SQL Scripts and Backups
```

---

## Version History & Changes

### Version 1.0 - Initial Setup (Commit: b513f38)
- Initial project structure and database schema
- Created base project with 3-tier architecture

### Version 1.1 - UI Framework (Commits: 46bbe80 - a60106f)
- Created User BLL & DAL classes
- Implemented User Permission class and 80% of DAL for Users
- Started Login Screen UI development
- Built System Configuration Screen
- Changed clsConfigurations building structure
- Updated clsUsers class

### Version 1.2 - User Management (Commits: 60fbe37 - b2cd3e4)
- Finished User Account Screen
- Fixed all User Login Attempt Screen issues
- Added AddOrUpdate User Control
- Developed User Adding/Updating Form with permissions
- Created Users Main Form Design
- Implemented "Prevent User From Updating Himself" functionality

### Version 1.3 - Customer Management (Commits: 04cc692 - ed56ae1)
- Built Customer Main Forms and User Controls
- Created Customers DAL & BLL
- Added Customer Add/Update functionality
- Implemented Search Bar with filtering
- Fixed errors in Customer Forms
- Created `frmAddOrUpdateCustomer` (later renamed to `frmAddOrUpdate`)
- Rearranged Forms and User Controls into appropriate named files
- Added Account User Control development

### Version 1.4 - Account Management (Commits: 947faa2 - cf448b4)
- Created Accounts DAL & BLL
- Added Account Add/Update Form with UI components
- Implemented "Show All Customer Accounts Made By His National ID" form
- Pushed new database backup with account features
- Updated Add/Update Account Form with validations
- Applied all missing account features and functionalities

### Version 1.5 - Transaction System (Commits: 5189915 - 8e6a68c)
- Created Transaction Type forms (Deposit/Withdrawl/Transfer)
- Built Transaction Main Screen UI
- Implemented Transaction Type Selection User Control
- Added "Perform Transaction" form layout
- Implemented Export Transactions functionality
- Fixed Exporting functionality errors

### Version 1.6 - Async Refactoring (Commits: 0cc413d - 13e8928)
- Converted Users DAL to async/await
- Updated dependent layers
- Fixed all forms issues related to async customers
- Created Async Config BLL and DAL
- Fixed async configuration errors
- Solved all errors due to async configuration

### Version 1.7 - Transaction Enhancement (Commits: 25d6450 - 1a9eaf7)
- Added Transaction Properties & Functionality to Main Dashboard
- Implemented Load To Account Form with Message Box
- Connected Forms with Delegates
- Created sub-form `frmAccountShortInfo`
- Added default account number copying on transaction type selection
- Implemented live transaction view
- Fixed search crashing on non-numeric input

### Version 1.8 - Balance & Validation (Commits: 28b9ee4 - 3d9c61f)
- Fixed balance before/after calculation using current balance and transaction type
- Fixed crash by using fallback when BalanceAfterTransaction is zero
- Added balance before/after columns to database
- Added null checks to prevent crashes in transaction details loading
- Added destination account status validation (only Active accounts can receive transfers)

### Version 1.9 - Transaction UI Improvements (Commits: 4b7dc9d - fad2f5c)
- Wrapped transaction calls in try-catch to handle exceptions
- Show success/failure message based on transaction result
- Added OnTransactionCompleted event to clsGlobal
- Added live refresh timer to main form
- Implemented transaction execution in switch cases

### Version 2.0 - Login & Live Features (Commits: b5a76ec - 4019026)
- Added live transactions grid on login screen showing today's transactions
- Added live refresh of transaction counts on login screen
- Added OnTransactionCompleted event that fires after successful transaction
- Dashboard subscribes to refresh when transaction completes
- Added live reference for balance and to account

### Version 2.1 - Final Transaction Fixes (Commits: 6d5e78a - b327af4)
- Added minimum balance bypass for Manager/Admin
- Added better error messages for transfer/deposits/withdrawals
- Refactored clsPerformTransaction - extracted shared validation methods
- Fixed Enter Key press for searching
- Fixed balance before/after to show transaction amount

### Version 2.2 - Scheduled Transfers (Commits: 0a2674a - c7a41ee)
- Added SQL stored procedures for scheduled transfers
- Created DAL methods for scheduled transfers
- Implemented ScheduleTransferAsync in BLL
- Connected UI to scheduled transfers feature
- Added pending status display for scheduled transfers
- Simplified transaction click handler
- Added scheduled transfer service with basic structure

### Version 2.3 - Scheduled Transfer Service (Commits: 9b1656f - fc62dde)
- Added monitoring services project for scheduled transfers
- Created BLL, DAL, UI and Service setup for scheduled transfers
- Enhanced scheduled transfer service with async OnStart
- Updated ProjectInstaller with SQL dependency
- Added better error handling to surface actual errors
- Added fix for sp_ProcessScheduledTransfers
- Fixed date format mismatch in UI and added connection string to service

---

## Core Components

### Business Logic Layer (SmartBank_BLL)

| Class | Purpose |
|-------|---------|
| `clsUsers` | User authentication, permissions, login attempts |
| `clsCustomers` | Customer CRUD operations |
| `clsAccounts` | Account management, balance operations |
| `clsTransactionLog` | Transaction history and logging |
| `clsPerformTransaction` | Execute deposit, withdrawal, transfer operations |
| `clsConfigurations` | System configuration settings |
| `clsPermissions` | Permission management |
| `clsGlobal` | Global state and events (OnTransactionCompleted) |
| `clsUtil` | Utility methods |

### Data Access Layer (SmartBack_DAL)

| Class | Purpose |
|-------|---------|
| `clsUsers_DAL` | Database operations for users |
| `clsCustomers_DAL` | Database operations for customers |
| `clsAccounts_DAL` | Database operations for accounts |
| `clsTransactionLog_DAL` | Database operations for transactions |
| `clsConfigurations_DAL` | Database operations for configurations |

### User Interface (SmartBank_UI)

| Form | Purpose |
|------|---------|
| `frmLogin` | User login with live transaction counts |
| `frmMain` | Main dashboard with transaction counts |
| `frmUsers` | User management (main, add/update) |
| `frmCustomers` | Customer management (main, add/update) |
| `frmAccounts` | Account management (main, add/update) |
| `frmTransactions` | Transaction main screen |
| `ctrlTransactionsMainScreen` | Transaction list and filtering |
| `ctrlTransfareTransactionTypeAndInfo` | Transfer transaction type selection |
| `ctrlDepositTransactionTypeAndInfo` | Deposit transaction |
| `ctrlWithdrawTransactionTypeAndInfo` | Withdrawal transaction |
| `frmSystemConfigurations` | System settings |
| `frmAddOrUpdate` | Combined add/update form for customers/accounts |

### Scheduled Transfer Service (SmartBank_MonituringServices)

| Component | Purpose |
|-----------|---------|
| `ProjectInstaller` | Windows service installer with SQL dependency |
| `Service` | Background service processing scheduled transfers |

---

## Database Features

### Tables Created
- Users (with permissions, login attempts)
- Customers (national ID, personal info)
- Accounts (account number, balance, status)
- TransactionLog (amount, type, balance before/after)
- ScheduledTransfers (schedule, status, execution)
- Configurations (system settings)

### Stored Procedures
- `sp_AddUpdateUser`, `sp_GetUserByID`, `sp_GetAllUsers`
- `sp_AddUpdateCustomer`, `sp_GetCustomerByID`, `sp_GetAllCustomers`
- `sp_AddUpdateAccount`, `sp_GetAccountByID`, `sp_GetAllAccounts`
- `sp_AddTransaction`, `sp_GetAllTransactions`, `sp_GetTransactionsByDate`
- `sp_GetTransactionByID`, `sp_FindTransaction`
- `sp_AddScheduledTransfer`, `sp_GetAllScheduledTransfers`, `sp_ProcessScheduledTransfers`
- `fn_GetAllTransactions` - Returns transactions with balance columns

---

## Key Features Implemented

### Authentication & Authorization
- User login with validation
- Permission-based access (Admin, Manager, Employee)
- Login attempt tracking
- User self-edit prevention

### Account Management
- Create/Update/Delete accounts
- Account status (Active, Closed, Blocked)
- Balance tracking
- National ID-based account lookup

### Transaction System
- **Deposit**: Add funds to account
- **Withdrawal**: Remove funds (with minimum balance check)
- **Transfer**: Move funds between accounts
- Balance before/after tracking
- Live transaction view on dashboard

### Scheduled Transfers
- Schedule future transfers
- Background Windows Service for processing
- Pending/Completed status tracking
- Error handling and logging

### Live Updates
- Transaction counts on login screen
- Live transaction grid on main dashboard
- Auto-refresh on transaction completion
- Real-time balance updates

### Search & Filtering
- Transaction search by ID, date, type
- Customer search by name, national ID
- Account search by number, customer

---

## Validation Features

### Transfer Validation
- Same-account validation
- Destination account status check (only Active)
- Sufficient balance check

### Withdrawal Validation
- Minimum balance requirement ($10)
- Manager/Admin bypass capability

### Transaction Validation
- Amount > 0 validation
- Description length validation
- Error message display with specific reasons

---

## Error Handling

### Transaction Errors
- Generic error messages → Specific account status messages
- Exception handling with try-catch blocks
- Success/Failure message boxes

### Async Error Handling
- Async/await pattern throughout
- Proper exception propagation
- Configuration error fixes

### Null Safety
- Null checks for transaction objects
- Split null safety in users
- Transaction find null checks

---

## Build & Configuration

### Release Mode Fixes
- Removed duplicate TargetFramework attributes
- Proper namespace configuration

### Logging
- Fixed log path for scheduled transfer service
- Added unauthorized access handling
- Log transaction events

---

## Total Commits: 100+

---

## Future Enhancements (Not Yet Implemented)
- Reports generation
- Audit trail
- Multi-branch support
- Online banking integration
- Mobile notifications