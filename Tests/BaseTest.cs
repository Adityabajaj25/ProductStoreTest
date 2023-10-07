namespace ProductStoreTest.Tests
{
    using NUnit.Framework;
    using OpenQA.Selenium;
    using ProductStoreTest.PageObjects;
    using ProductStoreTest.Utilities;
    using System.Threading;

    [TestFixture(AppConstants.Chrome)]
    public abstract class BaseTest
    {
        string browserType;
        LocalDriverUtility localDriverUtility;
        protected HomePage homePage;
        protected LoginPage loginPage;
        protected ProductDetailsPage productDetailsPage;
        protected CartPage cartPage;
        protected PlaceOrderPage placeOrderPage;

        public BaseTest(string browserType)
        {
            this.browserType = browserType;
            localDriverUtility = new LocalDriverUtility();
        }

        [OneTimeSetUp]
        public void InitializeDriver()
        {
            IWebDriver driver = localDriverUtility.Launch(this.browserType, AppConstants.baseURL);
            homePage = new HomePage(driver);
        }


        [OneTimeTearDown]
        public void CloseBrowser()
        {
            localDriverUtility.Close();
        }
    }
}
