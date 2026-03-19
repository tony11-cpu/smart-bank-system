using SmartBack_DAL;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace SmartBank
{
    public static class clsCustomers_DAL
    {
        public static bool IsCustomerExistByID(int customerID)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(clsDB_Util.ConnectionString))
                using (SqlCommand cmd = new SqlCommand("SELECT dbo.IsCustomerExistsByID(@CustomerID)", conn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@CustomerID", customerID);
                    conn.Open();

                    return Convert.ToBoolean(cmd.ExecuteScalar());
                }
            }
            catch (SqlException ex)
            {
                clsDB_Util.clsLogger.Log(ex.Message, EventLogEntryType.Error);
            }

            return false;
        }

        public static bool IsCustomerExistByNationalID(string nationalID)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(clsDB_Util.ConnectionString))
                using (SqlCommand cmd = new SqlCommand("SELECT dbo.IsCustomerExistsByNationalID(@NationalID)", conn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@NationalID", nationalID);
                    conn.Open();

                    return Convert.ToBoolean(cmd.ExecuteScalar());
                }
            }
            catch (SqlException ex)
            {
                clsDB_Util.clsLogger.Log(ex.Message, EventLogEntryType.Error);
            }

            return false;
        }

        public static bool GetCustomerByID(int customerID, ref string firstName, ref string lastName, ref string nationalID,
                                       ref DateTime dateOfBirth, ref string phone, ref string email,
                                       ref string address, ref DateTime registeredDate,
                                       ref bool isActive, ref int createdByUserID , ref string imagePath , ref bool Gender)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(clsDB_Util.ConnectionString))
                using (SqlCommand cmd = new SqlCommand("sp_GetCustomerByID", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@CustomerID", customerID);

                    SqlParameter pFirstName = new SqlParameter("@FirstName", SqlDbType.NVarChar, 100) { Direction = ParameterDirection.Output };
                    SqlParameter pLastName = new SqlParameter("@LastName", SqlDbType.NVarChar, 100) { Direction = ParameterDirection.Output };
                    SqlParameter pNationalID = new SqlParameter("@NationalID", SqlDbType.NVarChar, 100) { Direction = ParameterDirection.Output };
                    SqlParameter pDateOfBirth = new SqlParameter("@DateOfBirth", SqlDbType.Date) { Direction = ParameterDirection.Output };
                    SqlParameter pPhone = new SqlParameter("@Phone", SqlDbType.NVarChar, 20) { Direction = ParameterDirection.Output };
                    SqlParameter pEmail = new SqlParameter("@Email", SqlDbType.NVarChar, 250) { Direction = ParameterDirection.Output };
                    SqlParameter pAddress = new SqlParameter("@Address", SqlDbType.NVarChar, 250) { Direction = ParameterDirection.Output };
                    SqlParameter pRegisteredDate = new SqlParameter("@RegisteredDate", SqlDbType.DateTime) { Direction = ParameterDirection.Output };
                    SqlParameter pIsActive = new SqlParameter("@IsActive", SqlDbType.Bit) { Direction = ParameterDirection.Output };
                    SqlParameter pCreatedByUserID = new SqlParameter("@CreatedByUserID", SqlDbType.Int) { Direction = ParameterDirection.Output };
                    SqlParameter pImagePath = new SqlParameter("@ImagePath", SqlDbType.NVarChar, 250) { Direction = ParameterDirection.Output };
                    SqlParameter pGender = new SqlParameter("@Gender", SqlDbType.Bit) { Direction = ParameterDirection.Output };

                    cmd.Parameters.Add(pFirstName);
                    cmd.Parameters.Add(pLastName);
                    cmd.Parameters.Add(pNationalID);
                    cmd.Parameters.Add(pDateOfBirth);
                    cmd.Parameters.Add(pPhone);
                    cmd.Parameters.Add(pEmail);
                    cmd.Parameters.Add(pAddress);
                    cmd.Parameters.Add(pRegisteredDate);
                    cmd.Parameters.Add(pIsActive);
                    cmd.Parameters.Add(pCreatedByUserID);
                    cmd.Parameters.Add(pImagePath);
                    cmd.Parameters.Add(pGender);

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    if (pFirstName.Value == DBNull.Value) 
                        return false;

                    firstName = (string)pFirstName.Value;
                    lastName = (string)pLastName.Value;
                    nationalID = (string)pNationalID.Value;
                    dateOfBirth = (DateTime)pDateOfBirth.Value;
                    phone = (string)pPhone.Value;
                    email = pEmail.Value == DBNull.Value ? null : (string)pEmail.Value;
                    address = (string)pAddress.Value;
                    registeredDate = (DateTime)pRegisteredDate.Value;
                    isActive = (bool)pIsActive.Value;
                    createdByUserID = (int)pCreatedByUserID.Value;
                    imagePath = pImagePath.Value == DBNull.Value ? null : (string)pImagePath.Value;
                    Gender = (bool)pGender.Value;

                    return true;
                }
            }
            catch (SqlException ex)
            {
                clsDB_Util.clsLogger.Log(ex.Message, EventLogEntryType.Error);
            }

            return false;
        }

        public static int CreateCustomer(int userInActionID, string firstName, string lastName, string nationalID,
                                         DateTime dateOfBirth, string phone, string email, string address , string imagePath , bool Gender)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(clsDB_Util.ConnectionString))
                using (SqlCommand cmd = new SqlCommand("sp_CreateCustomer", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@UserInActionID", userInActionID);
                    cmd.Parameters.AddWithValue("@FirstName", firstName);
                    cmd.Parameters.AddWithValue("@LastName", lastName);
                    cmd.Parameters.AddWithValue("@NationalID", nationalID);
                    cmd.Parameters.AddWithValue("@DateOfBirth", dateOfBirth);
                    cmd.Parameters.AddWithValue("@Phone", phone);
                    cmd.Parameters.AddWithValue("@Email", string.IsNullOrEmpty(email) ? (object)DBNull.Value : email);
                    cmd.Parameters.AddWithValue("@Address", address);
                    cmd.Parameters.AddWithValue("@ImagePath", string.IsNullOrEmpty(imagePath) ? (object)DBNull.Value : imagePath);
                    cmd.Parameters.AddWithValue("@Gender", Gender);

                    SqlParameter newCustomerID = new SqlParameter("@NewCustomerID", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(newCustomerID);

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    return (int)newCustomerID.Value;
                }
            }
            catch (SqlException ex)
            {
                clsDB_Util.clsLogger.Log(ex.Message, EventLogEntryType.Error);
            }

            return -1;
        }

        public static bool UpdateCustomer(int adminUserID, int customerID,
                                          string firstName, string lastName, string phone,
                                          string email, string address, string imagePath , bool gender)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(clsDB_Util.ConnectionString))
                using (SqlCommand cmd = new SqlCommand("sp_UpdateCustomer", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@AdminUserID", adminUserID);
                    cmd.Parameters.AddWithValue("@CustomerID", customerID);
                    cmd.Parameters.AddWithValue("@FirstName", firstName);
                    cmd.Parameters.AddWithValue("@LastName", lastName);
                    cmd.Parameters.AddWithValue("@Phone", phone);
                    cmd.Parameters.AddWithValue("@Email", string.IsNullOrEmpty(email) ? (object)DBNull.Value : email);
                    cmd.Parameters.AddWithValue("@Address", address);
                    cmd.Parameters.AddWithValue("@ImagePath", string.IsNullOrEmpty(imagePath) ? (object)DBNull.Value : imagePath);
                    cmd.Parameters.AddWithValue("@Gender" , gender);

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    return true;
                }
            }
            catch (SqlException ex)
            {
                clsDB_Util.clsLogger.Log(ex.Message, EventLogEntryType.Error);
            }

            return false;
        }

        public static bool DeactivateCustomer(int customerID, int adminUserID)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(clsDB_Util.ConnectionString))
                using (SqlCommand cmd = new SqlCommand("sp_DeactivateCustomer", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@CustomerID", customerID);
                    cmd.Parameters.AddWithValue("@AdminUserID", adminUserID);

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    return true;
                }
            }
            catch (SqlException ex)
            {
                clsDB_Util.clsLogger.Log(ex.Message, EventLogEntryType.Error);
            }

            return false;
        }
    }
}