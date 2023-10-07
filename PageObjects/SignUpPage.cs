namespace ProductStoreTest.PageObjects
{
    using OpenQA.Selenium;

    public class SignUpPage : BasePage
    {
        #region Locators

        By SignupUserName = By.Id("sign-username");
        By SignupPassword = By.Id("sign-password");
        By SignupBtn = By.XPath("//button[text()='Sign up']");

        #endregion


        public SignUpPage(IWebDriver driver) : base(driver)
        { }

        public void SignUp(string username, string password)
        {
            action.SetText(action.Find(SignupUserName, 20), username);
            action.SetText(action.Find(SignupPassword, 20), password);
            action.Click(action.Find(SignupBtn));
        }
    }
}
