using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductStoreTest.Utilities
{
    internal class LocalDriverUtility
    {
        private readonly WebDriverFactory _driverFactory;
        static IWebDriver driver;

        public LocalDriverUtility() : this(new WebDriverFactory())
        {

        }

        public LocalDriverUtility(WebDriverFactory driverFactory)
        {
            this._driverFactory = driverFactory;
        }

        public virtual IWebDriver Launch(string browserType, string url)
        {
            driver = CreateWebDriver(browserType);

            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);
            return driver;
        }

        public virtual void Close()
        {
            driver.Quit();
        }

        private IWebDriver CreateWebDriver(string browserType)
        {
            switch (browserType)
            {
                case AppConstants.Chrome:
                    return _driverFactory.CreateLocalChromeDriver();
                default:
                    throw new NotSupportedException($"{browserType} is not supported browser type");
            }
        }
    }
}
