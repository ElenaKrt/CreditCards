using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace UIFramework
{
    public class BasePage : DriverHandler
    {
        public bool GoToUrl(string url)
        {
            Driver.Navigate().GoToUrl(url);
            this.WaitForWindowsToLoad();
            return Driver.Url.Contains(url);
        }

        public void WaitForWindowsToLoad()
        {
            DateTime dateTime = DateTime.Now.AddSeconds(15);
            do
                ;
            while (!((string)GetWindowStatus() == "complete") 
                && DateTime.Now < dateTime);
        }

        protected object GetWindowStatus()
        {
            return ExecuteJavaScript("return document.readyState;");
        }

        protected object ExecuteJavaScript(string js)
        {
            IJavaScriptExecutor driver = (IJavaScriptExecutor)DriverHandler.Driver;
            try
            {
                    return driver.ExecuteScript(js);
            }
            catch (Exception ex)
            {
                Console.WriteLine("ExecuteJSScript error: " + js + ": " + ex);
            }
            return null;
        }

        protected bool Click(IWebElement webElement, bool wait = false)
        {
            if (webElement == null)
                return false;
            DateTime dateTime = DateTime.Now.AddSeconds(20);
            do
            {
                    if (webElement != null)
                    {
                        webElement.Click();
                        if (!wait)
                            return true;
                        this.WaitForWindowsToLoad();
                        return true;
                    }
            }
            while (DateTime.Now < dateTime);
            return false;
        }

        public static bool ScrollDown()
        {
           var res = ((IJavaScriptExecutor)Driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight - 150)");
            return res != null;
        }

        public bool GetPageUrl(string expectedPage)
        {
            DateTime wait = DateTime.Now.AddSeconds(5);
            do
            {
                var res = Driver.Url;
                if (res.Contains(expectedPage))
                    return true;
            } while (DateTime.Now < wait);
            return false;
        }

        protected internal virtual void HooverOver(Domain.DomElement domElement)
        {
            Actions builder = new Actions(Driver);
            var res = Find(domElement);
            builder.MoveToElement(res)
                .Click().Build().Perform();

        }

        protected internal virtual IWebElement Find(Domain.DomElement domElement)
        {
            string attributeValue = domElement.AttributeValue;
            DateTime dateTime = DateTime.Now.AddSeconds( 20);
            do
            {
                try
                {
                    switch (domElement.AttributeName)
                    {
                       case (Domain.DomElementType.ClassName):
                            return Driver.FindElement(By.ClassName(attributeValue));
                        case Domain.DomElementType.CssSelector:
                            return Driver.FindElement(By.CssSelector(attributeValue));
                        case Domain.DomElementType.XPath:
                                return Driver.FindElement(By.XPath(attributeValue));
                        default:
                            return Driver.FindElement(By.Id(attributeValue));
                    }
                }
                catch (Exception ex)
                {
                    if (DateTime.Now >= dateTime)
                    {
                        if (ex is NoSuchElementException || ex is WebDriverTimeoutException || ex is WebDriverException || ex is InvalidOperationException && ex.Message.Contains("Sizzle is not defined"))
                        {
                            return (IWebElement)null;
                        }
                        throw;
                    }
                }
            }
            while (DateTime.Now < dateTime);
            return null;
        }
    }
}
