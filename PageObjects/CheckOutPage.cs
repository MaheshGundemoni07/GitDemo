using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpSelFrameworl.PageObjects
{
    internal class CheckOutPage
    {
        IWebDriver driver;
        public CheckOutPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        //driver.FindElements(By.CssSelector("h4 a"));
        // driver.FindElement(By.CssSelector(".btn-success")).Click();

        [FindsBy(How = How.CssSelector, Using = "h4 a")]
        private IList<IWebElement> checkOutProducts;

        [FindsBy(How = How.CssSelector, Using = ".btn-success")]
        private IWebElement checkOut;

       public IList<IWebElement> allcheckOutProducts()
        {
            return checkOutProducts;
        }

        public ConfirmationPage checkOutButton()
        {
             checkOut.Click();
            return new ConfirmationPage(driver);
        }

    }
}
