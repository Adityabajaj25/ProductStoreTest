namespace ProductStoreTest.Tests
{
    using NUnit.Framework;
    using ProductStoreTest.PageObjects;
    using ProductStoreTest.Utilities;

    [Order(1)]
    public class SignUpTest : BaseTest
    {
        SignUpPage signUpPage;
        public SignUpTest(string browserType) : base(browserType)
        { }

        [Test]
        [TestCase(AppConstants.UserName, AppConstants.Password, Description = "Test to verify user sign up")]
        public void UserSignUpTest(string userName, string password)
        {
            signUpPage = homePage.ClickSignUp();
            signUpPage.SignUp(userName, password);
            Assert.AreEqual("Sign up successful.", signUpPage.HandleAlert());
        }
    }
}
