using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBank
{
    public class clsPermissions
    {
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
                    _permissions = (int)(enPermission.CanDeposit | enPermission.CanWithdraw | enPermission.CanTransfer | enPermission.CanScheduleTransfer |
                                         enPermission.CanOpenAccount | enPermission.CanViewStatement);
                    break;

                case enPermissionPresenter.Manager:
                    _permissions = (int)(enPermission.CanDeposit | enPermission.CanWithdraw | enPermission.CanTransfer | enPermission.CanScheduleTransfer |
                                         enPermission.CanOpenAccount | enPermission.CanViewStatement | enPermission.CanFreezeAccount | enPermission.CanCloseAccount |
                                         enPermission.CanViewFraudFlags | enPermission.CanResolveFraudFlags | enPermission.CanViewAuditLog | enPermission.CanExportAuditLog);
                    break;

                case enPermissionPresenter.Admin:
                    _permissions = (int)(enPermission.CanDeposit | enPermission.CanWithdraw | enPermission.CanTransfer | enPermission.CanScheduleTransfer |
                                         enPermission.CanOpenAccount | enPermission.CanViewStatement | enPermission.CanFreezeAccount | enPermission.CanCloseAccount |
                                         enPermission.CanViewFraudFlags | enPermission.CanResolveFraudFlags | enPermission.CanViewAuditLog |
                                         enPermission.CanExportAuditLog | enPermission.CanManageUsers | enPermission.CanUnlockUsers |
                                         enPermission.CanChangePermissions | enPermission.CanEditSystemConfig);
                    break;
            }

            this.PermissionPresenter = presenter;
        }

        private enPermissionPresenter _loadPermissionPresenter()
        {
            if(_permissions == (int)(enPermission.CanDeposit | enPermission.CanWithdraw | enPermission.CanTransfer | enPermission.CanScheduleTransfer |
                                         enPermission.CanOpenAccount | enPermission.CanViewStatement | enPermission.CanFreezeAccount | enPermission.CanCloseAccount |
                                         enPermission.CanViewFraudFlags | enPermission.CanResolveFraudFlags | enPermission.CanViewAuditLog |
                                         enPermission.CanExportAuditLog | enPermission.CanManageUsers | enPermission.CanUnlockUsers |
                                         enPermission.CanChangePermissions | enPermission.CanEditSystemConfig))
            {
                return enPermissionPresenter.Admin;
            }
            else if(_permissions == (int)(enPermission.CanDeposit | enPermission.CanWithdraw | enPermission.CanTransfer | enPermission.CanScheduleTransfer |
                                         enPermission.CanOpenAccount | enPermission.CanViewStatement | enPermission.CanFreezeAccount | enPermission.CanCloseAccount |
                                         enPermission.CanViewFraudFlags | enPermission.CanResolveFraudFlags | enPermission.CanViewAuditLog | enPermission.CanExportAuditLog))
            {
                return enPermissionPresenter.Manager;
            }
            else if(_permissions == (int)(enPermission.CanDeposit | enPermission.CanWithdraw | enPermission.CanTransfer | enPermission.CanScheduleTransfer |
                                         enPermission.CanOpenAccount | enPermission.CanViewStatement))
            {
                return enPermissionPresenter.Teller;
            }

            return enPermissionPresenter.Custom;
        }

        public enum enPermissionPresenter { Admin, Manager, Teller , Custom }

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
            CanEditSystemConfig = 32768
        }

        public enPermissionPresenter PermissionPresenter { get; private set; }

        private int _permissions;

        public int Permissions => _permissions;

        public bool Has(enPermission permission) => ((int)permission & _permissions) == (int)permission;
    }
}
