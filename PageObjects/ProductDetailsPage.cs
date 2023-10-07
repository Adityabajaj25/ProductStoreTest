namespace ProductStoreTest.PageObjects
{
    using OpenQA.Selenium;

    public class ProductDetailsPage : BasePage
    {
        #region Locator

        By ProductName = By.ClassName("name");
        By ProductPrice = By.ClassName("price-container");
        By AddToCartBtn = By.LinkText("Add to cart");

        #endregion

        public ProductDetailsPage(IWebDriver driver) : base(driver)
        { }

        public string GetProductName() => action.Find(ProductName).Text;

        public string GetProductPrice() => action.Find(ProductPrice).Text;

        public string AddProductToCart()
        {
            action.Find(AddToCartBtn).Click();
            return HandleAlert();
        }

    }
}
