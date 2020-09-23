using NUnit.Framework;
using OpenQA.Selenium;
using SpecFlowProject.Pages;
using TechTalk.SpecFlow;

namespace SpecFlowProject.Steps
{
    [Binding]
    [Scope(Feature = "NewsPageSteps")]
    class EntertainmentArtsPageSteps : BaseTest
    {
        private string copiedUrl;

        [When(@"click on Entertainment & Arts tab")]
        public void WhenClickOnEntertainmentArtsTab()
        {
           
            if (GetBasePage().GetSignInButton().Displayed)
            {
                IJavaScriptExecutor executor = (IJavaScriptExecutor)GetDriver();
                executor.ExecuteScript("arguments[0].click();", GetBasePage().GetSignInButton());
            }
            IJavaScriptExecutor executor2 = (IJavaScriptExecutor)GetDriver();
            executor2.ExecuteScript("arguments[0].click();", GetEntertainmentArtsPage().GetEntertainmentArtsPageButton());
            GetBasePage().WaitForPageLoadComplete();
        }

        [When(@"click the first article")]
        public void WhenClickTheFirstArticle()
        {
            IJavaScriptExecutor executor3 = (IJavaScriptExecutor)GetDriver();
            executor3.ExecuteScript("arguments[0].click();", GetEntertainmentArtsPage().GetEntertainmentArtsPageFirstArticleButton());
            GetBasePage().WaitForPageLoadComplete();
        }

        [When(@"click Share")]
        public void WhenClickShare()
        {
            GetEntertainmentArtsPage().ClickShareButton();
        }

        [When(@"copy the link")]
        public void WhenCopyTheLink()
        {
            copiedUrl = GetEntertainmentArtsPage().GetShareLink();
        }

        [When(@"navigate the link")]
        public void WhenNavigateTheLink()
        {
            GetDriver().Navigate().GoToUrl(copiedUrl);
        }

        [Then(@"the same article is open")]
        public void ThenTheSameArticleIsOpen()
        {
            Assert.AreEqual(GetDriver().Url, copiedUrl);
        }
    }
}
