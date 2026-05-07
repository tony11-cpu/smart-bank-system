using SmartBank_BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace SmartBank_MonituringServices
{
    partial class HandlingSchedualedTransfaresService : ServiceBase
    {
        public HandlingSchedualedTransfaresService()
        {
            InitializeComponent();

            CanShutdown = true;
            this.ServiceName = "HandlingSchedualedTransfaresService";

        }

        private void _logServiceMessage(string message)
        {
            clsUtil.clsLogger.Log(clsUtil.clsLogger.LogDirectory.SchedualTransfareFile, message);
        }

        protected override void OnStart(string[] args)
        {
            Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.Normal;
            
            try
            {

                _logServiceMessage("Service started successfully.");
            }
            catch (Exception ex)
            {
                _logServiceMessage($"An error occurred while starting the service: {ex.Message}");
                this.OnStop();
            }
        }

        protected override void OnStop()
        {
            _logServiceMessage("Service stopped.");
        }

        protected override void OnShutdown()
        {
            
        }
    }
}
