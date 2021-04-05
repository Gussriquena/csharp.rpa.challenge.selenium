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
            var iniFile = new IniFile(@"C:\Projetos\RPA\csharp.rpa.challenge.selenium\csharp.rpa.challenge.selenium\resources\config.ini");

            IWebDriver driver;
            driver = new ChromeDriver(@"C:\Projetos\RPA\csharp.rpa.challenge.selenium\csharp.rpa.challenge.selenium\resources\");
            driver.Manage().Window.Maximize();
            String baseURL = iniFile.GetValue("url", "mainUrlChallenge");

            driver.Navigate().GoToUrl(baseURL);
            log.Info("Opened website");

        }
    }
}
