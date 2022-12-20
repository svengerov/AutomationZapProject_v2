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
    public class DrierPage : ProductPage
    {
        By filterBtn = By.Id("footerMultiFilterBtn");
        By checkboxes = By.CssSelector("input[role='checkbox']");
        By sortPrice = By.LinkText("מחיר");
        public DrierPage GetInfoByCapacity(string your_capacity)
        {   
            List<string> capacityList = new List<string>();
                IWebElement MultipleChoiceCapacity = driver.FindElements(By.ClassName("MultiSelectionBtn"))[2];
                MultipleChoiceCapacity.Click();
                locatorService.waitForElement(checkboxes);
                var capacityCheckboxes = driver.FindElements(checkboxes);
                
                    foreach (IWebElement _capacity in capacityCheckboxes)
                    {
                    capacityList.Add(_capacity.GetAttribute("data-range-value"));
                    }
                
            if (Int32.Parse(your_capacity) < 6) your_capacity = "6";
            else if (Int32.Parse(your_capacity) > 10) your_capacity = "16";
            capacityCheckboxes[capacityList.IndexOf(your_capacity)].Click();

                driver.FindElement(filterBtn).Click();

            int amount = Int32.Parse(driver.FindElement(By.ClassName("number")).Text);    //amount of items found 
                IWebElement sortByPrice = driver.FindElement(sortPrice);
                sortByPrice.Click();
                IWebElement firstProductDetails = driver.FindElements(By.ClassName("ComparePricesBtn"))[0];
                firstProductDetails.Click();

              int shops = driver.FindElements(By.ClassName("BuyButtons")).Count + driver.FindElements(By.ClassName("SmartBuyButtons")).Count;  //number of shops

            var prices = driver.FindElements(By.ClassName("PriceNum"));
            int minPriceByCapacity = prices.Select(priceEntry => IntConverter.ConvertToInt(priceEntry.Text)).Min();
           
             return new DrierPage{ productAmountCurrentCompany = amount, priceCurrentCompany = minPriceByCapacity, numberOfShopsCurrentCompany = shops };
    }

}
}   