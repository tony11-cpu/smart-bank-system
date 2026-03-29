using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBank
{
    public class clsPermissions
    {
        private static readonly int _tellerPerms = (int)(enPermission.CanDeposit | enPermission.CanWithdraw | enPermission.CanTransfer |
                                                   enPermission.CanScheduleTransfer | enPermission.CanOpenAccount | enPermission.CanViewStatement);

        private static readonly int _managerPerms = _tellerPerms | (int)(enPermission.CanFreezeAccount | enPermission.CanCloseAccount |
                                                                          enPermission.CanViewFraudFlags | enPermission.CanResolveFraudFlags |
                                                                          enPermission.CanViewAuditLog | enPermission.CanExportAuditLog |
                                                                          enPermission.CanViewCustomerNationalId);

        private static readonly int _adminPerms = _managerPerms | (int)(enPermission.CanManageUsers | enPermission.CanUnlockUsers |
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
                    _permissions = _tellerPerms;
                    break;
                case enPermissionPresenter.Manager:
                    _permissions = _managerPerms;
                    break;
                case enPermissionPresenter.Admin:
                    _permissions = _adminPerms;
                    break;
            }

            this.PermissionPresenter = presenter;
            this.PermissionPresenterString = presenter.ToString();
        }

        private enPermissionPresenter _loadPermissionPresenter()
        {
            if (_permissions == _adminPerms)
            {
                PermissionPresenterString = "Admin";
                return enPermissionPresenter.Admin;
            }
            else if (_permissions == _managerPerms)
            {
                PermissionPresenterString = "Manager";
                return enPermissionPresenter.Manager;
            }
            else if (_permissions == _tellerPerms)
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
            CanViewCustomerNationalId = 65536
        }

        private int _permissions = 0;
        public enPermissionPresenter PermissionPresenter { get; private set; }
        public string PermissionPresenterString { get; private set; }
        public int Permissions => _permissions;
        public bool Has(enPermission permission) => ((int)permission & _permissions) == (int)permission;
        public override string ToString() => PermissionPresenterString;
    }
}