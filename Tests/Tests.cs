using Infra.DataModels;
using Infra.Pages;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using static Infra.Pages.BasePage;


namespace Tests
{
    [TestFixture]
    public class Tests : TestBase
    {
        
        [Test]
        [TestCase("Laptop", "Lenovo")]
        [TestCase("Drier", "Samsung")]
        public void GetZapInfoForProductByCompany(string your_product, string company)
        {
            Pages.zapPage.SearchProduct(productsDict[your_product]);
            bool checkTitle = Pages.zapPage.IsAt(productsDict[your_product]);
            Assert.IsTrue(checkTitle, $"your title must be releated to {your_product}");
            logger.Debug($"Got to {your_product} Page");
            var productInfo = Pages.productPage.GetInfoByCompany(company);
            logger.Debug($"lowest {your_product} price for company = {company} is {productInfo.getLowestPrice}");
            logger.Debug($"amount of found {your_product}s for company = {company} is {productInfo.getProductAmount}");
            logger.Debug($"amount of shops found for your {your_product} and company = {company} is {productInfo.getNumberOfShops}");
        }
        
        
        [Test]
        [TestCase("i5")]
        public void GetZapInfoForLaptopByProcessor(string processor)
        {
            const string productName = "Laptop";
            Pages.zapPage.SearchProduct(productsDict[productName]);
            bool checkTitle = Pages.zapPage.IsAt(productsDict[productName]);
            Assert.IsTrue(checkTitle, $"your title is {productsDict[productName]} and correct title is releated to {productName}");
            logger.Debug($"Got to Laptop Page");
            var productInfoByProcessor = Pages.laptopPage.GetInfoByProcessor(processor);
            logger.Debug($"lowest price for {productName} processor = {processor} is {productInfoByProcessor.getLowestPrice}");
            logger.Debug($"amount of found  {productName} processors = {processor} is {productInfoByProcessor.getProductAmount}");
            logger.Debug($"amount of shops found for your {productName} and processor = {processor} is {productInfoByProcessor.getNumberOfShops}");
        }
        

        [Test]
        [TestCase("USB")]
        public void GetZapInfoForHeadphonesByConnectionType(string connectionType)
        {
            const string productName = "Headphones";
            Pages.zapPage.SearchProduct(productsDict[productName]);
            bool checkTitle = Pages.zapPage.IsAt(productsDict[productName]);
            Assert.IsTrue(checkTitle, $"your title is {productsDict[productName]} and correct title is releated to {productName}");
            logger.Debug($"Got to {productName} Page");
            var productInfoByConnectionType = Pages.headphonesPage.GetInfoByConnectionType(connectionType);
            logger.Debug($"lowest price for {productName} and connectionType =  {connectionType} is {productInfoByConnectionType.getLowestPrice}");
            logger.Debug($"amount of found {productName} for connectionType = {connectionType} is {productInfoByConnectionType.getProductAmount}");
            logger.Debug($"amount of shops found for your {productName} and connectionType = {connectionType} is {productInfoByConnectionType.getNumberOfShops}");
        }
        
        
        [Test]
        [TestCase("6")]
        public void GetZapInfoForDrierByCapacity(string capacityKg)
        {
            const string productName = "Drier";
            Pages.zapPage.SearchProduct(productsDict[productName]);
            bool checkTitle = Pages.zapPage.IsAt(productsDict[productName]);
            Assert.IsTrue(checkTitle, $"your title is {productsDict[productName]} and correct title is releated to {productName}");
            logger.Debug($"Got to {productName} Page");
            var productInfoByCapacity = Pages.drierPage.GetInfoByCapacity(capacityKg);
            logger.Debug($"lowest price for {productName} and capacity = {capacityKg} is {productInfoByCapacity.getLowestPrice}");
            logger.Debug($"amount of found {productName} for capacity = {capacityKg} is {productInfoByCapacity.getProductAmount}");
            logger.Debug($"amount of shops found for your {productName} and capacity = {capacityKg} is {productInfoByCapacity.getNumberOfShops}");
        }
        
        
        [Test]
        [TestCase("700")]
        public void GetZapInfoForTelescopesByRange(string telRange)
        {
            const string productName = "Telescopes";
            Pages.zapPage.SearchProduct(productsDict[productName]);
            bool checkTitle = Pages.zapPage.IsAt(productsDict[productName]);
            Assert.IsTrue(checkTitle, $"your title is {productsDict[productName]} and correct title is related to {productName}");
            logger.Debug($"Got to {productName} Page");
            var productInfoByRange = Pages.telescopesPage.GetInfoByRange(telRange);
            logger.Debug($"lowest price for {productName} and range = {telRange} is {productInfoByRange.getLowestPrice}");
            logger.Debug($"amount of found {productName} for range = {telRange} is {productInfoByRange.getProductAmount}");
            logger.Debug($"amount of shops found for your {productName} and range = {telRange} is {productInfoByRange.getNumberOfShops}");
        }
        
        

