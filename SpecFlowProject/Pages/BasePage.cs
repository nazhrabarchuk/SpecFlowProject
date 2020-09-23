using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SpecFlowProject.Pages
{
    public class BasePage
    {
        protected IWebDriver driver;
        private readonly long timeout = 5000;
        public IWebElement SignInButton => this.driver.FindElement(By.XPath("//button[@class='sign_in-exit']"));

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void ImplicitWait() => driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(timeout);
        

        public void WaitForPageLoadComplete()
        {
            IWait<IWebDriver> wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(timeout));
            wait.Until(driver1 => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
        }

        public IWebElement GetSignInButton()
        {
            return SignInButton;
        }
    }
}
