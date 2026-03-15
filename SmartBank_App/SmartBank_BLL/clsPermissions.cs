using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBank_BLL
{
    public class clsPermissions
    {
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

        public enum enPermissionPresenter { Admin , Manager , Teller}

        private int _permissions;

        public int Permissions => _permissions;

        public clsPermissions(int permissions) => this._permissions = permissions;

        public clsPermissions(enPermissionPresenter presenter) => _getPresenterPermissions(presenter);

        private void _getPresenterPermissions(enPermissionPresenter presenter)
        {
            _permissions = 0;

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
        }

        public bool Has(enPermission permission) => ((int)permission & _permissions) == (int)permission;
    }
}
