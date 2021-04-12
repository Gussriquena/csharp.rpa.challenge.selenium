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
        ChallengePage challengePage;

        public ChallengeController(Logging log)
        {
            this.log = log;
        }

        public void initFlow()
        {
           
            ExcelController excelController = new ExcelController();
            List<Person> personList = excelController.loadExcelData();

            if (personList.Count != 0) {
                startChallengeInsertion(personList);
                excelController.writeExcel(personList);
            }
           
            WebDriverFactory.closeDriver();
        }

        private void startChallengeInsertion(List<Person> personList)
        {
            driver = WebDriverFactory.getInstance();
            this.challengePage = new ChallengePage(driver);

            driver.Navigate().GoToUrl(ChallengeConstants.URL_CHALLENGE);
            challengePage.clickStart();

            foreach (var person in personList)
            {
                insertData(person);
            }
        }

        private void insertData(Person person)
        {
            try
            {
                challengePage.fillInput("First Name", person.firstName);
                challengePage.fillInput("Last Name", person.lastName);
                challengePage.fillInput("Company Name", person.companyName);
                challengePage.fillInput("Role in Company", person.roleInCompany);
                challengePage.fillInput("Address", person.address);
                challengePage.fillInput("Email", person.email);
                challengePage.fillInput("Phone Number", person.phoneNumber);
                challengePage.clickSubmit();

                person.isProcessed = true;
            }
            catch (Exception e)
            {
                log.Error(person.firstName + " - " + e.Message);
                driver.Navigate().GoToUrl(ChallengeConstants.URL_CHALLENGE);
            }
        }
    }
}
