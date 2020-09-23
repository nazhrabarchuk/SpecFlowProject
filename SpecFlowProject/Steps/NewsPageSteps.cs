using NUnit.Framework;
using OpenQA.Selenium;
using SpecFlowProject.Pages;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SpecFlowProject.Steps
{
    [Binding]
    class NewsPageSteps : BaseTest
    {
        private const string EXPECTED_HEADLINE_ARTICLE_TEXT = "WHO warns of 'very serious situation' in Europe";

        private const string EXPECTED_SEARCHED_FIRST_ARTICLE_TEXT = "World's End: World's End";

        private readonly string[] SECONDARY_ARTICLE_TEXT = { "Greece moves migrants to new camp after fire", "Navalny's aides say poison found on water bottle", "Why fires in Siberia threaten us all", "Protesters topple conquistador statue in Colombia", "Police 'requested heat ray' for White House protest" };

        private string copiedUrl;

        [Given(@"the BBC Home page is open")]
        public void GivenTheBBCHomePageIsOpen()
        {
            CreateDriver();
        }
        [Given(@"I go to News")]
        public void GivenIGoToNews()
        {
            GetHomePage().ClickNewsPageButton();
            GetBasePage().WaitForPageLoadComplete();

        }

     
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

      

        [When(@"click on Coronavirus tab")]
        public void WhenClickOnCoronavirusTab()
        {
            IJavaScriptExecutor executor = (IJavaScriptExecutor)GetDriver();
            executor.ExecuteScript("arguments[0].click();", GetNewsPage().GetCoronovirusButton());
            GetBasePage().WaitForPageLoadComplete();
        }

        [When(@"click on Your Coronavirus Stories tab")]
        public void WhenClickOnYourCoronavirusStoriesTab()
        {
            IJavaScriptExecutor executor2 = (IJavaScriptExecutor)GetDriver();
            executor2.ExecuteScript("arguments[0].click();", GetNewsPage().GeYouCoronovirusStoriesButton());
            GetBasePage().WaitForPageLoadComplete();
        }

        [When(@"go to “How to share with BBC news”")]
        public void WhenGoToHowToShareWithBBCNews()
        {
            IJavaScriptExecutor executor3 = (IJavaScriptExecutor)GetDriver();
            executor3.ExecuteScript("arguments[0].click();", GetNewsPage().GetHowToShareBBCNewsButton());
            GetBasePage().WaitForPageLoadComplete();
        }

        [When(@"fill in the information on the bottom")]
        public void WhenFillInTheInformationOnTheBottom(Table table)
        {
            if (GetBasePage().GetSignInButton().Displayed)
            {
                IJavaScriptExecutor executor = (IJavaScriptExecutor)GetDriver();
                executor.ExecuteScript("arguments[0].click();", GetBasePage().GetSignInButton());
            }
            dynamic data = table.CreateDynamicInstance();

            GetNewsPage().Login((string)data.Story, (string)data.Name, (string)data.EmailAddress, (string)data.ContactNumber, (string)data.Location);

        }

        [When(@"click Submit")]
        public void WhenClickSubmit()
        {
            GetNewsPage().ClickSubmit();
        }

        [Then(@"the story is not sent")]
        public void ThenTheStoryIsNotSent()
        {
            Assert.IsTrue(GetNewsPage().IsErrorMessageExist());
        }
    }
}
