namespace ProductStoreTest.Tests
{
    using NUnit.Framework;
    using System;
    using ProductStoreTest.Utilities;

    [Order(5)]
    public class PlaceOrderTests : BaseTest
    {
        public PlaceOrderTests(string browserType) : base(browserType)
        {
        }

        [Test]
        [TestCase("TestUSer", "India", "Bangalore", "123456", "12", "2023",
            Description = "Test to verify place order functionality")]
        public void VerifyPlacedOrder(string name, string country, string city, string cardNo, string month, string year)
        {
            loginPage = homePage.ClickLogin();
            homePage = loginPage.LoginToApplication(AppConstants.UserName, AppConstants.Password);
            homePage.GetLoggedInUserName();
            cartPage = homePage.ClickCart();

            placeOrderPage = cartPage.ClickPlaceOrder();
            placeOrderPage.FillOrderDetails(name, country, city, cardNo, month, year);
            placeOrderPage.ClickPurchaseButton();
            string confirmMsg = placeOrderPage.GetOrderConfirmMsg();
            placeOrderPage.CloseConfirmBox();
            Assert.AreEqual("Thank you for your purchase!", confirmMsg);
        }
    }
}
