using Fetch_Coding_Exercise__SDET.Source.Drivers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fetch_Coding_Exercise__SDET.Source.Pages
{
    public class HomePage : Driver
    {
        public IWebElement resetButton => _driver.FindElement(By.XPath("//button[text() = 'Reset']"));
        public IWebElement weighButton => _driver.FindElement(By.XPath("//button[text() = 'Weigh']"));
        public IWebElement leftBowlTopLeft => _driver.FindElement(By.Id("left_0"));
        public IWebElement leftBowlTopMiddle => _driver.FindElement(By.Id("left_1"));
        public IWebElement leftBowlTopRight => _driver.FindElement(By.Id("left_2"));
        public IWebElement leftBowMiddleLeft => _driver.FindElement(By.Id("left_3"));
        public IWebElement leftBowMiddle => _driver.FindElement(By.Id("left_4"));
        public IWebElement leftBowlMiddleRight => _driver.FindElement(By.Id("left_5"));
        public IWebElement leftBowlLowerLeft => _driver.FindElement(By.Id("left_6"));
        public IWebElement leftBowlLowerMiddle => _driver.FindElement(By.Id("left_7"));
        public IWebElement leftBowlLowerRight => _driver.FindElement(By.Id("left_8"));
        public IWebElement rightBowlTopLeft => _driver.FindElement(By.Id("right_0"));
        public IWebElement rightBowlTopMiddle => _driver.FindElement(By.Id("right_1"));
        public IWebElement rightBowlTopRight => _driver.FindElement(By.Id("right_2"));
        public IWebElement rightBowlMiddleLeft => _driver.FindElement(By.Id("right_3"));
        public IWebElement rightBowlMiddle => _driver.FindElement(By.Id("right_4"));
        public IWebElement rightBowlMiddleRight => _driver.FindElement(By.Id("right_5"));
        public IWebElement rightBowlLowerLeft => _driver.FindElement(By.Id("right_6"));
        public IWebElement rightBowlLowerMiddle => _driver.FindElement(By.Id("right_7"));
        public IWebElement rightBowlLowerRight => _driver.FindElement(By.Id("right_8"));
    }
}
