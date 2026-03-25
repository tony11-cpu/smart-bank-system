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

        public static bool IsCustomerExists(int customerID) => clsCustomers_DAL.IsCustomerExistByID(customerID);

        public static bool IsCustomerExists(string nationalID) => clsCustomers_DAL.IsCustomerExistByNationalID(nationalID);

        public static List<clsCustomers> GetAllCustomers()
        {
            List<clsCustomers> customers = new List<clsCustomers>();
            DataTable values = clsCustomers_DAL.GetAllCustomers();
            foreach (DataRow row in values.Rows)
            {
                customers.Add(new clsCustomers(
                    (int)row["Customer ID"],
                    row["Full Name"].ToString().Split(' ')[0],
                    row["Full Name"].ToString().Split(' ')[1],
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
            } return customers;
        }

        public static clsCustomers Find(int customerID)
        {
            string firstName = null;
            string lastName = null;
            string nationalID = null;
            DateTime dateOfBirth = DateTime.MinValue;
            string phone = null;
            string email = null;
            string address = null;
            DateTime registeredDate = DateTime.MinValue;
            bool isActive = false;
            int createdByUserID = -1;
            string ImagePath = null;
            bool Gender = false;

            if (clsCustomers_DAL.GetCustomerByID(customerID,
                ref firstName, ref lastName, ref nationalID,
                ref dateOfBirth, ref phone, ref email,
                ref address, ref registeredDate,
                ref isActive, ref createdByUserID , ref ImagePath, ref Gender))
            {
                return new clsCustomers(customerID, firstName, lastName,
                    nationalID, dateOfBirth, phone, email,
                    address, registeredDate, isActive, createdByUserID, Gender, ImagePath);
            }

            return null;
        }

        public static clsCustomers Find(string nationalID)
        {
            int customerID = -1;
            string firstName = null;
            string lastName = null;
            DateTime dateOfBirth = DateTime.MinValue;
            string phone = null;
            string email = null;
            string address = null;
            DateTime registeredDate = DateTime.MinValue;
            bool isActive = false;
            int createdByUserID = -1;
            string ImagePath = null;
            bool Gender = false;

            if (clsCustomers_DAL.GetCustomerByNationalID(nationalID,
                ref customerID, ref firstName, ref lastName,
                ref dateOfBirth, ref phone, ref email,
                ref address, ref registeredDate,
                ref isActive, ref createdByUserID, ref ImagePath, ref Gender))
            {
                return new clsCustomers(customerID, firstName, lastName,
                    nationalID, dateOfBirth, phone, email,
                    address, registeredDate, isActive, createdByUserID, Gender, ImagePath);
            }

            return null;
        }

        private bool _addNew()
        {
            this.CustomerID = clsCustomers_DAL.CreateCustomer(clsGlobal.ActiveUser.UserID ?? throw new InvalidOperationException("Active user is not set."), 
                                                              FirstName,LastName, NationalID,DateOfBirth, Phone, Email, Address, DateTime.Now ,true ,
                                                              ImagePath, Gender);
            return CustomerID != -1;
        }

        private bool _update() => clsCustomers_DAL.UpdateCustomer(clsGlobal.ActiveUser.UserID ?? throw new InvalidOperationException("Active user is not set."),
                                                                  CustomerID ?? throw new InvalidOperationException("Customer ID is not set."),
                                                                  FirstName, LastName,Phone, Email, Address, ImagePath, Gender , DateOfBirth);

        public bool Save()
        {
            switch (_mode)
            {
                case enMode.Add:
                    if (_addNew())
                    {
                        _mode = enMode.Update;
                        return true;
                    }
                    return false;
                case enMode.Update: return _update();
                default:
                    throw new InvalidOperationException("Invalid mode for saving customer.");
            }
        }

        public bool Deactivate()
        {
            if (_mode != enMode.Update || !IsActive)
                return false;

            if(CustomerID != null && (clsGlobal.ActiveUser != null || clsGlobal.ActiveUser.UserID != null) &&
                clsCustomers_DAL.DeactivateCustomer(CustomerID.Value, clsGlobal.ActiveUser.UserID.Value))
            {
                IsActive = false;
                return true;
            }
               
            return false;
        }

        public bool Activate()
        {
            if (_mode != enMode.Update || IsActive)
                return false;

            if (CustomerID != null && (clsGlobal.ActiveUser != null || clsGlobal.ActiveUser.UserID != null) &&
                clsCustomers_DAL.ActivateCustomer(CustomerID.Value, clsGlobal.ActiveUser.UserID.Value))
            {
                IsActive = false;
                return true;
            }

            return false;
        }
    }
}
