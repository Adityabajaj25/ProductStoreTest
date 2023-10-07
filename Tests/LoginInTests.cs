namespace ProductStoreTest.Tests
{
    using NUnit.Framework;
    using ProductStoreTest.Utilities;

    [Order(2)]
    public class LoginInTests : BaseTest
    {
        public LoginInTests(string browserType) : base(browserType)
        {
        }

        [Test]
        [TestCase(AppConstants.UserName, AppConstants.Password, Description = "Test to verify user login")]
        public void UserLoginTest(string userName, string password)
        {
            loginPage = homePage.ClickLogin();
            homePage = loginPage.LoginToApplication(userName, password);
            Assert.AreEqual(homePage.GetLoggedInUserName(), AppConstants.UserName);
        }
    }
}