        [Test]
        [TestCase("Laptop", "HP", "Lenovo")]

        public void GetComparingResultsForProductsByCompanies(string your_product, string firstCompany, string companyToCompare)
        {
            Pages.zapPage.SearchProduct(productsDict[your_product]);
            bool checkTitle = Pages.zapPage.IsAt(productsDict[your_product]);
            Assert.IsTrue(checkTitle, $"your title is {checkTitle} and must be {your_product}");
            var productInfoFirstCompany = Pages.productPage.GetInfoByCompany(firstCompany);
            Pages.zapPage.SearchProduct(productsDict[your_product]);
            var productInfoCompareCompany = Pages.productPage.GetInfoByCompany(companyToCompare);
            logger.Debug($"lowest {your_product} price for company = {firstCompany} is {productInfoFirstCompany.getLowestPrice}");
            logger.Debug($"lowest {your_product} price for company = {companyToCompare} is {productInfoCompareCompany.getLowestPrice}");
            if (productInfoFirstCompany.getLowestPrice() >= productInfoCompareCompany.getLowestPrice())
            {
                logger.Debug($"{firstCompany} price is more than {companyToCompare} price, the difference is {productInfoFirstCompany.getLowestPrice() - productInfoCompareCompany.getLowestPrice()}");
                    }
            else
            {
                logger.Debug($"{firstCompany} price is less than {companyToCompare} price, the difference is {productInfoCompareCompany.getLowestPrice() - productInfoFirstCompany.getLowestPrice()}");
            }
            logger.Debug($"amount of found {your_product} for company = {firstCompany} is {productInfoFirstCompany.getProductAmount}");
            logger.Debug($"amount of found {your_product} for company = {companyToCompare} is {productInfoCompareCompany.getProductAmount}");
            if (productInfoFirstCompany.getProductAmount() >= productInfoCompareCompany.getProductAmount())
            {
                logger.Debug($"{firstCompany} product amount is more than {companyToCompare} product amount, the difference is {productInfoFirstCompany.getProductAmount() - productInfoCompareCompany.getProductAmount()}");
            }
            else
            {
                logger.Debug($"{firstCompany} product amount is less than {companyToCompare} product amount, the difference is {productInfoCompareCompany.getProductAmount() - productInfoFirstCompany.getProductAmount()}");
            }
            logger.Debug($"amount of shops found for your {your_product} and company = {firstCompany} is {productInfoFirstCompany.getNumberOfShops}");
            logger.Debug($"amount of shops found for your {your_product} and company = {companyToCompare} is {productInfoCompareCompany.getNumberOfShops}");
            if (productInfoFirstCompany.getNumberOfShops() >= productInfoCompareCompany.getNumberOfShops())
            {
                logger.Debug($"{firstCompany} shops number is more than {companyToCompare} shops number, the difference is {productInfoFirstCompany.getNumberOfShops() - productInfoCompareCompany.getNumberOfShops()}");
            }
            else
            {
                logger.Debug($"{firstCompany} shops number is less than {companyToCompare} shops number, the difference is {productInfoCompareCompany.getNumberOfShops() - productInfoFirstCompany.getNumberOfShops()}");
            }
        }
       
    }
}

