using IronXL;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Linq;

namespace csharp.rpa.challenge.selenium
{
    class Program
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        static void Main(string[] args)
        {
            log.Info("Starting application");

            loadExcelData();

            IWebDriver driver;
            driver = new ChromeDriver(constants.ChallengeConstants.PATH_CHROMEDRIVER);
            driver.Manage().Window.Maximize();


            driver.Navigate().GoToUrl(constants.ChallengeConstants.URL_CHALLENGE);
            log.Info("Opened website");


        }

        private static void loadExcelData()
        {
            // ironsoftware.com/csharp/excel/examples/read-xlsx-file

            string[] excelPath = Directory.GetFiles(constants.ChallengeConstants.PATH_INPUT_EXCEL, "*.xlsx");

            WorkBook workbook = WorkBook.Load(excelPath[0]);
            WorkSheet sheet = workbook.DefaultWorkSheet;

            string currentCell = "A1";
            for (var counter = 1; currentCell.Length != 0; counter++)
            {
                currentCell = sheet["A" + counter + ""].StringValue;
                Console.WriteLine(currentCell);
            }

            Console.ReadKey();
        }
    }
}
