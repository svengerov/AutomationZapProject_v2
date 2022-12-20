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
    public class HeadphonesPage : ProductPage
    {
        By filterBtn = By.Id("footerMultiFilterBtn");
        By checkboxes = By.CssSelector("input[role='checkbox']");
        By sortPrice = By.LinkText("מחיר");

           public HeadphonesPage GetInfoByConnectionType(string your_connectionType)
        {            
                List<string> connectionTypeList = new List<string>();
                IWebElement MultipleChoiceconnectionType = driver.FindElements(By.ClassName("MultiSelectionBtn"))[1];
                MultipleChoiceconnectionType.Click();
                locatorService.waitForElement(checkboxes);
                var connectionTypeCheckboxes = driver.FindElements(checkboxes);
               
                    foreach (IWebElement _connectionType in connectionTypeCheckboxes)
                    {
                        connectionTypeList.Add(_connectionType.GetAttribute("data-range-value"));
                    }
                                
                connectionTypeCheckboxes[connectionTypeList.IndexOf(your_connectionType)].Click();                          
                driver.FindElement(filterBtn).Click();
               int amount = Int32.Parse(driver.FindElement(By.ClassName("number")).Text);    //amount of items found 
                IWebElement sortByPrice = driver.FindElement(sortPrice);
                sortByPrice.Click();
                IWebElement firstProductDetails = driver.FindElements(By.ClassName("ComparePricesBtn"))[0];
                firstProductDetails.Click();

               int NumOfShopsByConnectionType = driver.FindElements(By.ClassName("BuyButtons")).Count + driver.FindElements(By.ClassName("SmartBuyButtons")).Count;  //number of shops

            var prices = driver.FindElements(By.ClassName("PriceNum"));
            int minPriceByConnectionType = prices.Select(priceEntry => IntConverter.ConvertToInt(priceEntry.Text)).Min();

            return new HeadphonesPage { productAmountCurrentCompany = amount, priceCurrentCompany = minPriceByConnectionType, numberOfShopsCurrentCompany = NumOfShopsByConnectionType};
        }

    }
}