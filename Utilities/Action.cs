namespace ProductStoreTest.Utilities
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;
    using SeleniumExtras.WaitHelpers;
    using System;
    using System.Collections.Generic;

    public class CommonAction
    {
        IWebDriver driver;

        public CommonAction(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement Find(By locator, int timeout = 10)
        {
            WebDriverWait wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(timeout));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
        }

        public IList<IWebElement> FindMultiple(By locator, int timeout = 10)
        {
            WebDriverWait wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(timeout));
            return wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(locator));
        }

        public bool WaitForInvisibilityOf(By locator, int timeout = 10)
        {
            WebDriverWait wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(timeout));
            return wait.Until(ExpectedConditions.InvisibilityOfElementLocated(locator));
        }

        public bool IsEnabled(IWebElement element)
        {
            return element.Enabled;
        }

        public void SetText(IWebElement element, string text)
        {
            element.SendKeys(text);
        }

        public void Click(IWebElement element)
        {
            element.Click();
        }

        public IAlert WaitForAlert(int timeout = 10)
        {
            WebDriverWait wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(timeout));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.AlertIsPresent());
            return this.driver.SwitchTo().Alert();
        }

        public string GetAlartText(IAlert alert)
        {
            return alert.Text;
        }

        public void AcceptAlert(IAlert alert)
        {
            alert.Accept();
        }

        public void ScrollToView(IWebElement element)
        {
            IJavaScriptExecutor javaScriptExecutor = (IJavaScriptExecutor)this.driver;
            javaScriptExecutor.ExecuteScript("arguments[0].scrollIntoView();", element);
        }

    }
}
