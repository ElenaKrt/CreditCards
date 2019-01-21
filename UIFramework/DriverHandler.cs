
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace UIFramework
{
    public class DriverHandler
    {
        public static IWebDriver Driver { get; set; }
        public static string BrowserUrl { get; set; }
        public static Domain.Browser BrowserType;

        public IWebDriver StartBrowser()
        {
            GlobalVariables.GetContext();
            BrowserType = GlobalVariables.BrowserType;
            BrowserUrl = GlobalVariables.BrowserUrl;  
                switch (BrowserType)
                {
                    case Domain.Browser.Firefox:
                    {
                        Driver = new FirefoxDriver();
                        break;
                    }
                    case Domain.Browser.Chrome:
                    {
                        Driver = new ChromeDriver();
                        break;
                    }
                    default:
                    {
                        Driver = new InternetExplorerDriver();
                        break;
                    }
                }
            Driver.Manage().Window.Maximize();
            return Driver;
        }

        public static void CloseBrowser()
        {
            Driver.Close();
            Driver.Quit();
            Driver = null;
        }
    }
}
