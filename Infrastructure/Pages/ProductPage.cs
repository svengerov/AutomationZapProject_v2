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
    public class ProductPage : BasePage
    {
        List<string> companiesList = new List<string>();

        protected int priceCurrentCompany;
        protected int productAmountCurrentCompany;
        protected int numberOfShopsCurrentCompany;

        By filterBtn = By.Id("footerMultiFilterBtn");
        By checkboxes = By.CssSelector("input[role='checkbox']");
        By sortPrice = By.LinkText("מחיר");
        public ProductPage GetInfoByCompany(string your_company)
        {
            IWebElement MultipleChoice = driver.FindElements(By.ClassName("MultiSelectionBtn"))[0];
            MultipleChoice.Click();
            locatorService.waitForElement(checkboxes);
            var companiesCheckboxes = driver.FindElements(checkboxes);            
           
                foreach (IWebElement _company in companiesCheckboxes)
                {                    
                    companiesList.Add(_company.GetAttribute("data-range-value"));
                }
                        
            companiesCheckboxes[companiesList.IndexOf(your_company)].Click();
            
                driver.FindElement(filterBtn).Click();

          int productAmount = Int32.Parse(driver.FindElement(By.ClassName("number")).Text);    //amount of items found 
               
                IWebElement sortByPrice = driver.FindElement(sortPrice);
                sortByPrice.Click();


            IWebElement firstProductDetails = driver.FindElements(By.ClassName("ComparePricesBtn"))[0];
            firstProductDetails.Click();

            
            int numberOfShops = driver.FindElements(By.ClassName("BuyBtn")).Count;
 
              var prices = driver.FindElements(By.ClassName("PriceNum"));
             int minPrice = prices.Select(priceEntry=>IntConverter.ConvertToInt(priceEntry.Text)).Min();
         
            return new ProductPage { productAmountCurrentCompany = productAmount, priceCurrentCompany = minPrice, numberOfShopsCurrentCompany = numberOfShops  };
        }
    
        public int getLowestPrice()
        {
            return priceCurrentCompany;
        }

        public int getProductAmount()
        {
            return productAmountCurrentCompany;
        }

        public int getNumberOfShops()
        {
            return numberOfShopsCurrentCompany;
        }

    }
}