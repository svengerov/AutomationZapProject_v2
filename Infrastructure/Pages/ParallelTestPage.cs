using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;



namespace Infra.Pages
{
    public class ParallelTestPage : BasePage
    {
 //       [Test]
 //       [Parallelizable]
 //       public void SearchGoogle()
 //       {
 //           driver.Navigate().GoToUrl("http://google.co.il");
 //           driver.FindElement(By.Name("q")).SendKeys("game"+Keys.Enter);
 //           BasePage.wait();
           
 //           BasePage.wait();
 //           BasePage.wait();
 //       }

        public void TakeScreenshot()
        {
            driver.Navigate().GoToUrl("http://twitter.com");
            ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile(DateTime.Now.ToShortDateString()+".jpg",ScreenshotImageFormat.Jpeg);

        }
    }

//    public class ParallelTestPage2 : BasePage
  //  {
    //    [Test]
    //    [Parallelizable]
   //     public void SearchGoogle2()
  //      {
  //          driver.Navigate().GoToUrl("http://google.co.il");
  //          driver.FindElement(By.Name("q")).SendKeys("game2"+Keys.Enter);
  //          BasePage.wait();
        
  //          BasePage.wait();
  //      }
 //   }
}