﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductStoreTest
{
    internal class WebDriverFactory
    {
        public virtual IWebDriver CreateLocalChromeDriver()
        {
            return new ChromeDriver();
        }


    }
}
