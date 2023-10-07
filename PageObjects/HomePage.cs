namespace ProductStoreTest.PageObjects
{
    using OpenQA.Selenium;

    public class HomePage : BasePage
    {
        IWebDriver driver;

        #region Locators
        By SignUp = By.Id("signin2");
        By Login = By.Id("login2");
        By LogOut = By.Id("logout2");
        By Cart = By.Id("cartur");
        By Home = By.XPath("//a[@class='nav-link' and @href=\"index.html\"]");
        By NameOfLoggedInUser = By.Id("nameofuser");

        By ProdTitle(string prodNme)
        {
            return By.LinkText(prodNme);
        }

        By ProductPrice(string productName)
        {
            string path = $"//h4[@class='card-title']/a[text()='{productName}']//ancestor::div[@class='card-block']/h5";
            return By.XPath(path);
        }
        #endregion

        public HomePage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        public SignUpPage ClickSignUp()
        {
            action.Find(SignUp).Click();
            return new SignUpPage(_driver);
        }

        public LoginPage ClickLogin()
        {
            action.Find(Login).Click();
            return new LoginPage(this.driver);
        }

        public void ClickLogout()
        {
            action.Find(LogOut).Click();
        }

        public HomePage ClickHome()
        {
            action.Find(Home).Click();
            return new HomePage(this.driver);
        }

        public CartPage ClickCart()
        {
            _driver.Navigate().Refresh();
            action.Find(Cart).Click();
            return new CartPage(_driver);
        }

        public string GetLoggedInUserName()
        {
            IWebElement elmLoggedUser = action.Find(NameOfLoggedInUser, 20);
            return elmLoggedUser?.Text.Replace("Welcome ", "");
        }

        public bool IsLogOutNotDisplayed()
        {
            return action.WaitForInvisibilityOf(LogOut, 10);
        }

        public ProductDetailsPage SelectProduct(string productName)
        {
            _driver.Navigate().Refresh();
            action.Find(NameOfLoggedInUser, 30);
            IWebElement element = action.Find(ProdTitle(productName), 20);
            action.ScrollToView(element);
            element.Click();
            return new ProductDetailsPage(_driver);
        }

        public string GetProductPrice(string productName)
        {
            IWebElement element = action.Find(ProductPrice(productName), 20);
            return element.Text;
        }
    }
}
