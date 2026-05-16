using SmartBank;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBank_BLL
{
    public class clsCustomers
    {
        public enum enMode { Add, Update }
        private enMode _mode;

        public int? CustomerID { get; private set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalID { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime RegisteredDate { get; private set; }
        public bool IsActive { get; private set; }
        public int CreatedByUserID { get; private set; }
        public string @ImagePath { get; set; }

        /// <summary>
        /// False = Male , True = Female
        /// </summary>
        public bool Gender { get; set; }

        public clsCustomers()
        {
            CustomerID = null;
            FirstName = null; 
            LastName = null;
            NationalID = null;
            DateOfBirth = DateTime.MinValue;
            Phone = null;
            Email = null;
            Address = null;
            RegisteredDate = DateTime.MinValue;
            IsActive = false;
            CreatedByUserID = -1;
            ImagePath = null;

            _mode = enMode.Add;
        }

        public clsCustomers(int customerID, string firstName, string lastName,
                            string nationalID, DateTime dateOfBirth,
                            string phone, string email, string address,
                            DateTime registeredDate, bool isActive, int createdByUserID , bool Gender , string ImagePath)
        {
            this.CustomerID = customerID;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.NationalID = nationalID;
            this.DateOfBirth = dateOfBirth;
            this.Phone = phone;
            this.Email = email;
            this.Address = address;
            this.RegisteredDate = registeredDate;
            this.IsActive = isActive;
            this.CreatedByUserID = createdByUserID;
            this.Gender = Gender;
            this.ImagePath = ImagePath;

            _mode = enMode.Update;
        }

        public static async Task<bool> IsCustomerExistsAsync(int customerID) => await clsCustomers_DAL.IsCustomerExistByIDAsync(customerID);

        public static async Task<bool> IsCustomerExistsAsync(string nationalID) => await clsCustomers_DAL.IsCustomerExistByNationalIDAsync(nationalID);

        public static async Task<List<clsCustomers>> GetAllCustomersAsync()
        {
            List<clsCustomers> customers = new List<clsCustomers>();
            DataTable values = await clsCustomers_DAL.GetAllCustomersAsync();

            foreach (DataRow row in values.Rows)
            {
                string[] fullNameParts = (row["Full Name"]?.ToString() ?? string.Empty).Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string firstName = fullNameParts.Length > 0 ? fullNameParts[0] : string.Empty;
                string lastName = fullNameParts.Length > 1 ? string.Join(" ", fullNameParts.Skip(1)) : string.Empty;

                customers.Add(new clsCustomers(
                    (int)row["Customer ID"],
                    firstName,
                    lastName,
                    row["National ID"].ToString(),
                    Convert.ToDateTime(row["Date Of Birth"]),
                    row["Phone"].ToString(),
                    row["Email"].ToString() == "No Email" ? null : row["Email"].ToString(),
                    row["Address"].ToString(),
                    Convert.ToDateTime(row["Join Date"]),
                    (bool)row["Is Active"],
                    (int)row["Created By User ID"],
                    row["Gender"].ToString() == "Female",
                    row["Image Path"] == DBNull.Value ? null : row["Image Path"].ToString()
                ));
            } 
            
            return customers;
        }

        public static async Task<clsCustomers> FindAsync(int customerID)
        {
            clsCustomerDto customerDto = await clsCustomers_DAL.GetCustomerByIDAsync(customerID);
            if (customerDto != null)
            {
                return new clsCustomers(customerID, customerDto.FirstName, customerDto.LastName,customerDto.NationalID, customerDto.DateOfBirth, customerDto.Phone, customerDto.Email,
                    customerDto.Address, customerDto.RegisteredDate, customerDto.IsActive, customerDto.CreatedByUserID, customerDto.Gender, customerDto.ImagePath);
            }

            return null;
        }

        public static async Task<clsCustomers> FindAsync(string nationalID)
        {
            clsCustomerDto customerDto = await clsCustomers_DAL.GetCustomerByNationalIDAsync(nationalID);
            if (customerDto != null)
            {
                return new clsCustomers(customerDto.CustomerID, customerDto.FirstName, customerDto.LastName, nationalID, customerDto.DateOfBirth, customerDto.Phone, customerDto.Email,
                    customerDto.Address, customerDto.RegisteredDate, customerDto.IsActive, customerDto.CreatedByUserID, customerDto.Gender, customerDto.ImagePath);
            }

            return null;
        }

        private async Task<bool> _addNewAsync()
        {
            this.CustomerID = await clsCustomers_DAL.CreateCustomerAsync(clsGlobal.ActiveUser.UserID ?? throw new InvalidOperationException("Active user is not set."),
                                                                         new clsCustomerDto(FirstName,LastName,NationalID,DateOfBirth,Phone,Email,Address,DateTime.Now,true,
                                                                         ImagePath,Gender));
            if(CustomerID == -1)
                return false;

            _mode = enMode.Update;
            return true;
        }

        private async Task<bool> _updateAsync() => await clsCustomers_DAL.UpdateCustomerAsync(clsGlobal.ActiveUser.UserID ?? throw new InvalidOperationException("Active user is not set."),
                                                                                         CustomerID ?? throw new InvalidOperationException("Customer ID is not set."),
                                                                                         FirstName, LastName,Phone, Email, Address, ImagePath, Gender , DateOfBirth);

        public async Task<bool> SaveAsync()
        {
            switch (_mode)
            {
                case enMode.Add:  return await _addNewAsync();
                case enMode.Update: return await _updateAsync();

                default:
                    throw new InvalidOperationException("Invalid mode for saving customer.");
            }
        }

        public async Task<bool> DeactivateAsync()
        {
            if (_mode != enMode.Update || !IsActive)
                return false;

            if(CustomerID != null && clsGlobal.ActiveUser != null && clsGlobal.ActiveUser.UserID != null 
                && await clsCustomers_DAL.DeactivateCustomerAsync(CustomerID.Value, clsGlobal.ActiveUser.UserID.Value))
            {
                IsActive = false;
                return true;
            }
               
            return false;
        }

        public async Task<bool> ActivateAsync()
        {
            if (_mode != enMode.Update || IsActive)
                return false;

            if (CustomerID != null && clsGlobal.ActiveUser != null && clsGlobal.ActiveUser.UserID != null 
                && await clsCustomers_DAL.ActivateCustomerAsync(CustomerID.Value, clsGlobal.ActiveUser.UserID.Value))
            {
                IsActive = true;  
                return true;
            }

            return false;
        }
    }
}
