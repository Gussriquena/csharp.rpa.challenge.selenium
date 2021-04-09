using csharp.rpa.challenge.selenium.constants;
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
            driver = new ChromeDriver(ChallengeConstants.PATH_CHROMEDRIVER, BrowserConfiguration.getChromeOptions());
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(80);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(80);
            
            return driver;
        }

        public static void closeDriver()
        {
            //driver.Close();
            //driver.Quit();
        }
    }
}
