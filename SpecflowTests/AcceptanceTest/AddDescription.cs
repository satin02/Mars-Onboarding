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
    public class AddLocation 
    {
        [Given(@"I clicked on the edit description under the Profile page")]
        public void GivenIClickedOnTheEditDescriptionUnderTheProfilePage()
        {
            //Wait
            Thread.Sleep(1500);

            // Click on Profile tab
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[1]/div/a[2]")).Click();

            //Click on Description
            Driver.driver.FindElement(By.XPath("/html/body/div[1]/div/section[2]/div/div/div/div[3]/div/div/div/h3/span/i")).Click();

            Thread.Sleep(2000);
         

        }
        
        [When(@"I add description and click on save button")]
        public void WhenIAddDescriptionAndClickOnSaveButton()
        {

            //Wait
            Thread.Sleep(2000);

            // Add Description
            Driver.driver.FindElement(By.XPath("/html/body/div[1]/div/section[2]/div/div/div/div[3]/div/div/form/div/div/div[2]/div[1]/textarea")).SendKeys("Added with automation");

            //Click Save Description
            Driver.driver.FindElement(By.XPath("//*[@id='editDescription']/div/form/div/div/div[2]/button")).Click();
        }


        
        [Then(@"descripton should be displayed on my profile")]
        public void ThenDescriptonShouldBeDisplayedOnMyProfile()
        {

            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Add description");

                Thread.Sleep(1000);
                string ExpectedValue = "Added with automation";
                string ActualValue = Driver.driver.FindElement(By.XPath("//*[@id='editDescription']/div/div/span")).Text;
                Thread.Sleep(500);
                if (ExpectedValue == ActualValue)
                {
                    CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Added description Successfully");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "DescriptionAdded");
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
