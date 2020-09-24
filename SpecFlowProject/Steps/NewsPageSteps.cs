using OpenQA.Selenium;
using TechTalk.SpecFlow;
using SpecFlowProject.Pages;
using NUnit.Framework;
using TechTalk.SpecFlow.Assist;

namespace SpecFlowProject.Steps
{
    [Binding]
    [Scope(Feature = "NewsPageSteps")]
    class NewsPageSteps : BaseTest
    {
        private const string EXPECTED_HEADLINE_ARTICLE_TEXT = "WHO warns of 'very serious situation' in Europe";

        private const string EXPECTED_SEARCHED_FIRST_ARTICLE_TEXT = "World's End: World's End";

        private readonly string[] SECONDARY_ARTICLE_TEXT = { "Greece moves migrants to new camp after fire", "Navalny's aides say poison found on water bottle", "Why fires in Siberia threaten us all", "Protesters topple conquistador statue in Colombia", "Police 'requested heat ray' for White House protest" };


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

            GetNewsPage().Login((string)data.Story, (string)data.Name, (string)data.EmailAddress, (string)data.ContactNumber,(string)data.Location);

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
