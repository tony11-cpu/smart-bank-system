using SmartBack_DAL;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Threading.Tasks;

public class clsAccountsDto
{
    public int AccountID { get; set; }
    public int CustomerID { get; set; }
    public string AccountNumber { get; set; }
    public string AccountType { get; set; }
    public decimal Balance { get; set; }
    public decimal MinimumBalance { get; set; }
    public string Status { get; set; }
    public DateTime? OpenedDate { get; set; }
    public DateTime? ClosedDate { get; set; }
    public int CreatedByUserID { get; set; }

    public clsAccountsDto(int accountID, int customerID, string accountNumber, string accountType,
                          decimal balance, decimal minimumBalance, string status,
                          DateTime? openedDate, DateTime? closedDate, int createdByUserID)
    {
        AccountID = accountID;
        CustomerID = customerID;
        AccountNumber = accountNumber;
        AccountType = accountType;
        Balance = balance;
        MinimumBalance = minimumBalance;
        Status = status;
        OpenedDate = openedDate;
        ClosedDate = closedDate;
        CreatedByUserID = createdByUserID;
    }
}

public static class clsAccounts_DAL
{
    public static async Task<int> CreateAccountAsync(int currentUserID, int customerID, string accountNumber, string accountType, decimal balance, decimal minimumBalance)
    {
        using (SqlConnection conn = new SqlConnection(clsDB_Util.ConnectionString))
        using (SqlCommand cmd = new SqlCommand("sp_CreateAccount", conn))
        {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserInActionID", currentUserID);
            cmd.Parameters.AddWithValue("@CustomerID", customerID);
            cmd.Parameters.AddWithValue("@AccountNumber", accountNumber);
            cmd.Parameters.AddWithValue("@AccountType", accountType);
            cmd.Parameters.AddWithValue("@Balance", balance);
            cmd.Parameters.AddWithValue("@MinimumBalance", minimumBalance);

            SqlParameter outputParam = new SqlParameter("@NewAccountID", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };
            cmd.Parameters.Add(outputParam);

            try
            {
                await conn.OpenAsync();
                await cmd.ExecuteNonQueryAsync();

                return (int)outputParam.Value;
            }
            catch (SqlException ex)
            {
                clsDB_Util.clsLogger.Log(ex.Message, EventLogEntryType.Error);
            }
        }

        return -1;
    }

    public static async Task<bool> UpdateAccountAsync(int currentUserID, int accountID, string accountType, decimal minimumBalance)
    {
        using (SqlConnection conn = new SqlConnection(clsDB_Util.ConnectionString))
        using (SqlCommand cmd = new SqlCommand("sp_UpdateAccount", conn))
        {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserInActionID", currentUserID);
            cmd.Parameters.AddWithValue("@AccountID", accountID);
            cmd.Parameters.AddWithValue("@AccountType", accountType);
            cmd.Parameters.AddWithValue("@MinimumBalance", minimumBalance);

            SqlParameter outputParam = new SqlParameter("@IsUpdated", SqlDbType.Bit)
            {
                Direction = ParameterDirection.Output
            };
            cmd.Parameters.Add(outputParam);

            try
            {
                await conn.OpenAsync();
                await cmd.ExecuteNonQueryAsync();

                return (bool)outputParam.Value;
            }
            catch (SqlException ex)
            {
                clsDB_Util.clsLogger.Log(ex.Message, EventLogEntryType.Error);
            }
        }

        return false;
    }

