namespace ProductStoreTest.PageObjects
{
    using OpenQA.Selenium;

    public class PlaceOrderPage : BasePage
    {
        #region Locators

        By Name = By.Id("name");
        By Country = By.Id("country");
        By City = By.Id("city");
        By CreditCard = By.Id("card");
        By Month = By.Id("month");
        By Year = By.Id("year");
        By PurchaseBtn = By.XPath("//button[text()='Purchase']");
        By OrderConfirmationMsg = By.XPath("//div[@class='sweet-alert  showSweetAlert visible']//h2");
        By ConfirmBoxOk = By.XPath("//button[text()='OK']");

        #endregion

        public PlaceOrderPage(IWebDriver driver) : base(driver)
        {
        }

        public void FillOrderDetails(string name, string country, string city, string cardNo, string month, string year)
        {
            action.SetText(action.Find(Name, 20), name);
            action.SetText(action.Find(Country, 20), country);
            action.SetText(action.Find(City, 20), city);
            action.SetText(action.Find(CreditCard, 20), cardNo);
            action.SetText(action.Find(Month, 20), month);
            action.SetText(action.Find(Year, 20), year);

        }

        public void ClickPurchaseButton()
        {
            action.Click(action.Find(PurchaseBtn, 20));
        }

        public string GetOrderConfirmMsg()
        {
            return action.Find(OrderConfirmationMsg).Text;
        }

        public void CloseConfirmBox()
        {
            action.Click(action.Find(ConfirmBoxOk));
        }
    }
}
