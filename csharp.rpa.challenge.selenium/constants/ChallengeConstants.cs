using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace csharp.rpa.challenge.selenium.constants
{
    class ChallengeConstants
    {
        public static string URL_CHALLENGE = GetValue("url", "mainUrlChallenge");
        public static string PATH_INPUT_EXCEL = GetValue("files", "pathInputExcel");
        public static string PATH_OUTPUT_EXCEL = GetValue("files", "pathOutputExcel");
        public static string PATH_PROCESSING_EXCEL = GetValue("files", "pathProcessingExcel");
        public static string FILE_NAME = GetValue("files", "fileName");
        public static string FILE_EXTENSION = GetValue("files", "fileExtension");

        public static string PATH_CHROMEDRIVER = GetValue("driver", "chromeDriverPath");
        public static bool CHROME_IS_HEADLESS = Convert.ToBoolean(GetValue("driver", "headless"));

        public static string XPATH_INPUT_DEFAULT = "//div//label[contains(text(), '{0}')]//following-sibling::input";
        public static string XPATH_START_BUTTON = "//div/button[contains(text(), 'Start')]";
        public static string XPATH_SUBMIT_BUTTON = "//form//input[@Type='submit' or contains(text(), 'submit') or starts-with(@class, 'btn')]";

        public static string GetValue(string section, string key)
        {

            var iniFile = new IniFile(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\resources\\config.ini");
            return iniFile.GetValue(section, key);
        }
    }
}
