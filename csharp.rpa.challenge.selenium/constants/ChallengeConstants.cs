using System;
using System.Collections.Generic;
using System.Text;

namespace csharp.rpa.challenge.selenium.constants
{
    class ChallengeConstants
    {
        public static string URL_CHALLENGE = getValue("url", "mainUrlChallenge");
        public static string PATH_INPUT_EXCEL = getValue("files", "pathInputExcel");
        public static string PATH_OUTPUT_EXCEL = getValue("files", "pathOutputExcel");
        public static string PATH_PROCESSING_EXCEL = getValue("files", "pathProcessingExcel");
        public static string FILE_NAME = getValue("files", "fileName");
        public static string FILE_EXTENSION = getValue("files", "fileExtension");

        public static string PATH_CHROMEDRIVER = getValue("driver", "chromeDriverPath");
        public static bool CHROME_IS_HEADLESS = Convert.ToBoolean(getValue("driver", "headless"));

        public static string XPATH_INPUT_DEFAULT = "//div//label[contains(text(), '{0}')]//following-sibling::input";
        public static string XPATH_START_BUTTON = "//div/button[contains(text(), 'Start')]";
        public static string XPATH_SUBMIT_BUTTON = "//form//input[@Type='submit' or contains(text(), 'submit') or starts-with(@class, 'btn')]";
        public static string XPATH_MESSAGE_RESULT = "";

        public static string getValue(string section, string key)
        {
            var iniFile = new IniFile(@"C:\Projetos\RPA\csharp.rpa.challenge.selenium\csharp.rpa.challenge.selenium\resources\config.ini");
            return iniFile.GetValue(section, key);
        }
    }
}
