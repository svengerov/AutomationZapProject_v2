using Infra.DataModels;
using Infra.Pages;
using Infra.Services;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using static Infra.Pages.BasePage;


namespace Tests
{
    [TestFixture]
    class TxtTraining : TestBase
    {
        [Test]
        public static void TestTraining()
        {
            string path = @"TestTextFile2.txt";
            string pathWrong = "TestWrong.txt";            
            string verifyValueFromSite = Pages.loginPage.getTextFromSite();
            List<string> textLines = File.ReadAllLines(path).ToList();    //read given text file

            // File.WriteAllLines(path,textLines);
            string fileNotFoundMessage = $"File in path = {pathWrong} doesnt exist!";   
            string textNotFoundMessage = $"File in {path} doesnt contain test string from web = {verifyValueFromSite}";
            Assert.IsTrue(File.Exists(path), fileNotFoundMessage);  //verify if file exists, stop the test if not
            Assert.IsTrue(textLines.Contains(verifyValueFromSite), textNotFoundMessage); // compare file contents with found text from web

           


        }
    }
}
