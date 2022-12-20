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
    }
}