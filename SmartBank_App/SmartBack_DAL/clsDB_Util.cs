using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SmartBack_DAL
{
    internal class clsDB_Util
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
