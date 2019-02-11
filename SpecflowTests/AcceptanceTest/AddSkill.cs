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
    public class AddSkill 
    {
        [Given(@"I clicked on the skill tab under profile page")]
        public void GivenIClickedOnTheSkillTabUnderProfilePage()
        {
            //Wait
            Thread.Sleep(1500);

            // Click on Profile tab
             Driver.driver.FindElement(By.XPath("/html/body/div[1]/div/section[1]/div/a[2]")).Click();

            // Click on Skill tab
            Driver.driver.FindElement(By.XPath("//*[@id='table']/div[1]/a[2]")).Click();

        }

        [When(@"I add a new skill")]
        public void WhenIAddANewSkill()
        {
            //Click on Add New button
            Driver.driver.FindElement(By.XPath("//*[@id='skill']/div/div[2]/div/table/thead/tr/th[3]/div")).Click();

            //Click on Add Skill
            Driver.driver.FindElement(By.XPath("//*[@id='skill']/div/div[2]/div/div/div[1]/input")).SendKeys("Indian Cooking");

            //Click on Skill level
            Driver.driver.FindElement(By.XPath("//*[@id='skill']/div/div[2]/div/div/div[2]/select")).Click();

            //Choose the skill level
            IWebElement Skil = Driver.driver.FindElements(By.XPath("//*[@id='skill']/div/div[2]/div/div/div[2]/select/option"))[1];
            Skil.Click();

            //Click on Add button
            Driver.driver.FindElement(By.XPath("//*[@id='skill']/div/div[2]/div/div/span/input[1]")).Click();
        }
        
        [Then(@"that skill should be added on my listing")]
        public void ThenThatSkillShouldBeAddedOnMyListing()
        {

            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Add a Skill");

                Thread.Sleep(1000);
                string ExpectedValue = "Indian Cooking";
                string ActualValue = Driver.driver.FindElement(By.XPath("//*[@id='skill']/div/div[2]/div/table/tbody/tr/td[1]")).Text;
                Thread.Sleep(500);
                if (ExpectedValue == ActualValue)
                {
                    CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Added a Skill Successfully");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "SkillAdded");
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
