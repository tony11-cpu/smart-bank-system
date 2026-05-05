
using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Threading.Tasks;

namespace SmartBack_DAL
{
    public class clsTransactionDto
    {
        public clsTransactionDto(int transactionID, int accountID, string transactionType, 
                                 decimal amount, int? relatedAccountID, string description, 
                                 DateTime transactionDate, int processedByUserID, bool isScheduled,
                                 decimal balanceBefore = 0, decimal balanceAfter = 0)
        {
            TransactionID = transactionID;
            AccountID = accountID;
            TransactionType = transactionType;
            Amount = amount;
            RelatedAccountID = relatedAccountID;
            Description = description;
            TransactionDate = transactionDate;
            ProcessedByUserID = processedByUserID;
            IsScheduled = isScheduled;
            BalanceBefore = balanceBefore;
            BalanceAfter = balanceAfter;
        }

        public int TransactionID { get; set; }
        public int AccountID { get; set; }
        public string TransactionType { get; set; }
        public decimal Amount { get; set; }
        public int? RelatedAccountID { get; set; }
        public string Description { get; set; }
        public DateTime TransactionDate { get; set; }
        public int ProcessedByUserID { get; set; }
        public bool IsScheduled { get; set; }
        public decimal BalanceBefore { get; set; }
        public decimal BalanceAfter { get; set; }
    }

    public static class clsTransactions_DAL
    {
        public static async Task<clsTransactionDto> GetTransactionByIDAsync(int transactionID)
        {
            using (SqlConnection conn = new SqlConnection(clsDB_Util.ConnectionString))
            using (SqlCommand cmd = new SqlCommand("sp_GetTransactionByID", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TransactionID", transactionID);

                SqlParameter pAccountID = new SqlParameter("@AccountID", SqlDbType.Int) { Direction = ParameterDirection.Output };
                SqlParameter pTransactionType = new SqlParameter("@TransactionType", SqlDbType.NVarChar, 20) { Direction = ParameterDirection.Output };
                SqlParameter pAmount = new SqlParameter("@Amount", SqlDbType.Decimal) { Direction = ParameterDirection.Output };
                SqlParameter pRelatedAccountID = new SqlParameter("@RelatedAccountID", SqlDbType.Int) { Direction = ParameterDirection.Output };
                SqlParameter pDescription = new SqlParameter("@Description", SqlDbType.NVarChar, 250) { Direction = ParameterDirection.Output };
                SqlParameter pTransactionDate = new SqlParameter("@TransactionDate", SqlDbType.DateTime) { Direction = ParameterDirection.Output };
                SqlParameter pProcessedByUserID = new SqlParameter("@ProcessedByUserID", SqlDbType.Int) { Direction = ParameterDirection.Output };
                SqlParameter pIsScheduled = new SqlParameter("@IsScheduled", SqlDbType.Bit) { Direction = ParameterDirection.Output };
                SqlParameter pBalanceBefore = new SqlParameter("@BalanceBefore", SqlDbType.Decimal) { Direction = ParameterDirection.Output };
                SqlParameter pBalanceAfter = new SqlParameter("@BalanceAfter", SqlDbType.Decimal) { Direction = ParameterDirection.Output };

                cmd.Parameters.Add(pAccountID);
                cmd.Parameters.Add(pTransactionType);
                cmd.Parameters.Add(pAmount);
                cmd.Parameters.Add(pRelatedAccountID);
                cmd.Parameters.Add(pDescription);
                cmd.Parameters.Add(pTransactionDate);
                cmd.Parameters.Add(pProcessedByUserID);
                cmd.Parameters.Add(pIsScheduled);
                cmd.Parameters.Add(pBalanceBefore);
                cmd.Parameters.Add(pBalanceAfter);

                try
                {
                    await conn.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                    if (pAccountID.Value == DBNull.Value) 
                        return null;

                    return new clsTransactionDto((int)pAccountID.Value, (int)pAccountID.Value, (string)pTransactionType.Value,
                        (decimal)pAmount.Value, pRelatedAccountID.Value == DBNull.Value ? null : (int?)pRelatedAccountID.Value,
                        pDescription.Value == DBNull.Value ? null : (string)pDescription.Value, (DateTime)pTransactionDate.Value,
                        (int)pProcessedByUserID.Value, (bool)pIsScheduled.Value,
                        pBalanceBefore.Value == DBNull.Value ? 0 : (decimal)pBalanceBefore.Value,
                        pBalanceAfter.Value == DBNull.Value ? 0 : (decimal)pBalanceAfter.Value);
                }
                catch (SqlException ex)
                {
                    clsDB_Util.clsLogger.Log(ex.Message, EventLogEntryType.Error);
                }
            }

            return null;
        }

        public static async Task<clsTransactionDto> GetLatestTransactionByAccountIDAsync(int accountID)
        {
            using (SqlConnection conn = new SqlConnection(clsDB_Util.ConnectionString))
            using (SqlCommand cmd = new SqlCommand("sp_GetLatestTransactionByAccountID", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@AccountID", accountID);

                SqlParameter pTransactionID = new SqlParameter("@TransactionID", SqlDbType.Int) { Direction = ParameterDirection.Output };
                SqlParameter pTransactionType = new SqlParameter("@TransactionType", SqlDbType.NVarChar, 20) { Direction = ParameterDirection.Output };
                SqlParameter pAmount = new SqlParameter("@Amount", SqlDbType.Decimal) { Direction = ParameterDirection.Output };
                SqlParameter pRelatedAccountID = new SqlParameter("@RelatedAccountID", SqlDbType.Int) { Direction = ParameterDirection.Output };
                SqlParameter pDescription = new SqlParameter("@Description", SqlDbType.NVarChar, 250) { Direction = ParameterDirection.Output };
                SqlParameter pTransactionDate = new SqlParameter("@TransactionDate", SqlDbType.DateTime) { Direction = ParameterDirection.Output };
                SqlParameter pProcessedByUserID = new SqlParameter("@ProcessedByUserID", SqlDbType.Int) { Direction = ParameterDirection.Output };
                SqlParameter pIsScheduled = new SqlParameter("@IsScheduled", SqlDbType.Bit) { Direction = ParameterDirection.Output };

                cmd.Parameters.Add(pTransactionID);
                cmd.Parameters.Add(pTransactionType);
                cmd.Parameters.Add(pAmount);
                cmd.Parameters.Add(pRelatedAccountID);
                cmd.Parameters.Add(pDescription);
                cmd.Parameters.Add(pTransactionDate);
                cmd.Parameters.Add(pProcessedByUserID);
                cmd.Parameters.Add(pIsScheduled);

                try
                {
                    await conn.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                    if (pTransactionID.Value == DBNull.Value) return null;

                    return new clsTransactionDto((int)pTransactionID.Value, accountID, (string)pTransactionType.Value, (decimal)pAmount.Value,
                        pRelatedAccountID.Value == DBNull.Value ? null : (int?)pRelatedAccountID.Value, 
                        pDescription.Value == DBNull.Value ? null : (string)pDescription.Value, (DateTime)pTransactionDate.Value, (int)pProcessedByUserID.Value, (bool)pIsScheduled.Value);
                }
                catch (SqlException ex)
                {
                    clsDB_Util.clsLogger.Log(ex.Message, EventLogEntryType.Error);
                }
            }

            return null;
        }

        public static async Task<bool> DepositAsync(int accountID, decimal amount, string description, int performedByUserID)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(clsDB_Util.ConnectionString))
                using (SqlCommand cmd = new SqlCommand("sp_Deposit", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@UserInActionID", performedByUserID);
                    cmd.Parameters.AddWithValue("@AccountID", accountID);
                    cmd.Parameters.AddWithValue("@Amount", amount);
                    cmd.Parameters.AddWithValue("@Description", description);

                    SqlParameter pNewTransactionID = new SqlParameter("@NewTransactionID", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(pNewTransactionID);

                    await conn.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                    return (int)pNewTransactionID.Value > 0;
                }
            }
            catch (SqlException ex)
            {
                clsDB_Util.clsLogger.Log(ex.Message, EventLogEntryType.Error);
            }

            return false;
        }

        public static async Task<bool> WithdrawAsync(int accountID, decimal amount, string description, int performedByUserID)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(clsDB_Util.ConnectionString))
                using (SqlCommand cmd = new SqlCommand("sp_Withdraw", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@UserInActionID", performedByUserID);
                    cmd.Parameters.AddWithValue("@AccountID", accountID);
                    cmd.Parameters.AddWithValue("@Amount", amount);
                    cmd.Parameters.AddWithValue("@Description", description);

                    SqlParameter pNewTransactionID = new SqlParameter("@NewTransactionID", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(pNewTransactionID);

                    await conn.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                    return (int)pNewTransactionID.Value > 0;
                }
            }
            catch (SqlException ex)
            {
                clsDB_Util.clsLogger.Log(ex.Message, EventLogEntryType.Error);
            }

            return false;
        }

