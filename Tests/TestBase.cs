using Infra.DataModels;
using Infra.Helpers;
using Infra.Pages;
using Microsoft.Data.SqlClient;
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
        protected static string googleUrl = @"http://google.com";
        protected ZapPage zapSite => Pages.zapPage;

        protected GooglePage googlePage => Pages.googlePage;
        protected DrierPage drierPage => Pages.drierPage;
        protected HddPage harddiskPage => Pages.hddPage;
        protected HeadphonesPage headPhonesPage => Pages.headphonesPage;
        protected LaptopPage laptopPage => Pages.laptopPage;
        protected TelescopesPage telescopesPage => Pages.telescopesPage;
        protected ProductPage productPage => Pages.productPage;

        public static SqlConnection db_connection;
        private static string dbServer;
        private static string dbName;

        protected static Dictionary<string, ProductsData> productsDict = new Dictionary<string, ProductsData>();


        [OneTimeSetUp]
        public static void oneTimeSetUp()
        {
            BasePage.InitDriver(baseUrl,googleUrl);
            string configFilePath = "DatabaseParameters.txt";
            var configLines = File.ReadAllLines(configFilePath);

            dbServer = configLines[0].Trim();  
            dbName = configLines[1].Trim();  

            db_connection = new SqlConnection($@"Server={dbServer};Database={dbName};Trusted_Connection=True;TrustServerCertificate=True;");

            try
            {
                   // Open the connection
                    db_connection.Open();              
            }
            catch (Exception ex )
                {
                Console.WriteLine("Error inserting data: " + ex.Message);
            }
               string dataFile = @"E:\AutomationProjects\SlavaAutomation2\credentials.json";             
              string productsFile = @"E:\AutomationProjects\SlavaAutomation2\products.json";
              productsDict = SerializerHelper.DeserializeJsonFile<Dictionary<string, ProductsData>>(productsFile);
        }

        [OneTimeTearDown]
        public static void oneTimeTearDown()
        {
            try
            {
                db_connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error inserting data: " + ex.Message);
            }
            BasePage.CloseDriver();
        }
        [SetUp]
        public void setup()
        {
            BasePage.InitDriver(baseUrl,googleUrl);
        }

        [TearDown]
        public void teardown()
        {
            if (TestContext.CurrentContext.Result.FailCount > 0)
                logger.Debug(TestContext.CurrentContext.Result.Message);
            BasePage.CloseDriver();
        }
    }
}