    public static async Task<clsAccountsDto> GetAccountByIDAsync(int accountID, clsAccountsDto accountDto)
    {
        using (SqlConnection conn = new SqlConnection(clsDB_Util.ConnectionString))
        using (SqlCommand cmd = new SqlCommand("sp_GetAccountByID", conn))
        {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@AccountID", accountID);

            SqlParameter pAccountNumber = new SqlParameter("@AccountNumber", SqlDbType.NVarChar, 20) { Direction = ParameterDirection.Output };
            SqlParameter pCustomerID = new SqlParameter("@CustomerID", SqlDbType.Int) { Direction = ParameterDirection.Output };
            SqlParameter pAccountType = new SqlParameter("@AccountType", SqlDbType.NVarChar, 20) { Direction = ParameterDirection.Output };
            SqlParameter pBalance = new SqlParameter("@Balance", SqlDbType.Decimal) { Direction = ParameterDirection.Output };
            SqlParameter pMinimumBalance = new SqlParameter("@MinimumBalance", SqlDbType.Decimal) { Direction = ParameterDirection.Output };
            SqlParameter pStatus = new SqlParameter("@Status", SqlDbType.NVarChar, 20) { Direction = ParameterDirection.Output };
            SqlParameter pOpenedDate = new SqlParameter("@OpenedDate", SqlDbType.DateTime) { Direction = ParameterDirection.Output };
            SqlParameter pClosedDate = new SqlParameter("@ClosedDate", SqlDbType.DateTime) { Direction = ParameterDirection.Output };
            SqlParameter pCreatedByUserID = new SqlParameter("@CreatedByUserID", SqlDbType.Int) { Direction = ParameterDirection.Output };

            cmd.Parameters.Add(pAccountNumber);
            cmd.Parameters.Add(pCustomerID);
            cmd.Parameters.Add(pAccountType);
            cmd.Parameters.Add(pBalance);
            cmd.Parameters.Add(pMinimumBalance);
            cmd.Parameters.Add(pStatus);
            cmd.Parameters.Add(pOpenedDate);
            cmd.Parameters.Add(pClosedDate);
            cmd.Parameters.Add(pCreatedByUserID);

            try
            {
                await conn.OpenAsync();
                await cmd.ExecuteNonQueryAsync();

                if (pAccountNumber.Value == DBNull.Value)
                    return null;

                return accountDto = new clsAccountsDto(accountID, (int)pCustomerID.Value, (string)pAccountNumber.Value,
                                               (string)pAccountType.Value, (decimal)pBalance.Value, (decimal)pMinimumBalance.Value,
                                               (string)pStatus.Value, (DateTime)pOpenedDate.Value, pClosedDate.Value == DBNull.Value ? (DateTime?)null : (DateTime)pClosedDate.Value,
                                               (int)pCreatedByUserID.Value); 
            }
            catch (SqlException ex)
            {
                clsDB_Util.clsLogger.Log(ex.Message, EventLogEntryType.Error);
            }
        }

        return null;
    }

    public static async Task<clsAccountsDto> GetAccountByNumberAsync(string accountNumber, clsAccountsDto accountDto)
    {
        using (SqlConnection conn = new SqlConnection(clsDB_Util.ConnectionString))
        using (SqlCommand cmd = new SqlCommand("sp_GetAccountByAccountNumber", conn))
        {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@AccountNumber", accountNumber);

            SqlParameter pAccountID = new SqlParameter("@AccountID", SqlDbType.Int) { Direction = ParameterDirection.Output };
            SqlParameter pCustomerID = new SqlParameter("@CustomerID", SqlDbType.Int) { Direction = ParameterDirection.Output };
            SqlParameter pAccountType = new SqlParameter("@AccountType", SqlDbType.NVarChar, 20) { Direction = ParameterDirection.Output };
            SqlParameter pBalance = new SqlParameter("@Balance", SqlDbType.Decimal) { Direction = ParameterDirection.Output };
            SqlParameter pMinimumBalance = new SqlParameter("@MinimumBalance", SqlDbType.Decimal) { Direction = ParameterDirection.Output };
            SqlParameter pStatus = new SqlParameter("@Status", SqlDbType.NVarChar, 20) { Direction = ParameterDirection.Output };
            SqlParameter pOpenedDate = new SqlParameter("@OpenedDate", SqlDbType.DateTime) { Direction = ParameterDirection.Output };
            SqlParameter pClosedDate = new SqlParameter("@ClosedDate", SqlDbType.DateTime) { Direction = ParameterDirection.Output };
            SqlParameter pCreatedByUserID = new SqlParameter("@CreatedByUserID", SqlDbType.Int) { Direction = ParameterDirection.Output };

            cmd.Parameters.Add(pAccountID);
            cmd.Parameters.Add(pCustomerID);
            cmd.Parameters.Add(pAccountType);
            cmd.Parameters.Add(pBalance);
            cmd.Parameters.Add(pMinimumBalance);
            cmd.Parameters.Add(pStatus);
            cmd.Parameters.Add(pOpenedDate);
            cmd.Parameters.Add(pClosedDate);
            cmd.Parameters.Add(pCreatedByUserID);

            try
            {
                await conn.OpenAsync();
                await cmd.ExecuteNonQueryAsync();

                if (pAccountID.Value == DBNull.Value)
                    return null;

                return new clsAccountsDto((int)pAccountID.Value, (int)pCustomerID.Value, accountNumber,
                                               (string)pAccountType.Value, (decimal)pBalance.Value, (decimal)pMinimumBalance.Value,
                                               (string)pStatus.Value, (DateTime)pOpenedDate.Value, pClosedDate.Value == DBNull.Value ? (DateTime?)null : (DateTime)pClosedDate.Value,
                                               (int)pCreatedByUserID.Value);
            }
            catch (SqlException ex)
            {
                clsDB_Util.clsLogger.Log(ex.Message, EventLogEntryType.Error);
            }
        }

        return null;
    }

