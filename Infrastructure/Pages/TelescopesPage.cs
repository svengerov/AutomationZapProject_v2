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
using Infra.Services;

namespace Infra.Pages
{
    public class TelescopesPage : ProductPage
    {
        By filterBtn = By.Id("footerMultiFilterBtn");
        By checkboxes = By.CssSelector("input[role='checkbox']");
        By sortPrice = By.LinkText("מחיר");
        public TelescopesPage GetInfoByRange(string your_telRange)
        {
            int index;
            IWebElement MultipleChoicetelRange = driver.FindElements(By.ClassName("MultiSelectionBtn"))[2];
            MultipleChoicetelRange.Click();
            locatorService.waitForElement(checkboxes);
            var telRangeCheckboxes = driver.FindElements(checkboxes);

            if (Int32.Parse(your_telRange)>600)
            {
                telRangeCheckboxes[3].Click();
            }
               
            else 
            {
                index = Int32.Parse(your_telRange) / 200;
                telRangeCheckboxes[index].Click();
            }
           
            driver.FindElement(filterBtn).Click();

           int amountByRange = Int32.Parse(driver.FindElement(By.ClassName("number")).Text);    //amount of items found 
          
            IWebElement sortByPrice = driver.FindElement(sortPrice);
            sortByPrice.Click();
            IWebElement firstProductDetails = driver.FindElements(By.ClassName("ComparePricesBtn"))[0];
            firstProductDetails.Click();

           int shopsByRange = driver.FindElements(By.ClassName("BuyButtons")).Count + driver.FindElements(By.ClassName("SmartBuyButtons")).Count;  //number of shops

            var prices = driver.FindElements(By.ClassName("PriceNum"));
            int minPriceByRange = prices.Select(priceEntry => IntConverter.ConvertToInt(priceEntry.Text)).Min();
          
            return new TelescopesPage { productAmountCurrentCompany = amountByRange, priceCurrentCompany = minPriceByRange, numberOfShopsCurrentCompany = shopsByRange }; 

        }
    }
}