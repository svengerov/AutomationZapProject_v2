using Infra.DataModels;
using Infra.Pages;
using Infra.Services;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using static Infra.Pages.BasePage;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using Infra.Helpers;

namespace Tests
{

    [TestFixture]
    public class Tests : TestBase
    {
          
          [Test]
          [TestCase("Laptop", "Lenovo")]

          public void GetZapInfoForProductByCompany(string your_product, string company)
          {
              zapSite.GetLinksCount();
              zapSite.SearchProduct(productsDict[your_product]);
              bool checkTitle = zapSite.IsAt(productsDict[your_product]);
              Assert.IsTrue(checkTitle, $"your title is {ZapPage.getTitle()} and it must be releated to {your_product}");
              logger.Debug($"Got to {ZapPage.getTitle()} Page");
              var productInfo = productPage.GetInfoByCompany(company);
              logger.Debug($"lowest {your_product} price for company = {company} is {productInfo.getLowestPrice()}");
              logger.Debug($"amount of found {your_product}s for company = {company} is {productInfo.getProductAmount()}");
              logger.Debug($"amount of shops found for your {your_product} and company = {company} is {productInfo.getNumberOfShops()}");

          }

        [Test]
        [TestCase("localhost", "TestDB", "INSERT INTO Users (UserName, UserEmail) VALUES (@UserName, @UserEmail);","SELECT * FROM Users;","Test1","Test1@gmail.com")]

        public void SqlAutomationTest(string server_, string db_name,string insert_query,string select_query,string username, string email)
        {
           DBHelper db_connection = new DBHelper(server_, db_name);

            db_connection.InsertData(insert_query,username,email);

            db_connection.ReadData(select_query);
                     
            

        }

    


        /*
          [Test]
          [TestCase("i5")]
          public void GetZapInfoForLaptopByProcessor(string processor)
          {
              const string productName = "Laptop";
              zapSite.SearchProduct(productsDict[productName]);
              bool checkTitle = zapSite.IsAt(productsDict[productName]);
              Assert.IsTrue(checkTitle, $"your title is {ZapPage.getTitle()} and correct title is releated to {productName}");
              logger.Debug($"Got to {ZapPage.getTitle()} Page");
              var productInfoByProcessor = laptopPage.GetInfoByProcessor(processor);
              logger.Debug($"lowest price for {productName} processor = {processor} is {productInfoByProcessor.getLowestPrice()}");
              logger.Debug($"amount of found  {productName} processors = {processor} is {productInfoByProcessor.getProductAmount()}");
              logger.Debug($"amount of shops found for your {productName} and processor = {processor} is {productInfoByProcessor.getNumberOfShops()}");
          }


          [Test]
          [TestCase("USB")]
          public void GetZapInfoForHeadphonesByConnectionType(string connectionType)
          {
              const string productName = "Headphones";
              zapSite.SearchProduct(productsDict[productName]);
              bool checkTitle = zapSite.IsAt(productsDict[productName]);
              Assert.IsTrue(checkTitle, $"your title is {ZapPage.getTitle()} and correct title is releated to {productName}");
              logger.Debug($"Got to {ZapPage.getTitle()} Page");
              var productInfoByConnectionType = headPhonesPage.GetInfoByConnectionType(connectionType);
              logger.Debug($"lowest price for {productName} and connectionType =  {connectionType} is {productInfoByConnectionType.getLowestPrice()}");
              logger.Debug($"amount of found {productName} for connectionType = {connectionType} is {productInfoByConnectionType.getProductAmount()}");
              logger.Debug($"amount of shops found for your {productName} and connectionType = {connectionType} is {productInfoByConnectionType.getNumberOfShops()}");
          }


          [Test]
          [TestCase("6")]
          public void GetZapInfoForDrierByCapacity(string capacityKg)
          {
              const string productName = "Drier";
              zapSite.SearchProduct(productsDict[productName]);
              bool checkTitle = zapSite.IsAt(productsDict[productName]);
              Assert.IsTrue(checkTitle, $"your title is {ZapPage.getTitle()} and correct title is releated to {productName}");
              logger.Debug($"Got to {ZapPage.getTitle()} Page");
              var productInfoByCapacity = drierPage.GetInfoByCapacity(capacityKg);
              logger.Debug($"lowest price for {productName} and capacity = {capacityKg} is {productInfoByCapacity.getLowestPrice()}");
              logger.Debug($"amount of found {productName} for capacity = {capacityKg} is {productInfoByCapacity.getProductAmount()}");
              logger.Debug($"amount of shops found for your {productName} and capacity = {capacityKg} is {productInfoByCapacity.getNumberOfShops()}");
          }
      

        [Test]
        [TestCase("נתניה","תל אביב - השלום","13","20","45")]

        public void TrainInfoByTimeAndDestinations(string origin, string destination, string day, string hour,string minutes)
        {
            Pages.trainSearchPage.NavigateTo();
            Pages.trainSearchPage.ChooseOriginAndDestination(origin, destination);
            Pages.trainSearchPage.ChooseDateAndTime(day, hour,minutes);
            Pages.trainSearchPage.GetInfo();

            String Info = $"Train is exiting {origin} station on platform {Pages.trainSearchPage.platform_origin} at time: {Pages.trainSearchPage.timeOrigin}";
            Info += "\n";
            Info += $"The duration of your ride is {Pages.trainSearchPage.duration} and you're arriving at time: {Pages.trainSearchPage.timeArrival} to platform: {Pages.trainSearchPage.platform_destination}"; 
            string path = @"TestTextFile.txt";                      
            File.WriteAllText(path, Info);
            Console.ReadLine();
           
        }
        */


