namespace ProductStoreTest.Tests
{
    using NUnit.Framework;
    using System;
    using ProductStoreTest.Utilities;

    [Order(4)]
    public class CartTests : BaseTest
    {
        public CartTests(string browserType) : base(browserType)
        { }

        [Test, Order(1)]
        [TestCase("Nokia lumia 1520", Description = "Test to validate product is available in cart")]
        public void VerifyProductInCart(string productName)
        {
            loginPage = homePage.ClickLogin();
            homePage = loginPage.LoginToApplication(AppConstants.UserName, AppConstants.Password);
            homePage.GetLoggedInUserName();
            cartPage = homePage.ClickCart();
            int prodQuantity = cartPage.GetProductQuantityInCart(productName);
            Assert.AreEqual(1, prodQuantity);
        }

        [Test, Order(2)]
        [TestCase(Description = "Test to validate total cart value")]
        public void VerifyTotalCartValue()
        {
            string cartValue = cartPage.GetCartTotal();
            Console.WriteLine(cartValue);
            Assert.AreEqual("820", cartValue);
        }
    }
}
