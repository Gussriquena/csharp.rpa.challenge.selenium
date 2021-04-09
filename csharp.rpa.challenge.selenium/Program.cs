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
    class Program
    {

        private static readonly Logging log = new Logging(@"C:\Arquivos\rpa.challenge.csharp\log\", "log_" + DateTime.Now.ToString("yyyMMdd_HHmmss") + ".txt");

        static void Main(string[] args)
        {
            log.Info("Starting application");

            ChallengeController challengeController = new ChallengeController(log);
            challengeController.initFlow();

            log.Info("Flow ended");
        }
    }
}
