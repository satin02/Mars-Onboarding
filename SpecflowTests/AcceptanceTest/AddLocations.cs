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
    public class AddLocations
    {
        [Given(@"I click on location under Profile Page")]
        public void GivenIClickOnLocationUnderProfilePage()
        {
            //Wait
            Thread.Sleep(1500);

            // Click on Profile tab
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[1]/div/a[2]")).Click();

            //Click on Location
            Driver.driver.FindElement(By.XPath("//*[@id='profileCard']/div/div/div/div/div[3]/div/div[1]/div/span/i")).Click();


        }
        
        [When(@"I enter the country and city name")]
        public void WhenIEnterTheCountryAndCityName()
        {
            //Choose country name
            Driver.driver.FindElement(By.XPath("//*[@id='profileCard']/div/div/div/div/div[3]/div/div[1]/div/span/select[1]/option[102]")).Click();

            //Choose city name
            Driver.driver.FindElement(By.XPath("//*[@id='profileCard']/div/div/div/div/div[3]/div/div[1]/div/span/select[2]/option[6]")).Click();
        }
        
        [Then(@"location is displayed on my profile")]
        public void ThenLocationIsDisplayedOnMyProfile()
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Add Location");

                Thread.Sleep(1000);
                string ExpectedValue = "New Zealand Auckland";
                string ActualValue = Driver.driver.FindElement(By.XPath("//*[@id='profileCard']/div/div/div/div/div[3]/div/div[1]/div/span")).Text;
                Thread.Sleep(500);
                if (ExpectedValue == ActualValue)
                {
                    CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Added location Successfully");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "LocationAdded");
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
