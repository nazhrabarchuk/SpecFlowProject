using NUnit.Framework;
using OpenQA.Selenium;

namespace SpecFlowProject.Pages
{
    class BaseTest
    {
     
        private const string BBC_URL = "https://www.bbc.com/";

        [SetUp]
        public void CreateDriver()
        {
            Driver.Start();
            Driver.MaximizeWindow();
            Driver.Navigate(BBC_URL);
        }

        [TearDown]
        public void Close()
        {
            Driver.Quit();
        }


        public IWebDriver GetDriver()
        {
            return Driver.Instance;
        }

        public BasePage GetBasePage()
        {
            return new BasePage(Driver.Instance);
        }

        public HomePage GetHomePage()
        {
            return new HomePage(Driver.Instance);
        }

        public NewsPage GetNewsPage()
        {
            return new NewsPage(Driver.Instance);
        }
        public EntertainmentArtsPage GetEntertainmentArtsPage()
        {
            return new EntertainmentArtsPage(Driver.Instance);
        }
    }
}
