using csharp.rpa.challenge.selenium.constants;
using csharp.rpa.challenge.selenium.utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace csharp.rpa.challenge.selenium.browser
{
    class WebDriverFactory : IDisposable
    {
        public IWebDriver Driver { get; set; }
        private bool disposedValue;

        public WebDriverFactory()
        {
            Driver = new ChromeDriver(ChallengeConstants.PATH_CHROMEDRIVER, BrowserConfiguration.GetChromeOptions());
            Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(80);
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(80);
        }

        public void CloseDriver()
        {
            Driver.Close();
            Driver.Quit();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    CloseDriver();
                }

                // Tarefa pendente: liberar recursos não gerenciados (objetos não gerenciados) e substituir o finalizador
                // Tarefa pendente: definir campos grandes como nulos
                disposedValue = true;
            }
        }

        // // Tarefa pendente: substituir o finalizador somente se 'Dispose(bool disposing)' tiver o código para liberar recursos não gerenciados
        // ~WebDriverFactory()
        // {
        //     // Não altere este código. Coloque o código de limpeza no método 'Dispose(bool disposing)'
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Não altere este código. Coloque o código de limpeza no método 'Dispose(bool disposing)'
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
