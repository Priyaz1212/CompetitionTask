using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsQA_1.Helpers
{
    public class Driver
    {
        public static IWebDriver driver { get; set; }
        public void Initialize()
        {
            driver  = new ChromeDriver();
            ImplicitWaitMethod();
            driver.Manage().Window.Maximize();

        }

        public static string BaseURL
        {
            get { return ConstantHelpers.Url; }
        }

        public static void NavigateURL()
        {
            driver.Navigate().GoToUrl(BaseURL);

        }
        public static void ImplicitWaitMethod()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);  

        }

        
        public void close()
        {
            driver.Quit();

        }

        public static IWebElement WaitForElement(IWebDriver driver, By by, int timeOutinSeconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutinSeconds));
            return (wait.Until(ExpectedConditions.ElementIsVisible(by)));
        }

        public static IWebElement WaitForElementToBeClickable(IWebDriver driver, By by, int timeOutinSeconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutinSeconds));
            return (wait.Until(ExpectedConditions.ElementToBeClickable(by)));
        }
        public static void WaitTobeClicable(IWebDriver driver, int seconds, string locator, string locatorvalue)
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, seconds));
            if (locator == "XPath")
            {

                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(locatorvalue)));
            }
            if (locator == "Id")
            {

                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id(locatorvalue)));
            }
            if (locator == "CssSelector")
            {

                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector(locatorvalue)));
            }
        }
    }
}
