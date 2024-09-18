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

namespace Infra.Pages
{
    public class LoginPage : BasePage
    {
        static string url = BasePage.baseUrl;
        static string wikiUrl = "https://wikipedia.org/";
        static string user = "0542318422";
        static string pass = "slava140281";

        /*
        public string Login()
                    {
            string actual_title;
            driver.Navigate ().GoToUrl(url);
            actual_title = driver.Title;
            
            return actual_title;

        }

        public void Facebook()
        {
            driver.Navigate().GoToUrl(url);
            driver.FindElement(By.Id("email")).SendKeys(user);
            driver.FindElement(By.Id("pass")).SendKeys(pass);
            driver.FindElement(By.Name("login")).Click();
            List<string> listContacts = new List<string>();
            IReadOnlyCollection<IWebElement> contacts = driver.FindElements(By.ClassName("x193iq5w"));
            foreach (IWebElement contact in contacts)
            {
                if (isOK(contact.Text) == true) 
                {
                    if (contact.Text.Contains("венгеров")) contact.Click();                          

                    listContacts.Add(contact.Text);
                }

            }

        }



        private bool isOK(string text)   //one space only, without numbers and special characters, between 9 and 18 characters, excluding additional combinations.
        {
            if ((text.Length <= 8) || (text.Length > 18)) return false;

            int countSpaces = 0;

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == ' ') countSpaces++;
                if ((int)(text[i])>32 && ((int)(text[i]) < 65)) return false;
            }                                  
            if (countSpaces!=1) return false;

            if (text.Contains("Не ")|| text.Contains("ть ") || text.Contains("оиск ")|| text.Contains(" IQ") || text.Contains ("Прямой")) return false;

            return true;
        }
        */

        /*
        public void Wikipedia()
        {
            driver.Navigate().GoToUrl(wikiUrl);
         //   driver.Manage().Window.Maximize();   //maximize window

            List<string> centralLanguages = new List<string>();
            BasePage.wait();
            IReadOnlyCollection<IWebElement> languages = driver.FindElements(By.ClassName("central-featured-lang"));
            BasePage.wait();
            foreach (IWebElement language in languages)
            {
                BasePage.wait();
                string languageText = language.Text;
               
                    languageText = languageText.Substring(0, languageText.IndexOf('\r'));
                    centralLanguages.Add(languageText);
                
            }
            Console.WriteLine("Total amount of languages: "+centralLanguages.Count);  //10 languages in page
            IWebElement languagesDropdown = driver.FindElement(By.Id("searchLanguage"));
            SelectElement selectLanguage = new SelectElement(languagesDropdown);
            selectLanguage.SelectByText("Deutsch");
            selectLanguage.SelectByValue("en");

            string stop = "";
        }
        
        public void GoogleImages()
        {
            int countImages = 0;
            driver.Navigate().GoToUrl("http://google.com");
            driver.FindElement(By.Name("q")).SendKeys("world"+ Keys.Enter);
      //      driver.FindElement(By.Name("btnK")).Click();
            var images = driver.FindElements(By.ClassName("uhHOwf"));
            foreach (var image in images)
            {
             countImages++;
            }
            Console.WriteLine(countImages);
            images[1].Click();
     //       driver.FindElement(By.ClassName("hdtb-mitem")).Click();
        }
        */

        public void handleDifferentWebElementsTraining(string el)
        {
            if (el == "radio")
            {
                string buttonValue = "";
                driver.Navigate().GoToUrl("http://test.rubywatir.com/radios.php");
                var radioButtons = driver.FindElements(By.Name("likeit"));
                for (int ind = 0; ind < radioButtons.Count(); ind++)
                {
                    radioButtons[ind].Click();
                }


                foreach (var button in radioButtons)                                    //which radiobutton is selected
                {
                    if (button.Selected)
                    {
                        buttonValue = button.GetAttribute("value");
                        driver.Navigate().GoToUrl("http://test.rubywatir.com/form.php");
                        driver.FindElement(By.Name("comments")).SendKeys("  " + buttonValue);
                        BasePage.wait();
                    }
                }

                Console.ReadLine();

            }
            else if (el == "checkbox")
            {

                string boxValue = "";
                driver.Navigate().GoToUrl("http://test.rubywatir.com/checkboxes.php");
                var checkboxes = driver.FindElements(By.Name("sports"));
                for (int ind = 0; ind < checkboxes.Count(); ind++)
                {
                    if ((checkboxes[ind].GetAttribute("value") == "snooker") && (!checkboxes[ind].Selected))
                        checkboxes[ind].Click();
                    else if (checkboxes[ind].Selected)
                    {
                        checkboxes[ind].Click();
                    }
                }


                foreach (var box in checkboxes)                                    //if needed checkbox is selected
                {
                    if (box.Selected)
                    {
                        boxValue = box.GetAttribute("value");
                        driver.Navigate().GoToUrl("http://test.rubywatir.com/form.php");
                        driver.FindElement(By.Name("comments")).SendKeys("  " + boxValue);
                        BasePage.wait();
                    }
                }

                Console.ReadLine();


            }
            else if (el == "select")
            {
                driver.Url = @"file://C:/Temp/selectTest.html";
                var selectDropdown = driver.FindElement(By.Id("select1"));
                var selectOptions = new SelectElement(selectDropdown);
                selectOptions.SelectByText("Test5");
                Console.ReadLine();


            }
            else if (el == "table")
            {
                List<string> tableDataList = new List<string>();
                driver.Navigate().GoToUrl("http://test.rubywatir.com/tables.php");
                //       var tableValue = driver.FindElement(By.XPath("/html/body/div[1]/div[3]/div/div/div[2]/div[3]/table/tbody/tr[2]/td[4]/div"));
                //       string tableText = tableValue.Text;
                var outerTable = driver.FindElement(By.Id("3rdTable"));
                var innerTable = outerTable.FindElement(By.TagName("table"));
                var rows = innerTable.FindElements(By.TagName("td"));

                foreach (var row in rows)
                {
                    string data = row.Text;
                    tableDataList.Add(data);
                }
            }

            else if (el == "links")
            {
                driver.Navigate().GoToUrl("http://test.rubywatir.com/links.php");
                By radiosLink = By.PartialLinkText("wrong");
                By radiosLinkFull = By.LinkText("radios page");
                if (locatorService.isElementPresent(radiosLink))
                {
                    driver.FindElement(By.PartialLinkText("radios")).Click();   //by.LinkText("radios page"))
                }
                else
                {
                    driver.FindElement(By.LinkText("radios page")).Click();
                }
            }

                Console.ReadLine();

            }

        public string getTextFromSite()
        {
            driver.Navigate().GoToUrl("http://test.rubywatir.com/index.php");
            var header1 = driver.FindElement(By.TagName("h1"));
            //*[@id="content"]/div/div/div[2]/p[1]
            string textUnderHeader1 = header1.Text;
            return textUnderHeader1;
        }
           

        }
    }


