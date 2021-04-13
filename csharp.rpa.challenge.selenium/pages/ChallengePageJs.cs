using csharp.rpa.challenge.selenium.constants;
using csharp.rpa.challenge.selenium.model;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace csharp.rpa.challenge.selenium.pages
{
    class ChallengePageJs
    {
        IJavaScriptExecutor js;

        public ChallengePageJs(IWebDriver driver)
        {
            js = (IJavaScriptExecutor) driver;
        }

        public void clickStart()
        {
            js.ExecuteScript("document.querySelector('div > button').click()");
        }

        public void clickSubmit()
        {
            js.ExecuteScript("document.querySelector(\"form > input[value='Submit']\").click()");
        }

        public void fillInput(String fieldName, String data)
        {
            String labelName = "label" + fieldName.Replace(" ", "");
            js.ExecuteScript("document.querySelector(\"div > rpa1-field[ng-reflect-label='" + labelName + "'] > div > input\").value='" + data + "'");
        }

        public void fillPage(string command)
        {
            js.ExecuteScript(command);
        }

        public string getResultMessage()
        {
            String message = "";

            try
            {
                message = js.ExecuteScript("return document.querySelector('div.message2').innerText").ToString();
            }
            catch (Exception)
            {
                message = "was not possible to get result Message";
            }

            return message;
        }
    }
}
