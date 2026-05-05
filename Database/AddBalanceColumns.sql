-- Run this first to add columns to Transactions table
ALTER TABLE Transactions ADD BalanceBefore decimal(18,2) NULL;
ALTER TABLE Transactions ADD BalanceAfter decimal(18,2) NULL;
GO

-- Update existing transactions with current account balances
UPDATE t
SET t.BalanceBefore = a.Balance,
    t.BalanceAfter = a.Balance
FROM Transactions t
JOIN Accounts a ON t.AccountID = a.AccountID
WHERE t.BalanceBefore IS NULL;
GO