using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SpecFlowProject.Pages
{

    class NewsPage : BasePage
    {
        public NewsPage(IWebDriver driver) : base(driver) { }

        private IWebElement HeadlineArticleH3 => this.driver.FindElement(By.XPath("//div[@data-entityid='container-top-stories#1']//div[contains(@class,'gs-u-display-inline-block@m')]//h3"));

        private IList<IWebElement> SecondaryArticleH3List => this.driver.FindElements(By.XPath("//div[@class='gel-wrap gs-u-pt+']//div[contains(@class,'nw-c-top-stories__secondary-item')]//h3"));

        private IWebElement CategoryLinkOfHeadlineArticleSpan => this.driver.FindElement(By.XPath("//div[@data-entityid='container-top-stories#1']//div[contains(@class,'gs-u-display-inline-block@m')]//li[@class='nw-c-promo-meta']/a/span"));

        private IWebElement FirstArticleSearchedSpan => this.driver.FindElement(By.XPath("//main[@id='main-content']//ul[@role='list']/li[1]//a/span"));

        private IWebElement CoronovirusButton => this.driver.FindElement(By.XPath("//nav[@role='navigation' and @class='nw-c-nav__wide']//span[contains(text(),'Coronavirus')]/parent::a"));

        private IWebElement YouCoronovirusStoriesButton => this.driver.FindElement(By.XPath("//nav[@role='navigation' and @class='nw-c-nav__wide-secondary']//span[contains(text(),'Your Coronavirus Stories')]/parent::a"));

        private IWebElement HowToShareBBCNewsButton => this.driver.FindElement(By.XPath("//h3[contains(text(),'How to share with BBC News')]/parent::a"));

        private IWebElement UserStoryTexarea => this.driver.FindElement(By.XPath("//div[@class='hearken-embed cleanslate']//textarea"));
        private IWebElement UserNameInput => this.driver.FindElement(By.XPath("//div[@class='hearken-embed cleanslate']//input[@aria-label='Name']"));
        private IWebElement UserEmailInput => this.driver.FindElement(By.XPath("//div[@class='hearken-embed cleanslate']//input[@aria-label='Email address']"));
        private IWebElement UserNumberInput => this.driver.FindElement(By.XPath("//div[@class='hearken-embed cleanslate']//input[@aria-label='Contact number ']"));
        private IWebElement UserLocationInput => this.driver.FindElement(By.XPath("//div[@class='hearken-embed cleanslate']//input[@aria-label='Location ']"));
        private IWebElement UserAdultCheckbox => this.driver.FindElement(By.XPath("//div[@class='hearken-embed cleanslate']//p[contains(text(),'I am over 16 years old')]/parent::div/parent::span/parent::label/input[@type='checkbox']"));
        private IWebElement UserConfirmServiceCheckbox => this.driver.FindElement(By.XPath("//div[@class='hearken-embed cleanslate']//p[contains(text(),'I accept the ')]/parent::div/parent::span/parent::label/input[@type='checkbox']"));
        private IWebElement SubmitButton => this.driver.FindElement(By.XPath("//div[@class='hearken-embed cleanslate']//button[contains(text(),Submit)]"));
        private IWebElement ErrorMessage => this.driver.FindElement(By.XPath("//div[@class='input-error-message']"));
        private IWebElement ConfirmNotification => this.driver.FindElement(By.XPath("//div[@class='embed-content-container']"));




        public IWebElement GetHeadlineArticleH3()
        {
            return HeadlineArticleH3;
        }

        public IList<IWebElement> GetSecondaryArticleH3List()
        {
            return SecondaryArticleH3List;
        }

        public IWebElement GetCategoryLinkOfHeadlineArticleSpan()
        {
            return CategoryLinkOfHeadlineArticleSpan;
        }

        public string GetFirstArticleSearchedSpanText()
        {
            return FirstArticleSearchedSpan.Text;
        }

        public IWebElement GetCoronovirusButton()
        {
            return CoronovirusButton;
        }

        public IWebElement GeYouCoronovirusStoriesButton()
        {
            return YouCoronovirusStoriesButton;
        }
        public IWebElement GetHowToShareBBCNewsButton()
        {
            return HowToShareBBCNewsButton;
        }


        public void Login(string userStory, string userName, string userEmail, string userNumber, string userLocation)
        {
            UserStoryTexarea.SendKeys(userStory);
            UserNameInput.SendKeys(userName);
            UserEmailInput.SendKeys(userEmail);
            UserNumberInput.SendKeys(userNumber);
            UserLocationInput.SendKeys(userLocation);
            UserAdultCheckbox.Click();
            UserConfirmServiceCheckbox.Click();
        }

        public void ClickSubmit() => SubmitButton.Submit();

        public bool IsErrorMessageExist() => ErrorMessage.Displayed;
    }
}
