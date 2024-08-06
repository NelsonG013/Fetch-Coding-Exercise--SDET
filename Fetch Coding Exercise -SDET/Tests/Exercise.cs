using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace Fetch_Coding_Exercise__SDET.Tests
{
    [TestFixture]
    public class GoldBarTests : PageInitializer
    {
        private List<(int[], int[], string)> weighings;

        [SetUp]
        public new void SetUp()
        {
            //base.InitScript(); // Initialize WebDriver and navigate to the URL
            weighings = new List<(int[], int[], string)>();
        }

        [TearDown]
        public new void TearDown()
        {
            base.CleanUp(); // Quit WebDriver
        }

        [Test]
        public void FindFakeBar()
        {
            var (fakeBar, alertMessage) = FindFakeBarInternal();

            // Validate the result
            ClassicAssert.AreEqual("Yay! You find it!", alertMessage);

            Console.WriteLine($"Fake Bar: {fakeBar}");
            Console.WriteLine($"Message: {alertMessage}");
            Console.WriteLine("Weighings");
            foreach (var weighing in weighings)
            {
                Console.WriteLine($"{string.Join(",", weighing.Item1)} vs {string.Join(",", weighing.Item2)}: {weighing.Item3}");
            }
        }

        private (int, string) FindFakeBarInternal()
        {
            int[] group1 = { 0, 1, 2 };
            int[] group2 = { 3, 4, 5 };
            int[] group3 = { 6, 7, 8 };

            WeighBars(group1, group2);
            int[] fakeGroup;
            string result = weighings[^1].Item3;

            Console.WriteLine($"Weighing result for group1 vs group2: {result}");

            if (result.Contains('='))
            {
                fakeGroup = group3;
            }
            else if (result.Contains('>'))
            {
                fakeGroup = group1;
            }
            else if (result.Contains('<'))
            {
                fakeGroup = group2;
            }
            else
            {
                throw new Exception($"Unexpected result: {result}");
            }

            int[] groupA = { fakeGroup[0], fakeGroup[1] };
            int[] groupB = { fakeGroup[2] };

            WeighBars(groupA, groupB);
            result = weighings[^1].Item3;
            Console.WriteLine($"Weighing result for groupA vs groupB: {result}");

            int fakeBar;

            if (result.Contains('='))
            {
                fakeBar = fakeGroup[2];
            }
            else if (result.Contains('>'))
            {
                fakeBar = fakeGroup[0];
            }
            else if (result.Contains('<'))
            {
                fakeBar = fakeGroup[1];
            }
            else
            {
                throw new Exception($"Unexpected result: {result}");
            }

            _driver.FindElement(By.Id($"coin_{fakeBar}")).Click();
            IAlert alert = _driver.SwitchTo().Alert();
            string alertMessage = alert.Text;
            alert.Accept();

            Console.WriteLine($"Alert message: {alertMessage}");

            return (fakeBar, alertMessage);
        }

        private void WeighBars(int[] leftBars, int[] rightBars)
        {
            // Clear previous entries
            ClearBowl(home.leftBowlTopLeft, home.leftBowlTopMiddle, home.leftBowlTopRight, home.leftBowMiddleLeft, home.leftBowMiddle, home.leftBowlMiddleRight, home.leftBowlLowerLeft, home.leftBowlLowerMiddle, home.leftBowlLowerRight);
            ClearBowl(home.rightBowlTopLeft, home.rightBowlTopMiddle, home.rightBowlTopRight, home.rightBowlMiddleLeft, home.rightBowlMiddle, home.rightBowlMiddleRight, home.rightBowlLowerLeft, home.rightBowlLowerMiddle, home.rightBowlLowerRight);

            FillBowl(new IWebElement[] {
                home.leftBowlTopLeft,
                home.leftBowlTopMiddle,
                home.leftBowlTopRight,
                home.leftBowMiddleLeft,
                home.leftBowMiddle,
                home.leftBowlMiddleRight,
                home.leftBowlLowerLeft,
                home.leftBowlLowerMiddle,
                home.leftBowlLowerRight
            }, leftBars);

            // Fill right bowl
            FillBowl(new IWebElement[] {
                home.rightBowlTopLeft,
                home.rightBowlTopMiddle,
                home.rightBowlTopRight,
                home.rightBowlMiddleLeft,
                home.rightBowlMiddle,
                home.rightBowlMiddleRight,
                home.rightBowlLowerLeft,
                home.rightBowlLowerMiddle,
                home.rightBowlLowerRight
            }, rightBars);

            // Weigh and capture result
            home.weighButton.Click();
            Thread.Sleep(2000); // Wait for weighing to complete

            string result = _driver.FindElement(By.XPath("//*[@id='reset']//preceding::button[@class = 'button']")).Text;
            weighings.Add((leftBars, rightBars, result));

            Console.WriteLine($"Weighing result: {result}");

            // Reset for the next weighing
            home.resetButton.Click();
        }

        private void ClearBowl(params IWebElement[] elements)
        {
            foreach (var element in elements)
            {
                element.Clear();
            }
        }

        private void FillBowl(IWebElement[] bowlElements, int[] barNumbers)
        {
            for (int i = 0; i < barNumbers.Length; i++)
            {
                if (i < bowlElements.Length) // Ensure we do not go out of bounds
                {
                    bowlElements[i].SendKeys(barNumbers[i].ToString());
                }
            }
        }
    }
}