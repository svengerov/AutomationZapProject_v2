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
    public class LaptopPage : ProductPage
    {
        By filterBtn = By.Id("footerMultiFilterBtn");
        By checkboxes = By.CssSelector("input[role='checkbox']");
        By sortPrice = By.LinkText("מחיר");
        public LaptopPage GetInfoByProcessor(string your_processor)
        {
            List<string> processorList = new List<string>();
            IWebElement MultipleChoiceprocessor = driver.FindElements(By.ClassName("MultiSelectionBtn"))[3];
            MultipleChoiceprocessor.Click();
            locatorService.waitForElement(checkboxes);
            var processorCheckboxes = driver.FindElements(checkboxes);
           
                foreach (IWebElement _processor in processorCheckboxes)
                {
                    processorList.Add(_processor.GetAttribute("data-range-value"));
                }
            
           for (int i = 0; i < processorList.Count; i++)
            {
                if (processorList[i].Contains(your_processor))
                {
                    processorCheckboxes[i].Click();
                    break;
                }
            }
                      
            driver.FindElement(filterBtn).Click();

          int  amountByProcessor = Int32.Parse(driver.FindElement(By.ClassName("number")).Text);    //amount of items found 
     
            IWebElement sortByPrice = driver.FindElement(sortPrice);
            sortByPrice.Click();
            IWebElement firstProductDetails = driver.FindElements(By.ClassName("ComparePricesBtn"))[0];
            firstProductDetails.Click();

          int numberOfShopsByProcessor = driver.FindElements(By.ClassName("BuyBtnText")).Count;  //number of shops

            var prices = driver.FindElements(By.ClassName("PriceNum"));
            int minPriceByProcessor = prices.Select(priceEntry => IntConverter.ConvertToInt(priceEntry.Text)).Min();

            return new LaptopPage { productAmountCurrentCompany = amountByProcessor, priceCurrentCompany = minPriceByProcessor, numberOfShopsCurrentCompany = numberOfShopsByProcessor }; 

        }
    }
}