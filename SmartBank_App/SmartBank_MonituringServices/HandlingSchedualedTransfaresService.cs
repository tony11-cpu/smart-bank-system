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
        private DateTime _lastScheduledFraudScanDate = DateTime.Now;

        public HandlingSchedualedTransfaresService()
        {
            InitializeComponent();

            this.ServiceName = "HandlingSchedualedTransfaresService";
            _scheduledTransfersTimer.AutoReset = true;
            _scheduledTransfersTimer.Elapsed += _scheduledTransfersTimer_Elapsed;
        }

        private void _logServiceMessage(string message) => clsUtil.clsLogger.Log(clsUtil.clsLogger.LogDirectory.SchedualTransfareFile, message);

        private async Task<int> _getConfigValueAsync(clsConfigurations.enConfigKey key, int defaultValue)
        {
            int? configValue = await clsConfigurations.GetConfigValueAsync(key);
            return configValue.HasValue && configValue.Value > 0 ? configValue.Value : defaultValue;
        }

        private async Task _processScheduledTransfersAsync()
        {
            lock (_processLock)
            {
                if (_isProcessingScheduledTransfers || _isStoppingService)
                {
                    _logServiceMessage($"Scheduled transfer processing skipped because previous processing is still running or service is stopping.");
                    return;
                }

                _isProcessingScheduledTransfers = true;
            }

            try
            {
                DateTime scanFrom = _lastScheduledFraudScanDate;
                DateTime scanTo = DateTime.Now;
                int maxRetries = await _getConfigValueAsync(clsConfigurations.enConfigKey.MaxScheduledTransferRetries, 3);

                for (int retryNumber = 0; retryNumber <= maxRetries; retryNumber++)
                {
                    try
                    {
                        int numberOfTransactionsResolved = await clsTransactions_DAL.ProcessScheduledTransfersAsync();
                        _logServiceMessage($"{numberOfTransactionsResolved} scheduled transfers processed.");

                        if (numberOfTransactionsResolved > 0)
                        {
                            DataTable processedScheduledDebits = await clsTransactions_DAL.GetProcessedScheduledDebitTransactionsAsync(scanFrom, scanTo);
                            await clsFraudDetectionService.EvaluateScheduledDebitTransactionsAsync(processedScheduledDebits);
                        }

                        _lastScheduledFraudScanDate = scanTo;
                        break;
                    }
                    catch (Exception ex)
                    {
                        if (retryNumber == maxRetries)
                        {
                            _logServiceMessage($"Scheduled transfer processing failed after {maxRetries} retries. Error: {ex.Message}");
                            break;
                        }

                        _logServiceMessage($"Scheduled transfer processing failed. retry {retryNumber + 1} of {maxRetries}. Error: {ex.Message}");
                    }
                }
            }
            finally
            {
                lock (_processLock)
                {
                    _isProcessingScheduledTransfers = false;
                }
            }
        }

        protected override async void OnStart(string[] args)
        {
            try
            {
                Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.Normal;
                _isStoppingService = false;
                _lastScheduledFraudScanDate = DateTime.Now.AddMinutes(-5);

                int serviceCheckIntervalSeconds = await _getConfigValueAsync(clsConfigurations.enConfigKey.ScheduledTransferCheckIntervalSeconds, 60);
                _scheduledTransfersTimer.Interval = TimeSpan.FromSeconds(serviceCheckIntervalSeconds).TotalMilliseconds;

                _logServiceMessage("Service started successfully.");
                _logServiceMessage($"Service check interval set to {serviceCheckIntervalSeconds} seconds.");
                _scheduledTransfersTimer.Start();

                await _processScheduledTransfersAsync();
            }
            catch (Exception ex)
            {
                _logServiceMessage($"Service failed to start correctly. Error: {ex.Message}");
                throw;
            }
        }

        private async void _scheduledTransfersTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                await _processScheduledTransfersAsync();
            }
            catch (Exception ex)
            {
                _logServiceMessage($"Unexpected error while processing scheduled transfers: {ex.Message}");
            }
        }

        protected override void OnStop()
        {
            _isStoppingService = true;

            _scheduledTransfersTimer.Stop();
            _scheduledTransfersTimer.Dispose();

            _logServiceMessage("Service stopped.");

            base.OnStop();
        }
    }
}
