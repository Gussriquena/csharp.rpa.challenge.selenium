using csharp.rpa.challenge.selenium.model;
using IronXL;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
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

            List<Person> personList = loadExcelData();

            IWebDriver driver;
            driver = new ChromeDriver(constants.ChallengeConstants.PATH_CHROMEDRIVER);
            driver.Manage().Window.Maximize();


            driver.Navigate().GoToUrl(constants.ChallengeConstants.URL_CHALLENGE);
            log.Info("Opened website");
        }

        private static List<Person> loadExcelData()
        {
            // ironsoftware.com/csharp/excel/examples/read-xlsx-file

            string[] excelPath = Directory.GetFiles(constants.ChallengeConstants.PATH_INPUT_EXCEL, "*.xlsx");

            List<Person> personList = new List<Person>();

            WorkBook workbook = WorkBook.Load(excelPath[0]);
            WorkSheet sheet = workbook.DefaultWorkSheet;

            string currentCell = "A1";
            for (var counter = 2; currentCell.Length != 0; counter++)
            {
                currentCell = sheet["A" + counter + ""].StringValue;

                if (currentCell.Length != 0)
                {
                    Person person = new Person();

                    person.firstName = sheet["A" + counter + ""].StringValue;
                    person.lastName = sheet["B" + counter + ""].StringValue;
                    person.companyName = sheet["C" + counter + ""].StringValue;
                    person.roleInCompany = sheet["D" + counter + ""].StringValue;
                    person.address = sheet["E" + counter + ""].StringValue;
                    person.email = sheet["F" + counter + ""].StringValue;
                    person.phoneNumber = sheet["G" + counter + ""].StringValue;

                    personList.Add(person);
                }
            }

            return personList;
        }
    }
}
