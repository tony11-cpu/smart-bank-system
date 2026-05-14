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
        public clsAccounts Account { get; private set; }
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
    }
}
