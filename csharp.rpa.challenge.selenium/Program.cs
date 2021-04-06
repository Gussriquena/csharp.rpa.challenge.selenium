using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;

namespace csharp.rpa.challenge.selenium
{
    class Program
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        static void Main(string[] args)
        {
            log.Info("Starting application");

            IWebDriver driver;
            driver = new ChromeDriver(constants.ChallengeConstants.PATH_CHROMEDRIVER);
            driver.Manage().Window.Maximize();


            driver.Navigate().GoToUrl(constants.ChallengeConstants.URL_CHALLENGE);


            log.Info("Opened website");

        }

        private void loadExcelData()
        {
            string[] excelPath = Directory.GetFiles(@"c:\MyDir\", "*.xlsx");
        }
    }
}
