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
        public static string PATH_CHROMEDRIVER = getValue("driver", "chromeDriverPath");

        public static string getValue(string section, string key)
        {
            var iniFile = new IniFile(@"C:\Projetos\RPA\csharp.rpa.challenge.selenium\csharp.rpa.challenge.selenium\resources\config.ini");
            return iniFile.GetValue(section, key);
        }
    }
}