        public static async Task<bool> TransferAsync(int fromAccountID, int toAccountID, decimal amount, string description, int performedByUserID)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(clsDB_Util.ConnectionString))
                using (SqlCommand cmd = new SqlCommand("sp_Transfer", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@UserInActionID", performedByUserID);
                    cmd.Parameters.AddWithValue("@FromAccountID", fromAccountID);
                    cmd.Parameters.AddWithValue("@ToAccountID", toAccountID);
                    cmd.Parameters.AddWithValue("@Amount", amount);
                    cmd.Parameters.AddWithValue("@Description", description);

                    SqlParameter pNewTransactionID = new SqlParameter("@NewTransactionID", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(pNewTransactionID);

                    await conn.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                    return (int)pNewTransactionID.Value > 0;
                }
            }
            catch (SqlException ex)
            {
                clsDB_Util.clsLogger.Log(ex.Message, EventLogEntryType.Error);
            }

            return false;
        }

        public static async Task<DataTable> GetAllTransactionsAsync()
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection conn = new SqlConnection(clsDB_Util.ConnectionString))
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.fn_GetAllTransactions()", conn))
                {
                    await conn.OpenAsync();
                    using (SqlDataReader adapter = await cmd.ExecuteReaderAsync())
                        dt.Load(adapter);

                    return dt;
                }
            }
            catch (SqlException ex)
            {
                clsDB_Util.clsLogger.Log(ex.Message, EventLogEntryType.Error);
            }

            return null;
        }
    }
}