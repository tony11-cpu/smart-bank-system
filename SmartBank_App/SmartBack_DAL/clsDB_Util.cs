using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Diagnostics;

namespace SmartBack_DAL
{
    internal static class clsDB_Util
    {
        public static readonly string ConnectionString = ConfigurationManager.ConnectionStrings["SmartBankDB"].ConnectionString;

        public static class clsLogger
        {
            public static void Log(string message, EventLogEntryType type = EventLogEntryType.Error)
            {
                string source = "SmartBank_Project";

                if (!EventLog.SourceExists(source))
                    EventLog.CreateEventSource(source, "Application");

                EventLog.WriteEntry(source, message, type);
            }
        }
    }
}
