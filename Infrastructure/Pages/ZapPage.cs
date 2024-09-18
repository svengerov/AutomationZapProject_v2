using Infra.DataModels;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using Infra.Helpers;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Infra.Pages
{
    public class ZapPage : BasePage
    {
             static string zapUrl = BasePage.baseUrl;
       
        public  bool IsAt(ProductsData your_product_data)
        {          
            return driver.Title.Contains(your_product_data.nameHebrewProduct);
        }

        public void GetLinksCount()
        {
            List<string> links = new List<string>();
            var currentTitle="";
            var anotherTitle = "";
            
            driver.Navigate().GoToUrl(zapUrl);
            IWebElement zapFooter = driver.FindElement(By.Id("uc_Footer_footer"));
            int countLinksFooter = zapFooter.FindElements(By.TagName("a")).Count();
            IWebElement first_section_in_footer = driver.FindElement(By.XPath("//*[@id='sectionFooter']/div[1]"));
            int countLinksSection = first_section_in_footer.FindElements(By.TagName("a")).Count();
            for (int i = 0; i < countLinksSection; i++)
            {
                var currentLink = first_section_in_footer.FindElements(By.TagName("a"))[i];
                links.Add( currentLink.Text);
                if(currentLink.Text.Contains("יצירת קשר"))
                {
                     currentTitle = driver.Title;
                    currentLink.Click();
                    break;
                }
            }
             anotherTitle = driver.Title;
            IWebElement nameField = driver.FindElement(By.Name("fullName"));
            Assert.AreNotEqual(currentTitle, anotherTitle,$"current title = {currentTitle} and anotherTitle={anotherTitle}");
            if ((currentTitle!=anotherTitle)&&(nameField.Displayed))
                {
                bool accepted = true;
            }
            
        }

        public void SearchProduct(ProductsData your_product_data)
        {
            driver.Navigate().GoToUrl(zapUrl);
            if ((your_product_data.nameHebrewProduct == null)||(your_product_data.nameHebrewCategory ==null))
            {
                throw new NoSuchElementException("No such product!");
            }
            else
            {
                driver.FindElement(By.LinkText(your_product_data.nameHebrewCategory)).Click();
                driver.FindElement(By.LinkText(your_product_data.nameHebrewProduct)).Click();
            }
        }

        public static string getTitle()
        {
            return driver.Title;
        }
    }
}