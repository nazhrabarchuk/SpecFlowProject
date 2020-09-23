using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SpecFlowProject.Pages
{

    class HomePage : BasePage
    {
        public HomePage(IWebDriver driver) : base(driver) { }

        private IWebElement NewsPageButton => this.driver.FindElement(By.XPath("//div[@id='orb-nav-links']//a[contains(text(),'News')]"));
        private IWebElement EntertainmentArtsPageButton => this.driver.FindElement(By.XPath("//nav[@role='navigation' and @aria-label='news']/ul[contains(@class,'nw-c-nav__wide-sections')]//a[contains(@href,'/news/entertainment_and_arts')]"));

        private IWebElement SearchInput => this.driver.FindElement(By.XPath("//input[@id='orb-search-q']"));

        private IWebElement SearchButton => this.driver.FindElement(By.XPath("//button[@id='orb-search-button']"));

        public void ClickNewsPageButton() => NewsPageButton.Click();
        
        public void ClickEntertainmentArtsPageButton() => EntertainmentArtsPageButton.Click();
        

        public void SearchByKeyWord(string keyword) => SearchInput.SendKeys(keyword);
        

        public IWebElement GetSearchButoon()
        {
            return SearchButton;
        }
    }
}
