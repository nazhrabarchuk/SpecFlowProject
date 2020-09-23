using SpecFlowProject.Pages;
using TechTalk.SpecFlow;

namespace SpecFlowProject.Steps
{
    [Binding]
    class HomePageSteps : BaseTest
    {
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

    }
}
