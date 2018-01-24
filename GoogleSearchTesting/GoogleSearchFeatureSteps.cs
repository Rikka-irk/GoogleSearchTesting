using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace GoogleSearchTest
{


    [Binding]
    public sealed class GoogleSearchFeatureSteps
    {
        IWebDriver driver;

        [Given(@"I navigate to the page ""(.*)""")]
        public void GivenINavigateToThePage(string p0)
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.google.com/");
        }

        [When(@"I see the page is loaded")]
        public void WhenISeeThePageIsLoaded()
        {
            Assert.AreEqual("Google", driver.Title);
        }

        [When(@"I enter Search Keyword in the Search Text box")]
        public void WhenIEnterSearchKeywordInTheSearchTextBox(Table table)
        {
            string searchText = table.Rows[0]["Keyword"].ToString();
            driver.FindElement(By.Name("q")).SendKeys(searchText);
        }

        [When(@"I click on Search Button")]
        public void WhenIClickOnSearchButton()
        {            
            driver.FindElement(By.Id("hplogo")).Click();
            driver.FindElement(By.Name("btnK")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [Then(@"Search items shows the items related to SpecFlow")]
        public void ThenSearchItemsShowsTheItemsRelatedToSpecFlow()
        {
            Assert.AreEqual("SpecFlow - Binding Business Requirements to .NET Code", driver.FindElement(By.CssSelector("#rso > div > div > div:nth-child(1) > div > div > h3 > a")).Text);
            driver.Close();
        }

    }
}