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
    public class HddPage : ProductPage
    {
        By filterBtn = By.Id("footerMultiFilterBtn");
        By checkboxes = By.CssSelector("input[role='checkbox']");
        By sortPrice = By.LinkText("מחיר");
        public HddPage GetInfoBySize(string hdd_size)
        {
            List<string> hddList = new List<string>();
            IWebElement MultipleChoiceHddSize = driver.FindElements(By.ClassName("MultiSelectionBtn"))[2];
            MultipleChoiceHddSize.Click();
            locatorService.waitForElement(checkboxes);
            var hddCheckboxes = driver.FindElements(checkboxes);
           
                foreach (IWebElement _hddSizeEntry in hddCheckboxes)
                {
                hddList.Add(_hddSizeEntry.GetAttribute("data-range-value"));
                }
            
           for (int i = 0; i < hddList.Count; i++)
            {
                if (hddList[i].Contains(hdd_size))
                {
                    hddCheckboxes[i].Click();
                    break;
                }
            }
                      
            driver.FindElement(By.ClassName("SanenBtn")).Click();

          int  amountBySize = Int32.Parse(driver.FindElement(By.ClassName("number")).Text);    //amount of items found 
     
            IWebElement sortByPrice = driver.FindElement(sortPrice);
            sortByPrice.Click();
            IWebElement firstProductDetails = driver.FindElements(By.ClassName("ComparePricesBtn"))[0];
            firstProductDetails.Click();

          int numberOfShopsBySize = driver.FindElements(By.ClassName("BuyBtnText")).Count;  //number of shops

            var prices = driver.FindElements(By.ClassName("PriceNum"));
            int minPriceBySize = prices.Select(priceEntry => IntConverter.ConvertToInt(priceEntry.Text)).Min();

            return new HddPage { productAmountCurrentCompany = amountBySize, priceCurrentCompany = minPriceBySize, numberOfShopsCurrentCompany = numberOfShopsBySize }; 

        }
    }
}