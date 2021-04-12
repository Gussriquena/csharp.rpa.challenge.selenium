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

        public void initFlow()
        {
           
            ExcelController excelController = new ExcelController();
            List<Person> personList = excelController.loadExcelData();

            if (personList.Count != 0) {
                excelController.resultMessage = dataInsertion(personList);
                excelController.writeExcel(personList);
            }
           
            WebDriverFactory.closeDriver();
        }

        private string dataInsertion(List<Person> personList)
        {
            driver = WebDriverFactory.getInstance();
            this.challengePageJs = new ChallengePageJs(driver);

            driver.Navigate().GoToUrl(ChallengeConstants.URL_CHALLENGE);
            challengePageJs.clickStart();

            foreach (var person in personList)
            {
                insertData(person);
            }

            return challengePageJs.getResultMessage();
        }

        private void insertData(Person person)
        {
            try
            {
                challengePageJs.fillInput("First Name", person.firstName);
                challengePageJs.fillInput("Last Name", person.lastName);
                challengePageJs.fillInput("Company Name", person.companyName);
                challengePageJs.fillInput("Role", person.roleInCompany);
                challengePageJs.fillInput("Address", person.address);
                challengePageJs.fillInput("Email", person.email);
                challengePageJs.fillInput("Phone", person.phoneNumber);
                challengePageJs.clickSubmit();

                person.isProcessed = true;
            }
            catch (Exception e)
            {
                log.Error(e.Message + person);
                driver.Navigate().GoToUrl(ChallengeConstants.URL_CHALLENGE);
            }
        }
    }
}
