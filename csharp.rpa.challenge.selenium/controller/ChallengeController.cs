using csharp.rpa.challenge.selenium.browser;
using csharp.rpa.challenge.selenium.constants;
using csharp.rpa.challenge.selenium.model;
using csharp.rpa.challenge.selenium.pages;
using csharp.rpa.challenge.selenium.utils;
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
        private readonly Logging log;
        private IWebDriver driver;
        ChallengePageJs challengePageJs;

        public ChallengeController(Logging log)
        {
            this.log = log;
        }

        public void InitFlow()
        {
            ExcelController excelController = new();
            List<Person> personList = excelController.LoadExcelData();

            if (personList.Count != 0) {
                using (WebDriverFactory factory = new())
                {
                    driver = factory.Driver;
                    excelController.resultMessage = DataInsertion(personList);
                    excelController.WriteExcel(personList);

                    log.Info(excelController.resultMessage);
                }
            } 
            else
            {
                log.Info("There is no file to process");
            }
        }

        private string DataInsertion(List<Person> personList)
        {
            this.challengePageJs = new ChallengePageJs(driver);

            driver.Navigate().GoToUrl(ChallengeConstants.URL_CHALLENGE);
            challengePageJs.ClickStart();

            foreach (Person person in personList)
            {
                InsertData(person);
            }

            return challengePageJs.GetResultMessage();
        }

        private void InsertData(Person person)
        {
            try
            {
                string command 
                    = "$('input[ng-reflect-name=labelFirstName]').val('" + person.firstName + "');"
                    + "$('input[ng-reflect-name=labelLastName]').val('" + person.lastName + "');"
                    + "$('input[ng-reflect-name=labelCompanyName]').val('" + person.companyName + "');"
                    + "$('input[ng-reflect-name=labelRole]').val('" + person.roleInCompany + "');"
                    + "$('input[ng-reflect-name=labelAddress]').val('" + person.address + "');"
                    + "$('input[ng-reflect-name=labelEmail]').val('" + person.email + "');"
                    + "$('input[ng-reflect-name=labelPhone]').val('" + person.phoneNumber + "');"
                    + "$('.inputFields .uiColorButton').click();\n";
               
                challengePageJs.FillPage(command);
                person.isProcessed = true;
            }
            catch (Exception e)
            {
                log.Error(e.Message + person);
                person.isProcessed = false;
                driver.Navigate().GoToUrl(ChallengeConstants.URL_CHALLENGE);
            }
        }
    }
}
