using Infra.DataModels;
using Infra.Helpers;
using Infra.Pages;
using NLog;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class TestBase
    {
        protected static ILogger logger =LogManager.GetCurrentClassLogger();
         protected static string baseUrl = @"http://zap.co.il";
    
        //  protected static Dictionary<string, Credentials> loginDict;
           protected static Dictionary<string, ProductsData> productsDict = new Dictionary<string, ProductsData>();


        [OneTimeSetUp]
        public static void oneTimeSetUp()
        {
            BasePage.InitDriver(baseUrl);
            //   string dataFile = @"E:\AutomationProjects\SlavaAutomation2\credentials.json"; 
            //   loginDict = SerializerHelper.DeserializeJsonFile<Dictionary<string, Credentials>>(dataFile);
             string productsFile = @"E:\AutomationProjects\SlavaAutomation2\products.json";
            productsDict = SerializerHelper.DeserializeJsonFile<Dictionary<string, ProductsData>>(productsFile);


        }

        [OneTimeTearDown]
        public static void oneTimeTearDown()
        {
            //        BasePage.CloseDriver();
        }
        [SetUp]
        public void setup()
        {
            BasePage.InitDriver(baseUrl);
        }

        [TearDown]
        public void teardown()
        {
          BasePage.CloseDriver();
        }
    }
}
