using csharp.rpa.challenge.selenium.constants;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace csharp.rpa.challenge.selenium.browser
{
    class BrowserConfiguration
    {

        public static ChromeOptions getChromeOptions()
        {
            var options = new ChromeOptions();
            options.AddArguments("--test-type", "--start-maximized");
			options.AddArguments("--enable-automation");
			options.AddArguments("--start-maximized");
			options.AddArguments("--no-sandbox");
			options.AddArguments("--dns-prefetch-disable");
			options.AddArguments("--ignore-certificate-errors");
			options.AddArguments("--disable-popup-blocking");
			options.AddArguments("--incognito");
			options.AddArguments("--enable-precise-memory-info");
			options.AddArguments("--disable-default-apps");
			options.AddArguments("--disable-extensions");
			options.AddArguments("--disable-gpu");
			options.AddArguments("--disable-infobars");

            if (ChallengeConstants.CHROME_IS_HEADLESS)
            {
				options.AddArguments("--headless");
			}

			return options;
        }

    }
}
