namespace ProductStoreTest.PageObjects
{
    using OpenQA.Selenium;
    using System;

    public class LoginPage : BasePage
    {
        IWebDriver driver;

        #region Locators

        By LoginUserName = By.Id("loginusername");
        By LoginPassword = By.Id("loginpassword");
        By LoginBtn = By.XPath("//button[text()='Log in']");
        By CloseBtn = By.XPath("//div[@id='logInModal']//button[text()='Close']");

        #endregion

        public LoginPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        public void ClickClose()
        {
            action.Find(CloseBtn, 20).Click();
        }

        public HomePage LoginToApplication(string userName, string password)
        {
            try
            {
                IWebElement elmUserName = action.Find(LoginUserName, 20);

                action.Click(elmUserName);
                action.SetText(elmUserName, userName);


                IWebElement elmPassword = action.Find(LoginPassword, 20);
                action.Click(elmPassword);
                action.SetText(elmPassword, password);

                IWebElement btnLoginIn = action.Find(LoginBtn, 20);
                action.Click(btnLoginIn);
                return new HomePage(driver);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }

        }
    }
}
