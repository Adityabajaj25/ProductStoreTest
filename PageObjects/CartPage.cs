namespace ProductStoreTest.PageObjects
{
    using OpenQA.Selenium;
    using System;
    using System.Linq;

    public class CartPage : BasePage
    {
        #region Locators
        By Product = By.XPath("//tr[@class='success']/td[2]");
        By CartValue = By.Id("totalp");
        By PlaceOrderBtn = By.XPath("//button[@data-target='#orderModal']");
        #endregion

        public CartPage(IWebDriver driver) : base(driver)
        {
        }

        public string GetCartTotal()
        {
            return action.Find(CartValue)?.Text;
        }

        public int GetProductQuantityInCart(string productName)
        {
            return action.FindMultiple(Product)
                         ?.Where(prod => prod.Text.Trim().Equals(productName, StringComparison.InvariantCultureIgnoreCase))
                         ?.Count() ?? 0;
        }

        public PlaceOrderPage ClickPlaceOrder()
        {
            action.Find(PlaceOrderBtn).Click();
            return new PlaceOrderPage(_driver);
        }
    }
}
