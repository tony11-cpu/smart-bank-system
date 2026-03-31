using SmartBank;
using SmartBank_UI.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SmartBank.clsPermissions;

namespace SmartBank_UI.Users.Users_User_Control
{
    public partial class ctrlUserPermissions : UserControl
    {
        public ctrlUserPermissions()
        {
            InitializeComponent();
        }

        private Dictionary<Button, enPermission> _permissionMap => new Dictionary<Button, enPermission>
        {
            { btnDeposit,             enPermission.CanDeposit },
            { btnWithdraw,            enPermission.CanWithdraw },
            { btnTransfer,            enPermission.CanTransfer },
            { btnScheduleTransfer,    enPermission.CanScheduleTransfer },
            { btnOpenAccount,         enPermission.CanOpenAccount },
            { btnViewStatement,       enPermission.CanViewStatement },
            { btnFreezeAccount,       enPermission.CanFreezeAccount },
            { btnCloseAccount,        enPermission.CanCloseAccount },
            { btnViewFraudFlag,       enPermission.CanViewFraudFlags },
            { btnResolveFlags,        enPermission.CanResolveFraudFlags },
            { btnViewAuditLog,        enPermission.CanViewAuditLog },
            { btnExportAuditLog,      enPermission.CanExportAuditLog },
            { btnManageUsers,         enPermission.CanManageUsers },
            { btnUnlockUsers,         enPermission.CanUnlockUsers },
            { btnChangePermissions,   enPermission.CanChangePermissions },
            { btnSystemConfig,        enPermission.CanEditSystemConfig },
            { btnViewCustomerId,      enPermission.CanViewCustomerNationalId },
            { btnCustomerActivity, enPermission.CanActivateOrDeactivateCustomer }
        };

        public clsPermissions Permissions { get; private set; }
        private bool _isReadOnly = true;


        public void LoadPermissions(int permissions)
        {
            Permissions = new clsPermissions(permissions);
            _isReadOnly = true;
            _applyPermissionIcons(Permissions.Permissions);
        }

        private void btnTellerPresent_Click(object sender, EventArgs e)
        {
            _isReadOnly = true;
            _applyPermissionIcons(enPermissionPresenter.Teller);
        }
        private void btnManagerPresent_Click(object sender, EventArgs e)
        {
            _isReadOnly = true;
            _applyPermissionIcons(enPermissionPresenter.Manager);
        }
        private void btnAdminPresent_Click(object sender, EventArgs e)
        {
            _isReadOnly = true;
            _applyPermissionIcons(enPermissionPresenter.Admin);
        }
        private void btnCustomePermissions_Click(object sender, EventArgs e)
        {
            _isReadOnly = false;
            Permissions = new clsPermissions(0);

            foreach (var btn in _permissionMap.Keys)
                btn.Image = Resources.icons8_dot_24__1_;
        }

        private void _applyPermissionIcons(int permissions)
        {
            Permissions = new clsPermissions(permissions);
            foreach (var kvp in _permissionMap)
                kvp.Key.Image = Permissions.Has(kvp.Value) ? Resources.icons8_dot_24 : Resources.icons8_dot_24__1_;
        }

        private void _applyPermissionIcons(enPermissionPresenter permission)
        {
            Permissions = new clsPermissions(permission);
            foreach (var kvp in _permissionMap)
                kvp.Key.Image = Permissions.Has(kvp.Value) ? Resources.icons8_dot_24 : Resources.icons8_dot_24__1_;
        }

        private void Permission_Click(object sender, EventArgs e)
        {
            if (_isReadOnly) 
                return;

            Button btn = (Button)sender;
            enPermission perm = _permissionMap[btn];
            btn.Image = Permissions.Has(perm) ? Resources.icons8_dot_24__1_ : Resources.icons8_dot_24;
            Permissions = new clsPermissions(btn.Image == Resources.icons8_dot_24 ? Permissions.Permissions & ~(int)perm : Permissions.Permissions | (int)perm);
        }

        private void ctrlUserPermissions_Load(object sender, EventArgs e)
        {
            Permissions = new clsPermissions(0);
        }
    }
}