    public static async Task<bool> FreezeAccountAsync(int currentUserID, int accountID) => await _executeStatusProcedureAsync("sp_FreezeAccount", currentUserID, accountID);

    public static async Task<bool> UnfreezeAccountAsync(int currentUserID, int accountID) => await _executeStatusProcedureAsync("sp_UnfreezeAccount", currentUserID, accountID);

    public static async Task<bool> CloseAccountAsync(int currentUserID, int accountID) => await _executeStatusProcedureAsync("sp_CloseAccount", currentUserID, accountID);

    private static async Task<bool> _executeStatusProcedureAsync(string procedureName, int currentUserID, int accountID)
    {
        using (SqlConnection conn = new SqlConnection(clsDB_Util.ConnectionString))
        using (SqlCommand cmd = new SqlCommand(procedureName, conn))
        {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserInActionID", currentUserID);
            cmd.Parameters.AddWithValue("@AccountID", accountID);
            SqlParameter outputParam = new SqlParameter("@IsUpdated", SqlDbType.Bit) { Direction = ParameterDirection.Output };
            cmd.Parameters.Add(outputParam);

            try
            {
                await conn.OpenAsync();
                await cmd.ExecuteNonQueryAsync();

                return (bool)outputParam.Value;
            }
            catch (SqlException ex)
            {
                clsDB_Util.clsLogger.Log(ex.Message, EventLogEntryType.Error);
            }
        }

        return false;
    }

    public static async Task<DataTable> GetAllAccountsAsync()
    {
        DataTable dt = new DataTable();
        using (SqlConnection conn = new SqlConnection(clsDB_Util.ConnectionString))
        using (SqlCommand cmd = new SqlCommand("SELECT * FROM fn_GetAllAccounts()", conn))
        {
            try
            {
                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                    dt.Load(reader); 

                return dt;
            }
            catch (Exception ex)
            {
                clsDB_Util.clsLogger.Log(ex.Message, EventLogEntryType.Error);
                return null;
            }
        }
    }

    public static async Task<bool> IsAccountExistsByIDAsync(int accountID)
    {
        using (SqlConnection conn = new SqlConnection(clsDB_Util.ConnectionString))
        using (SqlCommand cmd = new SqlCommand("SELECT dbo.IsAccountExistsByID(@AccountID)", conn))
        {
            cmd.Parameters.AddWithValue("@AccountID", accountID);

            try
            {
                await conn.OpenAsync();
                return Convert.ToBoolean(await cmd.ExecuteScalarAsync());
            }
            catch (SqlException ex)
            {
                clsDB_Util.clsLogger.Log(ex.Message, EventLogEntryType.Error);
            }
        }

        return false;
    }

    public static async Task<DataTable> GetAccountsByCustomerIDAsync(int customerID)
    {
        DataTable dt = new DataTable();
        using (SqlConnection conn = new SqlConnection(clsDB_Util.ConnectionString))
        using (SqlCommand cmd = new SqlCommand("SELECT * FROM fn_GetAllAccounts() WHERE CustomerID = @CustomerID", conn))
        {
            cmd.Parameters.AddWithValue("@CustomerID", customerID);
            try
            {
                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                    dt.Load(reader);
            }
            catch (Exception ex)
            {
                clsDB_Util.clsLogger.Log(ex.Message);
                dt = null;
            }
        }

        return dt;
    }

    public static async Task<bool> IsAccountExistsByNumberAsync(string accountNumber)
    {
        using (SqlConnection conn = new SqlConnection(clsDB_Util.ConnectionString))
        using (SqlCommand cmd = new SqlCommand("SELECT dbo.IsAccountExistsByNumber(@AccountNumber)", conn))
        {
            cmd.Parameters.AddWithValue("@AccountNumber", accountNumber);
            try
            {
                await conn.OpenAsync();
                return Convert.ToBoolean(await cmd.ExecuteScalarAsync());
            }
            catch (SqlException ex)
            {
                clsDB_Util.clsLogger.Log(ex.Message, EventLogEntryType.Error);
            }
        }

        return false;
    }
}