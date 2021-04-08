using csharp.rpa.challenge.selenium.browser;
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
            ExcelController excelController = new ExcelController();
            List<Person> personList = excelController.loadExcelData();

            IWebDriver driver;
            driver = new ChromeDriver(ChallengeConstants.PATH_CHROMEDRIVER, BrowserConfiguration.getChromeOptions());
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
        }
    }
}
