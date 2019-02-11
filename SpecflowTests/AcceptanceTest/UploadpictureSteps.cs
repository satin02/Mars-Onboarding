using AutoItX3Lib;
using NUnit.Framework;
using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using SpecflowPages;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using static SpecflowPages.CommonMethods;

namespace SpecflowTests
{
    [Binding]
    public class UploadpictureSteps
    {
        [Given(@"I click on Profile page")]
        public void GivenIClickOnProfilePage()
        {
            //Wait
            Thread.Sleep(1500);

            // Click on Profile tab
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[1]/div/a[2]")).Click();
        }
        
        [When(@"I upload profle picture")]
        public void WhenIUploadProflePicture()
        {
            //CLick on Upload Pic
            Driver.driver.FindElement(By.XPath("//*[@id='profileCard']/div/div/div/div/div[1]/div/i")).Click();

            Thread.Sleep(500);
            AutoItX3 auto = new AutoItX3();
            auto.WinActivate("Open");
            auto.Send(@"C:\Users\Satinder\Downloads\Blueflower.jpg");
            Thread.Sleep(1000);
            auto.Send("{ENTER}");

        }
        
        [Then(@"picture should be displayed on my Profile Page")]
        public void ThenPictureShouldBeDisplayedOnMyProfilePage()
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Upload Picture");

                //Check if pic is uploaded
                Assert.IsTrue(Driver.driver.FindElement(By.XPath("//*[@id='profileCard']/div/div/div/div/div[1]/img")).Displayed);

             
                CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Uploaded pic Successfully");
                SaveScreenShotClass.SaveScreenshot(Driver.driver, "PictureUploaded");
               

            }
            catch (Exception e)
            {
                CommonMethods.test.Log(LogStatus.Fail, "Test Failed", e.Message);
            }
        }
    }
}
