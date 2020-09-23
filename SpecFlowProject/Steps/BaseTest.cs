using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SpecFlowProject.Pages
{
    class BaseTest
    {
        private IWebDriver driver;
        private const string BBC_URL = "https://www.bbc.com/";

        [SetUp]
        public void CreateDriver()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(BBC_URL);
        }

        [TearDown]
        public void Close()
        {
            driver.Quit();
        }


        public IWebDriver GetDriver()
        {
            return driver;
        }

        public BasePage GetBasePage()
        {
            return new BasePage(driver);
        }

        public HomePage GetHomePage()
        {
            return new HomePage(driver);
        }

        public NewsPage GetNewsPage()
        {
            return new NewsPage(driver);
        }
        public EntertainmentArtsPage GetEntertainmentArtsPage()
        {
            return new EntertainmentArtsPage(driver);
        }
    }
}
