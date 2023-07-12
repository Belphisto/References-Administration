using System;
using System.Configuration;
using System.Collections.Specialized;

namespace References_Administration
{
    public class Config
    {
        private static readonly NameValueCollection AppSettings = ConfigurationManager.AppSettings;
        public static readonly string LOG_PATH = AppSettings["LogFile"];
    }
}
