using SmartBack_DAL;
using SmartBank;
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
using System.Timers;

namespace SmartBank_MonituringServices
{
    partial class HandlingSchedualedTransfaresService : ServiceBase
    {
        private readonly Timer _scheduledTransfersTimer = new Timer(TimeSpan.FromMinutes(5).TotalMilliseconds);
        private readonly object _processLock = new object();
        private bool _isProcessingScheduledTransfers = false;
        private bool _isStoppingService = false;

        public HandlingSchedualedTransfaresService()
        {
            InitializeComponent();
            this.ServiceName = "HandlingSchedualedTransfaresService";
            _scheduledTransfersTimer.AutoReset = true;
            _scheduledTransfersTimer.Elapsed += _scheduledTransfersTimer_Elapsed;
        }

        private void _logServiceMessage(string message)
        {
            clsUtil.clsLogger.Log(clsUtil.clsLogger.LogDirectory.SchedualTransfareFile, message);
        }

        private async Task _processScheduledTransfersAsync(string triggerSource)
        {
            lock (_processLock)
            {
                if (_isProcessingScheduledTransfers || _isStoppingService)
                {
                    _logServiceMessage($"Scheduled transfer processing skipped ({triggerSource}) because previous processing is still running or service is stopping.");
                    return;
                }

                _isProcessingScheduledTransfers = true;
            }

            try
            {
                int numberOfTransactionsResolved = await clsTransactions_DAL.ProcessScheduledTransfersAsync();
                _logServiceMessage($"{numberOfTransactionsResolved} scheduled transfers processed ({triggerSource}).");
            }
            catch (Exception ex)
            {
                _logServiceMessage($"An error occurred while processing scheduled transfers ({triggerSource}): {ex.Message}");
            }
            finally
            {
                lock (_processLock)
                {
                    _isProcessingScheduledTransfers = false;
                }
            }
        }

        protected override void OnStart(string[] args)
        {
            Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.Normal;
            _isStoppingService = false;

            _logServiceMessage("Service started successfully.");
            _scheduledTransfersTimer.Start();

            _ = _processScheduledTransfersAsync("OnStart");
        }

        private async void _scheduledTransfersTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            await _processScheduledTransfersAsync("TimerElapsed");
        }

        protected override void OnStop()
        {
            _isStoppingService = true;
            _scheduledTransfersTimer.Stop();
            _scheduledTransfersTimer.Dispose();

            _logServiceMessage("Service stopped.");
        }
    }
}
