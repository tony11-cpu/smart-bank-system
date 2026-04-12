using SmartBack_DAL;
using System;
using System.Data;
using System.Data.SqlClient;

public static class clsAccounts_DAL
{
    public static int CreateAccount(int currentUserID, int customerID, string accountNumber, string accountType, decimal balance, decimal minimumBalance)
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
                conn.Open();
                cmd.ExecuteNonQuery();
                return (int)outputParam.Value;
            }
            catch (Exception ex)
            {
                clsDB_Util.clsLogger.Log(ex.Message);
            }
        }

        return -1;
    }

    public static bool UpdateAccount(int currentUserID, int accountID, string accountType, decimal minimumBalance)
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
                conn.Open();
                cmd.ExecuteNonQuery();
                return (bool)outputParam.Value;
            }
            catch (Exception ex)
            {
                clsDB_Util.clsLogger.Log(ex.Message);
            }
        }

        return false;
    }

    public static bool GetAccountByID(int accountID, ref string accountNumber, ref int customerID, ref string accountType, ref decimal balance,
                                  ref decimal minimumBalance, ref string status, ref DateTime? openedDate, ref DateTime? closedDate, ref int createdByUserID)
    {
        using (SqlConnection conn = new SqlConnection(clsDB_Util.ConnectionString))
        using (SqlCommand cmd = new SqlCommand("sp_GetAccountByID", conn))
        {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@AccountID", accountID);
            cmd.Parameters.Add(new SqlParameter("@AccountNumber", SqlDbType.NVarChar, 20) { Direction = ParameterDirection.Output });
            cmd.Parameters.Add(new SqlParameter("@CustomerID", SqlDbType.Int) { Direction = ParameterDirection.Output });
            cmd.Parameters.Add(new SqlParameter("@AccountType", SqlDbType.NVarChar, 20) { Direction = ParameterDirection.Output });
            cmd.Parameters.Add(new SqlParameter("@Balance", SqlDbType.Decimal) { Direction = ParameterDirection.Output });
            cmd.Parameters.Add(new SqlParameter("@MinimumBalance", SqlDbType.Decimal) { Direction = ParameterDirection.Output });
            cmd.Parameters.Add(new SqlParameter("@Status", SqlDbType.NVarChar, 20) { Direction = ParameterDirection.Output });
            cmd.Parameters.Add(new SqlParameter("@OpenedDate", SqlDbType.DateTime) { Direction = ParameterDirection.Output });
            cmd.Parameters.Add(new SqlParameter("@ClosedDate", SqlDbType.DateTime) { Direction = ParameterDirection.Output });
            cmd.Parameters.Add(new SqlParameter("@CreatedByUserID", SqlDbType.Int) { Direction = ParameterDirection.Output });

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();

                if (cmd.Parameters["@AccountNumber"].Value == DBNull.Value)
                    return false;

                accountNumber = cmd.Parameters["@AccountNumber"].Value.ToString();
                customerID = (int)cmd.Parameters["@CustomerID"].Value;
                accountType = cmd.Parameters["@AccountType"].Value.ToString();
                balance = (decimal)cmd.Parameters["@Balance"].Value;
                minimumBalance = (decimal)cmd.Parameters["@MinimumBalance"].Value;
                status = cmd.Parameters["@Status"].Value.ToString();
                openedDate = (DateTime)cmd.Parameters["@OpenedDate"].Value;
                closedDate = cmd.Parameters["@ClosedDate"].Value == DBNull.Value ? (DateTime?)null : (DateTime)cmd.Parameters["@ClosedDate"].Value;
                createdByUserID = (int)cmd.Parameters["@CreatedByUserID"].Value;

                return true;
            }
            catch (Exception ex)
            {
                clsDB_Util.clsLogger.Log(ex.Message);
            }
        }

        return false;
    }

    public static bool GetAccountByNumber(string accountNumber, ref int accountID, ref int customerID, ref string accountType, 
        ref decimal balance, ref decimal minimumBalance, ref string status, ref DateTime? openedDate, ref DateTime? closedDate,
        ref int createdByUserID)
    {
        using (SqlConnection conn = new SqlConnection(clsDB_Util.ConnectionString))
        using (SqlCommand cmd = new SqlCommand("sp_GetAccountByAccountNumber", conn))
        {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@AccountNumber", accountNumber);
            cmd.Parameters.Add(new SqlParameter("@AccountID", SqlDbType.Int) { Direction = ParameterDirection.Output });
            cmd.Parameters.Add(new SqlParameter("@CustomerID", SqlDbType.Int) { Direction = ParameterDirection.Output });
            cmd.Parameters.Add(new SqlParameter("@AccountType", SqlDbType.NVarChar, 20) { Direction = ParameterDirection.Output });
            cmd.Parameters.Add(new SqlParameter("@Balance", SqlDbType.Decimal) { Direction = ParameterDirection.Output });
            cmd.Parameters.Add(new SqlParameter("@MinimumBalance", SqlDbType.Decimal) { Direction = ParameterDirection.Output });
            cmd.Parameters.Add(new SqlParameter("@Status", SqlDbType.NVarChar, 20) { Direction = ParameterDirection.Output });
            cmd.Parameters.Add(new SqlParameter("@OpenedDate", SqlDbType.DateTime) { Direction = ParameterDirection.Output });
            cmd.Parameters.Add(new SqlParameter("@ClosedDate", SqlDbType.DateTime) { Direction = ParameterDirection.Output });
            cmd.Parameters.Add(new SqlParameter("@CreatedByUserID", SqlDbType.Int) { Direction = ParameterDirection.Output });

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();

                if (cmd.Parameters["@AccountID"].Value == DBNull.Value)
                    return false;

                accountID = (int)cmd.Parameters["@AccountID"].Value;
                customerID = (int)cmd.Parameters["@CustomerID"].Value;
                accountType = cmd.Parameters["@AccountType"].Value.ToString();
                balance = (decimal)cmd.Parameters["@Balance"].Value;
                minimumBalance = (decimal)cmd.Parameters["@MinimumBalance"].Value;
                status = cmd.Parameters["@Status"].Value.ToString();
                openedDate = (DateTime)cmd.Parameters["@OpenedDate"].Value;
                closedDate = cmd.Parameters["@ClosedDate"].Value == DBNull.Value ? (DateTime?)null : (DateTime)cmd.Parameters["@ClosedDate"].Value;
                createdByUserID = (int)cmd.Parameters["@CreatedByUserID"].Value;

                return true;
            }
            catch (Exception ex)
            {
                clsDB_Util.clsLogger.Log(ex.Message);
            }
        }

        return false;
    }

    public static bool FreezeAccount(int currentUserID, int accountID) => _executeStatusProcedure("sp_FreezeAccount", currentUserID, accountID);

    public static bool UnfreezeAccount(int currentUserID, int accountID) => _executeStatusProcedure("sp_UnfreezeAccount", currentUserID, accountID);

    public static bool CloseAccount(int currentUserID, int accountID) => _executeStatusProcedure("sp_CloseAccount", currentUserID, accountID);

    private static bool _executeStatusProcedure(string procedureName, int currentUserID, int accountID)
    {
        using (SqlConnection conn = new SqlConnection(clsDB_Util.ConnectionString))
        using (SqlCommand cmd = new SqlCommand(procedureName, conn))
        {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserInActionID", currentUserID);
            cmd.Parameters.AddWithValue("@AccountID", accountID);
            SqlParameter outputParam = new SqlParameter("@IsUpdated", SqlDbType.Bit)
            {
                Direction = ParameterDirection.Output
            };
            cmd.Parameters.Add(outputParam);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                return (bool)outputParam.Value;
            }
            catch (Exception ex)
            {
                clsDB_Util.clsLogger.Log(ex.Message);
            }
        }

        return false;
    }

    public static DataTable GetAllAccounts()
    {
        DataTable dt = new DataTable();
        using (SqlConnection conn = new SqlConnection(clsDB_Util.ConnectionString))
        using (SqlCommand cmd = new SqlCommand("SELECT * FROM fn_GetAllAccounts()", conn))
        {
            try
            {
                conn.Open();
                dt.Load(cmd.ExecuteReader());
            }
            catch (Exception ex)
            {
                clsDB_Util.clsLogger.Log(ex.Message);
                return null;
            }
        }

        return dt;
    }

    public static DataTable GetAccountsByCustomerID(int customerID)
    {
        DataTable dt = new DataTable();
        using (SqlConnection conn = new SqlConnection(clsDB_Util.ConnectionString))
        using (SqlCommand cmd = new SqlCommand("SELECT * FROM fn_GetAllAccounts() WHERE CustomerID = @CustomerID", conn))
        {
            cmd.Parameters.AddWithValue("@CustomerID", customerID);
            try
            {
                conn.Open();
                dt.Load(cmd.ExecuteReader());
            }
            catch (Exception ex)
            {
                clsDB_Util.clsLogger.Log(ex.Message);
                dt = null;
            }
        }

        return dt;
    }

    public static bool IsAccountExistsByID(int accountID)
    {
        using (SqlConnection conn = new SqlConnection(clsDB_Util.ConnectionString))
        using (SqlCommand cmd = new SqlCommand("SELECT dbo.IsAccountExistsByID(@AccountID)", conn))
        {
            cmd.Parameters.AddWithValue("@AccountID", accountID);
            try
            {
                conn.Open();
                return (bool)cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                clsDB_Util.clsLogger.Log(ex.Message);
            }
        }

        return false;
    }

    public static bool IsAccountExistsByNumber(string accountNumber)
    {
        using (SqlConnection conn = new SqlConnection(clsDB_Util.ConnectionString))
        using (SqlCommand cmd = new SqlCommand("SELECT dbo.IsAccountExistsByNumber(@AccountNumber)", conn))
        {
            cmd.Parameters.AddWithValue("@AccountNumber", accountNumber);
            try
            {
                conn.Open();
                return (bool)cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                clsDB_Util.clsLogger.Log(ex.Message);
            }
        }

        return false;
    }
}