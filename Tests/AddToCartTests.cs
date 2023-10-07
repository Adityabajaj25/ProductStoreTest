namespace ProductStoreTest.Tests
{
    using NUnit.Framework;
    using ProductStoreTest.Utilities;

    [Order(3)]
    public class AddToCartTests : BaseTest
    {
        public AddToCartTests(string browserType) : base(browserType)
        { }

        [Test]
        [TestCase("Nokia lumia 1520", Description = "Test to verify Add to cart functionality")]
        public void VerifyAddToCart(string productName)
        {
            loginPage = homePage.ClickLogin();
            homePage = loginPage.LoginToApplication(AppConstants.UserName, AppConstants.Password);

            homePage.GetLoggedInUserName();
            productDetailsPage = homePage.SelectProduct(productName);
            string alertText = productDetailsPage.AddProductToCart();
            Assert.IsTrue(alertText.Contains("Product added"));
        }
    }
}
