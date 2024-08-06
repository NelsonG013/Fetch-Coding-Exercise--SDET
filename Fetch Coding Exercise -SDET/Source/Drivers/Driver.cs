using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fetch_Coding_Exercise__SDET.Source.Drivers
{
    public class Driver
    {
        public static IWebDriver _driver;

        [SetUp]
        public void InitScript()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl("http://sdetchallenge.fetch.com/");
            _driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void CleanUp()
        {
            _driver.Quit();
        }
    }
}
