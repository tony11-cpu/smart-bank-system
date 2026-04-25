using SmartBack_DAL;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Net;
using System.Security.Policy;
using System.Threading.Tasks;

namespace SmartBank
{
    public class clsCustomerDto
    {
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalID { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime RegisteredDate { get; set; }
        public bool IsActive { get; set; }
        public int CreatedByUserID { get; set; }
        public string ImagePath { get; set; }
        public bool Gender { get; set; }

        public clsCustomerDto(int customerID, string firstName, string lastName, string nationalID,
                              DateTime dateOfBirth, string phone, string email, string address,
                              DateTime registeredDate, bool isActive, int createdByUserID,
                              string imagePath, bool gender)
        {
            CustomerID = customerID;
            FirstName = firstName;
            LastName = lastName;
            NationalID = nationalID;
            DateOfBirth = dateOfBirth;
            Phone = phone;
            Email = email;
            Address = address;
            RegisteredDate = registeredDate;
            IsActive = isActive;
            CreatedByUserID = createdByUserID;
            ImagePath = imagePath;
            Gender = gender;
        }

        public clsCustomerDto(string firstName, string lastName, string nationalID,
                              DateTime dateOfBirth, string phone, string email, string address,
                              DateTime registeredDate, bool isActive,
                              string imagePath, bool gender)
        {
            FirstName = firstName;
            LastName = lastName;
            NationalID = nationalID;
            DateOfBirth = dateOfBirth;
            Phone = phone;
            Email = email;
            Address = address;
            RegisteredDate = registeredDate;
            IsActive = isActive;
            ImagePath = imagePath;
            Gender = gender;
        }
    }

