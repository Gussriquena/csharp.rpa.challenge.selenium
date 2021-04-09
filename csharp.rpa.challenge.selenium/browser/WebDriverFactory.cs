using csharp.rpa.challenge.selenium.utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace csharp.rpa.challenge.selenium.browser
{
    class WebDriverFactory
    {
        private static IWebDriver driver;

        public static IWebDriver getInstance()
        {
            driver = new ChromeDriver(BrowserConfiguration.getChromeOptions());
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            
            return driver;
        }

        public static void closeDriver()
        {
            driver.Close();
            driver.Quit();
        }
    }
}
