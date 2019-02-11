using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using SpecflowPages;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using static SpecflowPages.CommonMethods;

namespace SpecflowTests.AcceptanceTest
{
    [Binding]
    public class UploadPic 
    {
        [Given(@"I click on the edit availability under Profile page")]
        public void GivenIClickOnTheEditAvailabilityUnderProfilePage()
        {
            //Wait
            Thread.Sleep(1500);

            // Click on Profile tab
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[1]/div/a[2]")).Click();

            //Click on Availability
            Driver.driver.FindElement(By.XPath("/html/body/div[1]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[2]/div/span/i")).Click();

        }
        
        [When(@"I choose my availability")]
        public void WhenIChooseMyAvailability()
        {
            // Choose Availability
            Driver.driver.FindElement(By.XPath("//*[@id='profileCard']/div/div/div/div/div[3]/div/div[2]/div/span/select/option[3]")).Click();

            Thread.Sleep(3000);
        }
        
        [Then(@"my availability should be displayed on my profile")]
        public void ThenMyAvailabilityShouldBeDisplayedOnMyProfile()
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Add availability");

                Thread.Sleep(1000);
                string ExpectedValue = "Full Time";
                string ActualValue = Driver.driver.FindElement(By.XPath("//*[@id='profileCard']/div/div/div/div/div[3]/div/div[2]/div/span")).Text;
                Thread.Sleep(500);
                if (ExpectedValue == ActualValue)
                {
                    CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Added availability Successfully");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "AvailabilityAdded");
                }

                else
                    CommonMethods.test.Log(LogStatus.Fail, "Test Failed");

            }
            catch (Exception e)
            {
                CommonMethods.test.Log(LogStatus.Fail, "Test Failed", e.Message);
            }
        }
    }
}
