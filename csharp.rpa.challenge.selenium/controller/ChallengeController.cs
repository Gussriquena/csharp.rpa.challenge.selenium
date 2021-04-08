using csharp.rpa.challenge.selenium.constants;
using csharp.rpa.challenge.selenium.model;
using IronXL;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace csharp.rpa.challenge.selenium.controller
{
    class ChallengeController
    {
        public void initFlow()
        {
            List<Person> personList = loadExcelData();

            IWebDriver driver;
            driver = new ChromeDriver(ChallengeConstants.PATH_CHROMEDRIVER);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(ChallengeConstants.URL_CHALLENGE);
            driver.FindElement(By.XPath(ChallengeConstants.XPATH_START_BUTTON)).Click();

            String baseInputXpath = ChallengeConstants.XPATH_INPUT_DEFAULT;

            foreach (var person in personList)
            {
                driver.FindElement(By.XPath(string.Format(baseInputXpath, "First Name"))).SendKeys(person.firstName);
                driver.FindElement(By.XPath(string.Format(baseInputXpath, "Last Name"))).SendKeys(person.lastName);
                driver.FindElement(By.XPath(string.Format(baseInputXpath, "Company Name"))).SendKeys(person.companyName);
                driver.FindElement(By.XPath(string.Format(baseInputXpath, "Role in Company"))).SendKeys(person.roleInCompany);
                driver.FindElement(By.XPath(string.Format(baseInputXpath, "Address"))).SendKeys(person.address);
                driver.FindElement(By.XPath(string.Format(baseInputXpath, "Email"))).SendKeys(person.email);
                driver.FindElement(By.XPath(string.Format(baseInputXpath, "Phone Number"))).SendKeys(person.phoneNumber);

                driver.FindElement(By.XPath(ChallengeConstants.XPATH_SUBMIT_BUTTON)).Click();
            }

            driver.Close();
            driver.Quit();

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