        /*

            [Test]
            [TestCase("Laptop", "HP", "Lenovo")]

            public void GetComparingResultsForProductsByCompanies(string your_product, string firstCompany, string companyToCompare)
            {
                zapSite.SearchProduct(productsDict[your_product]);
                bool checkTitle = zapSite.IsAt(productsDict[your_product]);
                Assert.IsTrue(checkTitle, $"your title is {ZapPage.getTitle()} and must be related to {your_product}");
                var productInfoFirstCompany = productPage.GetInfoByCompany(firstCompany);
                zapSite.SearchProduct(productsDict[your_product]);
                var productInfoCompareCompany = productPage.GetInfoByCompany(companyToCompare);
                logger.Debug($"lowest {your_product} price for company = {firstCompany} is {productInfoFirstCompany.getLowestPrice()}");
                logger.Debug($"lowest {your_product} price for company = {companyToCompare} is {productInfoCompareCompany.getLowestPrice()}");
                if (productInfoFirstCompany.getLowestPrice() >= productInfoCompareCompany.getLowestPrice())
                {
                    logger.Debug($"{firstCompany} price is more than {companyToCompare} price, the difference is {productInfoFirstCompany.getLowestPrice() - productInfoCompareCompany.getLowestPrice()}");
                }
                else
                {
                    logger.Debug($"{firstCompany} price is less than {companyToCompare} price, the difference is {productInfoCompareCompany.getLowestPrice() - productInfoFirstCompany.getLowestPrice()}");
                }
                logger.Debug($"amount of found {your_product} for company = {firstCompany} is {productInfoFirstCompany.getProductAmount()}");
                logger.Debug($"amount of found {your_product} for company = {companyToCompare} is {productInfoCompareCompany.getProductAmount()}");
                if (productInfoFirstCompany.getProductAmount() >= productInfoCompareCompany.getProductAmount())
                {
                    logger.Debug($"{firstCompany} product amount is more than {companyToCompare} product amount, the difference is {productInfoFirstCompany.getProductAmount() - productInfoCompareCompany.getProductAmount()}");
                }
                else
                {
                    logger.Debug($"{firstCompany} product amount is less than {companyToCompare} product amount, the difference is {productInfoCompareCompany.getProductAmount() - productInfoFirstCompany.getProductAmount()}");
                }
                logger.Debug($"amount of shops found for your {your_product} and company = {firstCompany} is {productInfoFirstCompany.getNumberOfShops()}");
                logger.Debug($"amount of shops found for your {your_product} and company = {companyToCompare} is {productInfoCompareCompany.getNumberOfShops()}");
                if (productInfoFirstCompany.getNumberOfShops() >= productInfoCompareCompany.getNumberOfShops())
                {
                    logger.Debug($"{firstCompany} shops number is more than {companyToCompare} shops number, the difference is {productInfoFirstCompany.getNumberOfShops() - productInfoCompareCompany.getNumberOfShops()}");
                }
                else
                {
                    logger.Debug($"{firstCompany} shops number is less than {companyToCompare} shops number, the difference is {productInfoCompareCompany.getNumberOfShops() - productInfoFirstCompany.getNumberOfShops()}");
                }
            }

            [Test]
            [TestCase("1,000", "8,000")]

            public void GetComparingPricesForHDDBySize(string firstSize, string secondSize)
            {
                int firstHdd = IntConverter.ConvertToInt(firstSize);
                int secondHdd = IntConverter.ConvertToInt(secondSize);
                zapSite.SearchProduct(productsDict["HDD"]);
                bool checkTitle = zapSite.IsAt(productsDict["HDD"]);            
                Assert.IsTrue(checkTitle, $"your title is {ZapPage.getTitle()} and must be related to HDD");
                var firstHddInfoBySize = harddiskPage.GetInfoBySize(firstSize);
                zapSite.SearchProduct(productsDict["HDD"]);            
                var secondHddInfoBySize = harddiskPage.GetInfoBySize(secondSize);
                logger.Debug($"Got to {ZapPage.getTitle()} Page");            
                logger.Debug($"lowest price for HDD and size = {firstHdd} is {firstHddInfoBySize.getLowestPrice()}");
                logger.Debug($"lowest price for HDD and size = {secondHdd} is {secondHddInfoBySize.getLowestPrice()}");
                if (firstHdd < secondHdd)
                {
                    Assert.Greater((firstHddInfoBySize.getLowestPrice() * 1000) / firstHdd, (secondHddInfoBySize.getLowestPrice() * 1000) / secondHdd,"Price for 1 GB is more when HDD size is more and it is incorrect!");
                        }
                else
                {
                    Assert.Less((firstHddInfoBySize.getLowestPrice() * 1000) / firstHdd, (secondHddInfoBySize.getLowestPrice() * 1000) / secondHdd, "Price for 1 GB is more when HDD size is more and it is incorrect!");
                }
                logger.Debug($"Price for 1 TB when size = {firstHdd} is {(firstHddInfoBySize.getLowestPrice() * 1000)                                                                                                                                                                                                                                                                                                                            / firstHdd}, Price for 1 TB when size = {secondHdd} is {(secondHddInfoBySize.getLowestPrice() * 1000) / secondHdd}");
            }
        */

       
    }

    }






