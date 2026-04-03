using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBank
{
    public class clsPermissions
    {
        public static readonly int TellerPermissions = (int)(enPermission.CanDeposit | enPermission.CanWithdraw | enPermission.CanTransfer |
                                                   enPermission.CanScheduleTransfer | enPermission.CanOpenAccount | enPermission.CanViewStatement);

        public static readonly int ManagerPermissions = TellerPermissions | (int)(enPermission.CanFreezeAccount | enPermission.CanCloseAccount |
                                                                          enPermission.CanViewFraudFlags | enPermission.CanResolveFraudFlags |
                                                                          enPermission.CanViewAuditLog | enPermission.CanExportAuditLog |
                                                                          enPermission.CanViewCustomerNationalId | enPermission.CanActivateOrDeactivateCustomer);

        public static readonly int AdminPermissions = ManagerPermissions | (int)(enPermission.CanManageUsers | enPermission.CanUnlockUsers |
                                                                         enPermission.CanChangePermissions | enPermission.CanEditSystemConfig);

        public clsPermissions(int permissions)
        {
            this._permissions = permissions;
            this.PermissionPresenter = _loadPermissionPresenter();
        }

        public clsPermissions(enPermissionPresenter presenter)
        {
            switch (presenter)
            {
                case enPermissionPresenter.Teller:
                    _permissions = TellerPermissions;
                    break;
                case enPermissionPresenter.Manager:
                    _permissions = ManagerPermissions;
                    break;
                case enPermissionPresenter.Admin:
                    _permissions = AdminPermissions;
                    break;
            }

            this.PermissionPresenter = presenter;
            this.PermissionPresenterString = presenter.ToString();
        }

        private enPermissionPresenter _loadPermissionPresenter()
        {
            if (_permissions == AdminPermissions)
            {
                PermissionPresenterString = "Admin";
                return enPermissionPresenter.Admin;
            }
            else if (_permissions == ManagerPermissions)
            {
                PermissionPresenterString = "Manager";
                return enPermissionPresenter.Manager;
            }
            else if (_permissions == TellerPermissions)
            {
                PermissionPresenterString = "Teller";
                return enPermissionPresenter.Teller;
            }

            PermissionPresenterString = "Custom";
            return enPermissionPresenter.Custom;
        }

        public enum enPermissionPresenter { Admin, Manager, Teller, Custom }
        public enum enPermission
        {
            CanDeposit = 1,
            CanWithdraw = 2,
            CanTransfer = 4,
            CanScheduleTransfer = 8,
            CanOpenAccount = 16,
            CanFreezeAccount = 32,
            CanCloseAccount = 64,
            CanViewStatement = 128,
            CanViewFraudFlags = 256,
            CanResolveFraudFlags = 512,
            CanViewAuditLog = 1024,
            CanExportAuditLog = 2048,
            CanManageUsers = 4096,
            CanUnlockUsers = 8192,
            CanChangePermissions = 16384,
            CanEditSystemConfig = 32768,
            CanViewCustomerNationalId = 65536,
            CanActivateOrDeactivateCustomer = 131072
        }

        private int _permissions = 0;
        public enPermissionPresenter PermissionPresenter { get; private set; }
        public string PermissionPresenterString { get; private set; }
        public int Permissions => _permissions;
        public bool Has(enPermission permission) => ((int)permission & _permissions) == (int)permission;
        public override string ToString() => PermissionPresenterString;
    }
}