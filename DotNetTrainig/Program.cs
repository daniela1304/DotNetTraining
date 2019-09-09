using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DotNetTrainig
{
    class Program
    {
        IWebDriver driver = new ChromeDriver();
        IWebElement elementFromDropDownMenu;
        IWebElement dropdownmenu;



        static void Main()
        {
        }


        [SetUp]
        public void Initialize()
        {
            driver.Navigate().GoToUrl("http://automationpractice.com/index.php");
        }


        [Test]
        public void TestLogoDisplay()
        {
            IWebElement element = driver.FindElement(By.Id("header_logo"));

            if (element.Displayed)
            {
                GreenMessage("Element is displayed");
            }
            else
            {
                RedMessage("Element not found");
            }
            
            // Thread.Sleep(3000);
        }


        [Test]
        public void TestLogin()
        {
            //open Login Page
            driver.Url = "http://automationpractice.com/index.php?controller=authentication&back=my-account";

            //enter username and password
            driver.FindElement(By.Id("email")).SendKeys("dana_tod3@yahoo.com");
            driver.FindElement(By.Id("passwd")).SendKeys("test123456");

            //click login button
            driver.FindElement(By.Id("SubmitLogin")).Click();

            //validate successful login 
            //String username = driver.FindElement(By.XPath("//span[contains(@class,'account')]")).Text;
            String username = driver.FindElement(By.ClassName("account")).FindElement(By.TagName("span")).Text;

            Assert.That(username, Does.Match("Daniela Todescu"));
            // Assert.AreEqual(username, "Daniela Todescu");
        }


      
        [Test]
        public void CheckNumberOfItemsDisplayedBetweenBrackets()
        {
            //open home page
            driver.Url="http://automationpractice.com/index.php";

            //navigate to women products page
            driver.FindElement(By.LinkText("Women")).Click();

            //click Categories checkbox
            driver.FindElement(By.Id("layered_category_4")).Click();

            String numberofelements = driver.FindElement(By.XPath("//*[@id='ul_layered_category_0']/li[1]/label/a/span")).Text;
            GreenMessage(numberofelements);

            List<string> stringList = numberofelements.Split('(', ')').ToList();
            
            for (int i = 0; i < stringList.Count; i++)
            {
                GreenMessage(stringList[0]);
            }

          
        }

        [Test]
        public void CheckSortByElements()
        { 
        //open home page
        driver.Url="http://automationpractice.com/index.php";

            //navigate to women products page
            driver.FindElement(By.LinkText("Women")).Click();

            //click on sort by drop down list
            driver.FindElement(By.Id("selectProductSort")).Click();

            //list elements of the frop down
            for (int i = 1; i<= 8; i++)
            {
                String dropdownelements = "#selectProductSort > option:nth-child(" + i + ")";

                elementFromDropDownMenu = driver.FindElement(By.CssSelector(dropdownelements));

                Console.WriteLine("The " + i + " option from th drop down list is: " + elementFromDropDownMenu.GetAttribute("value"));
            }

        }

        [Test]
        public void FollowOnFacebook()
        {
            driver.Navigate().GoToUrl("http://automationpractice.com/index.php");
      

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.FindElement(By.XPath("//*[@id='social_block']/ul/li[1]/a")).Click();
        }

        [Test]
        public void CheckShopNowButtonOnHomeslider()
        {
            var buttons = driver.FindElements(By.ClassName("homeslider-description"));
            driver.FindElement(By.ClassName("bx-next")).Click();

            foreach ( var button in buttons)
            {
                Assert.IsNotNull(button.FindElement(By.XPath("//*[@id='homeslider']/li[4]/div/p[2]/button")));
            }
        }


        [TearDown]
        public void Cleanup()
        {
            driver.Quit();
        }

        private static void RedMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static void GreenMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}



