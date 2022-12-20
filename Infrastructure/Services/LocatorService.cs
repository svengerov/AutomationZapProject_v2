using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Services
{
    public class LocatorService
    {
        private IWebDriver driver;
        public LocatorService(IWebDriver _driver)
        {
            this.driver = _driver;
        }
        public IWebElement findByTagContainingText(string tag, string text, int waitSec = 30)
        {
            By locator = By.XPath("//" + tag + "[contains(text(), '" + text + "')]");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(waitSec));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(locator));
            return driver.FindElement(locator);
        }

        public IWebElement waitForElement(By locator, int waitSec = 30)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(waitSec));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(locator));
            return driver.FindElement(locator);
        }
        public bool isElementPresent(By locator)
        {
            try
            {
                driver.FindElement(locator);
                return true;
            }
            catch (NoSuchElementException nse)
            {
                return false;
            }
        }

    }
}
