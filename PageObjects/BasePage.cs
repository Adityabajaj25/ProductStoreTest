namespace ProductStoreTest.PageObjects
{
    using OpenQA.Selenium;
    using ProductStoreTest.Utilities;
    using System;

    public class BasePage
    {
        protected CommonAction action;
        protected static IWebDriver _driver;
        public BasePage(IWebDriver driver)
        {
            _driver = driver;
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(15);
            action = new CommonAction(_driver);
        }

        public string HandleAlert()
        {
            IAlert alert = action.WaitForAlert(20);
            string alertText = action.WaitForAlert(20).Text;
            alert.Accept();
            return alertText;
        }
    }
}
