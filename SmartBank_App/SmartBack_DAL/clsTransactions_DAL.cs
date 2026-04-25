
using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Threading.Tasks;

namespace SmartBack_DAL
{
    public static class clsTransactions_DAL
    {
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