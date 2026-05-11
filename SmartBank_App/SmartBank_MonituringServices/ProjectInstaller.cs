using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.ServiceProcess;
using System.Threading.Tasks;

namespace SmartBank_MonituringServices
{
    [RunInstaller(true)]
    public partial class ProjectInstaller : Installer
    {
        private ServiceInstaller _serviceInstaller;
        private ServiceProcessInstaller _serviceProcessInstaller;

        public ProjectInstaller()
        {
            InitializeComponent();

            _serviceProcessInstaller = new ServiceProcessInstaller()
            {
                Account = ServiceAccount.LocalSystem
            };

            _serviceInstaller = new ServiceInstaller()
            {
                ServiceName = "HandlingSchedualedTransfaresService",
                StartType = ServiceStartMode.Automatic,
                DelayedAutoStart = true,
                DisplayName = "Handling Schedualed Transfares Service in Smart Bank System",
                Description = "Service for handling schedualed transfare transactions throughout the system.",
                ServicesDependedOn = new string[] 
                {
                    "MSSQLSERVER"
                }
            };

            Installers.Add(_serviceProcessInstaller);
            Installers.Add(_serviceInstaller);
        }
    }
}
