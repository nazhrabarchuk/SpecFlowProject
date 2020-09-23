using OpenQA.Selenium;

namespace SpecFlowProject.Pages
{
    class EntertainmentArtsPage : BasePage
    {
        public EntertainmentArtsPage(IWebDriver driver) : base(driver) { }

        private IWebElement EntertainmentArtsPageButton => this.driver.FindElement(By.XPath("//nav[@role='navigation' and @aria-label='news']/ul[contains(@class,'nw-c-nav__wide-sections')]//a[contains(@href,'/news/entertainment_and_arts')]"));
        private IWebElement EntertainmentArtsPageFirstArticleButton => this.driver.FindElement(By.XPath("//div[@class='no-mpu']//div[@class='gel-layout__item gel-1/1']//a[contains(@class,'gel-paragon-bold gs-u-mt+')]"));
        private IWebElement ShareButton => this.driver.FindElement(By.XPath("//a[@class='twite__share-button']"));
        private IWebElement ShareLink => this.driver.FindElement(By.XPath("//a[@class='twite__share-link']"));

        public IWebElement GetEntertainmentArtsPageButton()
        {
            return EntertainmentArtsPageButton;
        }

        public IWebElement GetEntertainmentArtsPageFirstArticleButton()
        {
           return EntertainmentArtsPageFirstArticleButton;
        }
        
        public void ClickShareButton() => ShareButton.Click();
        

        public string GetShareLink()
        {
            return ShareLink.Text;
        }
    }
}
