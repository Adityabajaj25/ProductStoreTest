namespace ProductStoreTest.Tests
{
    using NUnit.Framework;
    using ProductStoreTest.Utilities;

    public class HomePageTests : BaseTest
    {
        public HomePageTests(string browserType) : base(browserType)
        { }

        [Test, Order(6)]
        [TestCase(Description = "Test to verify log out functionality")]
        public void VerifyLogout()
        {

            loginPage = homePage.ClickLogin();
            homePage = loginPage.LoginToApplication(AppConstants.UserName, AppConstants.Password);
            homePage.GetLoggedInUserName();
            homePage.ClickLogout();
            Assert.IsTrue(homePage.IsLogOutNotDisplayed());
        }
    }
}
