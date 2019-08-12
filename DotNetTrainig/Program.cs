using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DotNetTrainig
{
    public class Program
    {
        
     
        static void Main()
        {
            IWebDriver driver;

            driver = new ChromeDriver();

            driver.Navigate().GoToUrl("http://automationpractice.com/index.php");
            
           Thread.Sleep(3000);

            driver.Quit();

        }

    }
}
