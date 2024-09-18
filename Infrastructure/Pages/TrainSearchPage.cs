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
using Infra.Pages;
using OpenQA.Selenium;

namespace Infra
{
    public class TrainSearchPage : BasePage
    {
        By cookiesBtn = By.CssSelector("#cookiesModalId > div:nth-child(2) > button:nth-child(1)");
        By chooseDate = By.CssSelector("#mainScroll > div > div > div > div:nth-child(2) > div > div:nth-child(1) > div:nth-child(4)");

        public string timeOrigin = String.Empty;        
        public string duration = String.Empty;
        public string timeArrival = String.Empty;
        public string platform_origin = String.Empty;
        public string platform_destination = String.Empty;


        public void NavigateTo()
        {
            driver.Navigate().GoToUrl("https://rail.co.il/?page=routePlan&step=origin");
            BasePage.wait();
            driver.FindElement(cookiesBtn).Click();
            BasePage.wait();
        }

        public void ChooseOriginAndDestination(string origin, string destination)
        {
        IReadOnlyCollection<IWebElement> stationLinksOrigin = driver.FindElements(By.TagName("span"));
         
            foreach (var stationLink in stationLinksOrigin)
            {
                String station_name = stationLink.Text.Trim();                
                if (station_name == origin)
                {
                    stationLink.Click();
                    break;
                }
             }
            BasePage.wait();
            IReadOnlyCollection<IWebElement> stationLinksDestination = driver.FindElements(By.TagName("span"));
            foreach (var stationLink in stationLinksDestination)
            {
                String station_name = stationLink.Text.Trim();
                if (station_name == destination)
                {
                    stationLink.Click();
                    return;
                }
            }
            //    IWebElement station_name = (IWebElement)stationLinks.Where(x => x.Text == origin);
            //    string link_text = station_name.Text;

        }

        public void ChooseDateAndTime(string day, string hour, string minutes)
        {
            driver.FindElement(chooseDate).Click();
            IReadOnlyCollection<IWebElement> dates = driver.FindElements(By.ClassName("react-datepicker__day"));
            String dateText;
            foreach (var _date in dates)
            {
                dateText = _date.Text;
                if (dateText == day)
                {
                    _date.Click();
                    break;
                }
            }
            String minutesIndex = ConvertToStringIndex(minutes);
            BasePage.wait();
            driver.FindElement(By.Id($"hours-wheel_{hour}")).Click();
         driver.FindElement(By.Id($"minutes-wheel_{minutesIndex}")).Click();
            BasePage.wait();
            IWebElement submitButton = driver.FindElements(By.TagName("button"))[0];
            submitButton.Click();
            IWebElement submitButton2 = driver.FindElements(By.TagName("button"))[0];
            submitButton2.Click();
            BasePage.wait();
            this.timeOrigin = driver.FindElements(By.ClassName("route-time"))[0].Text;
            this.platform_origin = driver.FindElements(By.ClassName("route-info-text"))[0].Text;
            this.timeArrival = driver.FindElements(By.ClassName("route-time"))[timeOrigin.Length].Text;
            this.platform_destination = driver.FindElements(By.ClassName("route-info-text"))[1].Text;
            this.duration = Convert.ToString(DateTime.Parse(timeArrival) - DateTime.Parse(timeOrigin));
        }

        public TrainSearchPage GetInfo()
        {
            
            return this;
        }

        private String ConvertToStringIndex(string minutes)
        {
            switch(minutes)
            {
                case "00":
                    {
                        return "0";                        
                    }
                case "15":
                    {
                        return "1";
                    }
                case "30":
                    {
                        return "2";                        
                    }
                case "45":
                    {
                        return "3";                        
                    }
                default:
                    return null;                    
            }

        }
    }
}