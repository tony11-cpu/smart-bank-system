using SmartBack_DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using SmartBank;

namespace SmartBank_BLL
{
    public class clsFraudFlags
    {
        public enum enMode { Add, Update }
        private enMode _mode;

        public int? FlagID { get; private set; }
        public clsAccounts Account { get; set; }
        public string FlagType { get; set; }
        public DateTime FlaggedDate { get; private set; }
        public string Details { get; set; }
        public bool IsResolved { get; private set; }
        public clsUsers ResolvedByUser { get; private set; }
        public DateTime? ResolvedDate { get; private set; }

        public clsFraudFlags()
        {
            FlagID = null;
            Account = null;
            FlagType = null;
            FlaggedDate = DateTime.MinValue;
            Details = null;
            IsResolved = false;
            ResolvedByUser = null;
            ResolvedDate = null;

            _mode = enMode.Add;
        }

        public clsFraudFlags(int flagID, clsAccounts account, string flagType, DateTime flaggedDate,
                             string details, bool isResolved, clsUsers resolvedByUser, DateTime? resolvedDate)
        {
            FlagID = flagID;
            Account = account;
            FlagType = flagType;
            FlaggedDate = flaggedDate;
            Details = details;
            IsResolved = isResolved;
            ResolvedByUser = resolvedByUser;
            ResolvedDate = resolvedDate;

            _mode = enMode.Update;
        }

        public static async Task<bool> IsFraudFlagExistsAsync(int flagID) => await clsFraudFlags_DAL.IsFraudFlagExistByIDAsync(flagID);

        public static async Task<clsFraudFlags> FindAsync(int flagID)
        {
            clsFraudFlagDto dto = await clsFraudFlags_DAL.GetFraudFlagByIDAsync(flagID);
            if (dto == null)
                return null;

            clsAccounts account = await clsAccounts.FindAsync(dto.AccountID);
            clsUsers resolvedByUser = null;

            if (dto.ResolvedByUserID.HasValue)
                resolvedByUser = await clsUsers.FindAsync(dto.ResolvedByUserID.Value);

            return new clsFraudFlags(dto.FlagID, account, dto.FlagType, dto.FlaggedDate, dto.Details,
                                     dto.IsResolved, resolvedByUser, dto.ResolvedDate);
        }

        public static async Task<List<clsFraudFlags>> GetAllFraudFlagsAsync()
        {
            DataTable dt = await clsFraudFlags_DAL.GetAllFraudFlagsAsync();
            if (dt == null || dt.Rows.Count == 0)
                return new List<clsFraudFlags>();

            List<clsFraudFlags> fraudFlags = new List<clsFraudFlags>();

            foreach (DataRow row in dt.Rows)
            {
                clsAccounts account = await clsAccounts.FindAsync((int)row["AccountID"]);
                clsUsers resolvedByUser = null;
                if (row["ResolvedByUserID"] != DBNull.Value)
                    resolvedByUser = await clsUsers.FindAsync((int)row["ResolvedByUserID"]);

                fraudFlags.Add(new clsFraudFlags(
                    (int)row["FlagID"],
                    account,
                    row["FlagType"].ToString(),
                    (DateTime)row["FlaggedDate"],
                    row["Details"].ToString(),
                    (bool)row["IsResolved"],
                    resolvedByUser,
                    row["ResolvedDate"] == DBNull.Value ? (DateTime?)null : (DateTime)row["ResolvedDate"]
                ));
            }

            return fraudFlags;
        }

        public static async Task<List<clsFraudFlags>> GetUnresolvedFraudFlagsAsync()
        {
            DataTable dt = await clsFraudFlags_DAL.GetUnresolvedFraudFlagsAsync();
            if (dt == null || dt.Rows.Count == 0)
                return new List<clsFraudFlags>();

            List<clsFraudFlags> fraudFlags = new List<clsFraudFlags>();

            foreach (DataRow row in dt.Rows)
            {
                clsAccounts account = await clsAccounts.FindAsync((int)row["AccountID"]);
                clsUsers resolvedByUser = null;
                if (row["ResolvedByUserID"] != DBNull.Value)
                    resolvedByUser = await clsUsers.FindAsync((int)row["ResolvedByUserID"]);

                fraudFlags.Add(new clsFraudFlags(
                    (int)row["FlagID"],
                    account,
                    row["FlagType"].ToString(),
                    (DateTime)row["FlaggedDate"],
                    row["Details"].ToString(),
                    (bool)row["IsResolved"],
                    resolvedByUser,
                    row["ResolvedDate"] == DBNull.Value ? (DateTime?)null : (DateTime)row["ResolvedDate"]
                ));
            }

            return fraudFlags;
        }

        public static async Task<List<clsFraudFlags>> GetFraudFlagsByAccountIDAsync(int accountID)
        {
            DataTable dt = await clsFraudFlags_DAL.GetFraudFlagsByAccountIDAsync(accountID);
            if (dt == null || dt.Rows.Count == 0)
                return new List<clsFraudFlags>();

            List<clsFraudFlags> fraudFlags = new List<clsFraudFlags>();
            clsAccounts account = await clsAccounts.FindAsync(accountID);

            foreach (DataRow row in dt.Rows)
            {
                clsUsers resolvedByUser = null;
                if (row["ResolvedByUserID"] != DBNull.Value)
                    resolvedByUser = await clsUsers.FindAsync((int)row["ResolvedByUserID"]);

                fraudFlags.Add(new clsFraudFlags(
                    (int)row["FlagID"],
                    account,
                    row["FlagType"].ToString(),
                    (DateTime)row["FlaggedDate"],
                    row["Details"].ToString(),
                    (bool)row["IsResolved"],
                    resolvedByUser,
                    row["ResolvedDate"] == DBNull.Value ? (DateTime?)null : (DateTime)row["ResolvedDate"]
                ));
            }

            return fraudFlags;
        }

        private async Task<bool> _addNewAsync()
        {
            int userID = clsGlobal.ActiveUser?.UserID ?? throw new Exception("No User Responsible!");
            int accountID = Account?.AccountID ?? throw new Exception("Account Is Not Set!");

            int newFlagID = await clsFraudFlags_DAL.CreateFraudFlagAsync(userID, accountID,
                                                                          FlagType, string.IsNullOrWhiteSpace(Details) ? "No Details" : Details);

            if (newFlagID == -1)
                return false;

            FlagID = newFlagID;
            FlaggedDate = DateTime.Now;
            IsResolved = false;
            _mode = enMode.Update;
            return true;
        }

        public async Task<bool> SaveAsync()
        {
            switch (_mode)
            {
                case enMode.Add: return await _addNewAsync();
                case enMode.Update: return true;

                default:
                    throw new InvalidOperationException("Invalid mode for saving fraud flag.");
            }
        }

        public async Task<bool> ResolveAsync()
        {
            if (_mode != enMode.Update || IsResolved)
                return false;

            if (!FlagID.HasValue)
                throw new Exception("Flag ID Is Not Set!");

            int userID = clsGlobal.ActiveUser?.UserID ?? throw new Exception("No User Responsible!");

            if (await clsFraudFlags_DAL.ResolveFraudFlagAsync(userID, FlagID.Value))
            {
                IsResolved = true;
                ResolvedDate = DateTime.Now;
                ResolvedByUser = clsGlobal.ActiveUser;
                return true;
            }

            return false;
        }
    }
}
