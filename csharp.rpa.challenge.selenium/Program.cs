using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace csharp.rpa.challenge.selenium
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver;
            driver = new ChromeDriver(@"C:\Projetos\RPA\csharp.rpa.challenge.selenium\csharp.rpa.challenge.selenium\resources\");
            driver.Manage().Window.Maximize();
            String baseURL = "https://www.google.com.br";

            driver.Navigate().GoToUrl(baseURL);
        }
    }
}
