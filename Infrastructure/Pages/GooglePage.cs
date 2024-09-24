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
using System.Xml.Linq;

namespace Infra.Pages
{
    public class GooglePage : BasePage
    {
             public string googleUrl = BasePage.googleUrl;
       
              public double SearchCurrencyInfo(int originCurrencyAmount, string originCurrency, string targetCurrency)
        {
            driver.Navigate().GoToUrl(googleUrl);
            var searchPanel =   driver.FindElement(By.Id("APjFqb"));// google search panel
            searchPanel.SendKeys($"{originCurrencyAmount} {originCurrency} to {targetCurrency}");
            searchPanel.SendKeys(Keys.Enter);
            var targetCurrencyAmountField = driver.FindElement(By.ClassName("a61j6"));
            string targetCurrencyAmountInfo = targetCurrencyAmountField.GetAttribute("value");
            double targetCurrencyAmount = Convert.ToDouble(Helpers.Converter.ConvertFromStringWithComma(targetCurrencyAmountInfo), CultureInfo.InvariantCulture);

            return targetCurrencyAmount;
            
        }

        public static string getTitle()
        {
            return driver.Title;
        }
    }
}