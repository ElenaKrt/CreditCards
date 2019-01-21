using System;
using System.Configuration;

namespace UIFramework
{
    public static class GlobalVariables
    {
        public static string BrowserUrl { get; set; }
        public static Domain.Browser BrowserType;
        
        public static void GetContext()
        {
            BrowserUrl = ConfigurationManager.AppSettings["testingSiteURL"];
            string appSetting = ConfigurationManager.AppSettings["browserType"];
            BrowserType = string.IsNullOrEmpty(appSetting) ? Domain.Browser.None : (Domain.Browser)Enum.Parse(typeof(Domain.Browser), appSetting);
        }
    }
}
