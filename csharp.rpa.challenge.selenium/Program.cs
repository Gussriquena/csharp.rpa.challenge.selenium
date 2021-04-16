using csharp.rpa.challenge.selenium.constants;
using csharp.rpa.challenge.selenium.controller;
using csharp.rpa.challenge.selenium.model;
using csharp.rpa.challenge.selenium.utils;
using IronXL;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace csharp.rpa.challenge.selenium
{
    /// <summary>
    /// You will see that this project was created with too many classes and packages for your size
    /// however, was created with this amount of classes justly to test implementation of new project patterns to RPA
    /// So, each functions and responsabilities that a selenium project have to be, are in your respective classes
    /// </summary>
    class Program
    {

        private static readonly Logging log = new(@"C:\Arquivos\rpa.challenge.csharp\log\", "log_" + DateTime.Now.ToString("yyyMMdd_HHmmss") + ".txt");

        static void Main(string[] args)
        {
            log.Info("Starting application");

            ChallengeController challengeController = new(log);
            challengeController.InitFlow();

            log.Info("Flow ended");

            log.Info(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory));
        }
    }
}