    public static class clsCustomers_DAL
    {
        public static async Task<bool> IsCustomerExistByIDAsync(int customerID)
        {
            using (SqlConnection conn = new SqlConnection(clsDB_Util.ConnectionString))
            using (SqlCommand cmd = new SqlCommand("SELECT dbo.IsCustomerExistsByID(@CustomerID)", conn))
            {
                cmd.Parameters.AddWithValue("@CustomerID", customerID);

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

        public static async Task<bool> IsCustomerExistByNationalIDAsync(string nationalID)
        {
            using (SqlConnection conn = new SqlConnection(clsDB_Util.ConnectionString))
            using (SqlCommand cmd = new SqlCommand("SELECT dbo.IsCustomerExistsByNationalID(@NationalID)", conn))
            {
                cmd.Parameters.AddWithValue("@NationalID", nationalID);

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

        public static async Task<clsCustomerDto> GetCustomerByIDAsync(int customerID)
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

                try
                {
                    await conn.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                    if (pFirstName.Value == DBNull.Value)
                        return null;

                    return new clsCustomerDto(customerID, (string)pFirstName.Value, (string)pLastName.Value,
                        (string)pNationalID.Value, (DateTime)pDateOfBirth.Value, (string)pPhone.Value,
                        pEmail.Value == DBNull.Value ? null : (string)pEmail.Value, (string)pAddress.Value,
                        (DateTime)pRegisteredDate.Value, (bool)pIsActive.Value, (int)pCreatedByUserID.Value,
                        pImagePath.Value == DBNull.Value ? null : (string)pImagePath.Value, (bool)pGender.Value);
                }
                catch (SqlException ex)
                {
                    clsDB_Util.clsLogger.Log(ex.Message, EventLogEntryType.Error);
                }
            }

            return null;
        }

        public static async Task<clsCustomerDto> GetCustomerByNationalIDAsync(string nationalID)
        {
            using (SqlConnection conn = new SqlConnection(clsDB_Util.ConnectionString))
            using (SqlCommand cmd = new SqlCommand("sp_GetCustomerByNationalID", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter pFirstName = new SqlParameter("@FirstName", SqlDbType.NVarChar, 100) { Direction = ParameterDirection.Output };
                SqlParameter pLastName = new SqlParameter("@LastName", SqlDbType.NVarChar, 100) { Direction = ParameterDirection.Output };
                SqlParameter pCustomerID = new SqlParameter("@CustomerID", SqlDbType.Int) { Direction = ParameterDirection.Output };
                SqlParameter pDateOfBirth = new SqlParameter("@DateOfBirth", SqlDbType.Date) { Direction = ParameterDirection.Output };
                SqlParameter pPhone = new SqlParameter("@Phone", SqlDbType.NVarChar, 20) { Direction = ParameterDirection.Output };
                SqlParameter pEmail = new SqlParameter("@Email", SqlDbType.NVarChar, 250) { Direction = ParameterDirection.Output };
                SqlParameter pAddress = new SqlParameter("@Address", SqlDbType.NVarChar, 250) { Direction = ParameterDirection.Output };
                SqlParameter pRegisteredDate = new SqlParameter("@RegisteredDate", SqlDbType.DateTime) { Direction = ParameterDirection.Output };
                SqlParameter pIsActive = new SqlParameter("@IsActive", SqlDbType.Bit) { Direction = ParameterDirection.Output };
                SqlParameter pCreatedByUserID = new SqlParameter("@CreatedByUserID", SqlDbType.Int) { Direction = ParameterDirection.Output };
                SqlParameter pImagePath = new SqlParameter("@ImagePath", SqlDbType.NVarChar, 300) { Direction = ParameterDirection.Output };
                SqlParameter pGender = new SqlParameter("@Gender", SqlDbType.Bit) { Direction = ParameterDirection.Output };

                cmd.Parameters.AddWithValue("@nationalID", nationalID);
                cmd.Parameters.Add(pFirstName);
                cmd.Parameters.Add(pLastName);
                cmd.Parameters.Add(pCustomerID);
                cmd.Parameters.Add(pDateOfBirth);
                cmd.Parameters.Add(pPhone);
                cmd.Parameters.Add(pEmail);
                cmd.Parameters.Add(pAddress);
                cmd.Parameters.Add(pRegisteredDate);
                cmd.Parameters.Add(pIsActive);
                cmd.Parameters.Add(pCreatedByUserID);
                cmd.Parameters.Add(pImagePath);
                cmd.Parameters.Add(pGender);

                try
                {
                    await conn.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                    if (pFirstName.Value == DBNull.Value)
                        return null;

                    return new clsCustomerDto((int)pCustomerID.Value, (string)pFirstName.Value,
                        (string)pLastName.Value, nationalID, (DateTime)pDateOfBirth.Value,
                        (string)pPhone.Value, pEmail.Value == DBNull.Value ? null : (string)pEmail.Value,
                        (string)pAddress.Value, (DateTime)pRegisteredDate.Value, (bool)pIsActive.Value,
                        (int)pCreatedByUserID.Value, pImagePath.Value == DBNull.Value ? null : (string)pImagePath.Value, (bool)pGender.Value);
                }
                catch (SqlException ex)
                {
                    clsDB_Util.clsLogger.Log(ex.Message, EventLogEntryType.Error);
                }
            }

            return null;
        }

        public static async Task<int> CreateCustomerAsync(int userInActionID, clsCustomerDto customerToCreate)
        {
            using (SqlConnection conn = new SqlConnection(clsDB_Util.ConnectionString))
            using (SqlCommand cmd = new SqlCommand("sp_CreateCustomer", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@UserInActionID", userInActionID);
                cmd.Parameters.AddWithValue("@FirstName", customerToCreate.FirstName);
                cmd.Parameters.AddWithValue("@LastName", customerToCreate.LastName);
                cmd.Parameters.AddWithValue("@NationalID", customerToCreate.NationalID);
                cmd.Parameters.AddWithValue("@DateOfBirth", customerToCreate.DateOfBirth);
                cmd.Parameters.AddWithValue("@Phone", customerToCreate.Phone);
                cmd.Parameters.AddWithValue("@Email", string.IsNullOrEmpty(customerToCreate.Email) ? (object)DBNull.Value : customerToCreate.Email);
                cmd.Parameters.AddWithValue("@Address", customerToCreate.Address);
                cmd.Parameters.AddWithValue("@Gender", customerToCreate.Gender);
                cmd.Parameters.AddWithValue("@IsActive", customerToCreate.IsActive);
                cmd.Parameters.AddWithValue("@RegisteredDate", customerToCreate.RegisteredDate);
                SqlParameter ImagePath = new SqlParameter("@ImagePath", SqlDbType.NVarChar, 300)
                {
                    Direction = ParameterDirection.Input,
                    Value = string.IsNullOrEmpty(customerToCreate.ImagePath) ? (object)DBNull.Value : customerToCreate.ImagePath
                };
                SqlParameter newCustomerID = new SqlParameter("@NewCustomerID", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };

                cmd.Parameters.Add(ImagePath);
                cmd.Parameters.Add(newCustomerID);

                try
                {
                    await conn.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                    return (int)newCustomerID.Value;
                }
                catch (SqlException ex)
                {
                    clsDB_Util.clsLogger.Log(ex.Message, EventLogEntryType.Error);
                }
            }

            return -1;
        }

        public static async Task<bool> UpdateCustomerAsync(int adminUserID, int cusomerID ,string firstName, string lastName, string phone,
                                                           string email, string address, string imagePath, bool gender , DateTime dateOfBirth)
        {
            using (SqlConnection conn = new SqlConnection(clsDB_Util.ConnectionString))
            using (SqlCommand cmd = new SqlCommand("sp_UpdateCustomer", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@AdminUserID", adminUserID);
                cmd.Parameters.AddWithValue("@CustomerID", cusomerID);
                cmd.Parameters.AddWithValue("@FirstName", firstName);
                cmd.Parameters.AddWithValue("@LastName", lastName);
                cmd.Parameters.AddWithValue("@Phone", phone);
                cmd.Parameters.AddWithValue("@Email", string.IsNullOrEmpty(email) ? (object)DBNull.Value : email);
                cmd.Parameters.AddWithValue("@Address", address);
                cmd.Parameters.AddWithValue("@ImagePath", string.IsNullOrEmpty(imagePath) ? (object)DBNull.Value : imagePath);
                cmd.Parameters.AddWithValue("@Gender", gender);
                cmd.Parameters.AddWithValue("@DateOfBirth", dateOfBirth);      

                try
                {
                    await conn.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                    return true;
                }
                catch (SqlException ex)
                {
                    clsDB_Util.clsLogger.Log(ex.Message, EventLogEntryType.Error);
                }
            }

            return false;
        }

        public static async Task<bool> DeactivateCustomerAsync(int customerID, int adminUserID) => await _executeStatusProcedureAsync("sp_DeactivateCustomer", customerID, adminUserID);

        public static async Task<bool> ActivateCustomerAsync(int customerID, int adminUserID) => await _executeStatusProcedureAsync("sp_ActivateCustomer", customerID, adminUserID);

        private static async Task<bool> _executeStatusProcedureAsync(string procedureName, int customerID, int adminUserID)
        {
            using (SqlConnection conn = new SqlConnection(clsDB_Util.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(procedureName, conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CustomerID", customerID);
                cmd.Parameters.AddWithValue("@AdminUserID", adminUserID);

                try
                {
                    await conn.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return true;
                }
                catch (SqlException ex)
                {
                    clsDB_Util.clsLogger.Log(ex.Message, EventLogEntryType.Error);
                }
            }

            return false;
        }

        public static async Task<DataTable> GetAllCustomersAsync()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(clsDB_Util.ConnectionString))
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM fn_GetAllCustomers();", conn))
            {
                try
                {
                    await conn.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                        dt.Load(reader);
                    return dt;
                }
                catch (SqlException ex)
                {
                    clsDB_Util.clsLogger.Log(ex.Message, EventLogEntryType.Error);
                }
            }

            return dt;
        }
    }
}