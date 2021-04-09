using csharp.rpa.challenge.selenium.constants;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace csharp.rpa.challenge.selenium.pages
{
    class ChallengePage
    {

        private IWebDriver driver;

        private By startButtonBy = By.XPath(ChallengeConstants.XPATH_START_BUTTON);
        private By submitButtonBy = By.XPath(ChallengeConstants.XPATH_SUBMIT_BUTTON);
        private By inputDefault;

        public ChallengePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void clickStart()
        {
            driver.FindElement(startButtonBy).Click(); 
        }

        public void clickSubmit()
        {
            driver.FindElement(submitButtonBy).Click();
        }

        public void fillInput(String fieldName, String data) 
        {
            this.inputDefault = By.XPath(string.Format(ChallengeConstants.XPATH_INPUT_DEFAULT, fieldName));
            driver.FindElement(inputDefault).SendKeys(data);
        }
    }
}
