using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpSelFrameworl.PageObjects
{
    internal class ProductsPage
    {
        IWebDriver driver;  
        public ProductsPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }


        //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
        //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.PartialLinkText("Checkout")));
        //   IList<IWebElement> products = driver.FindElements(By.TagName("app-card"));
        //  By.CssSelector(".card-title a"))
        //driver.FindElement(By.PartialLinkText("Checkout")).Click();

        By cardTitle = By.CssSelector(".card-title a");
        By addProduct = By.CssSelector(".card-footer button");
        By eachProduct = By.CssSelector(".card-title a");

        [FindsBy(How = How.TagName, Using = "app-card")]
        private IList<IWebElement> cards;

        [FindsBy(How = How.PartialLinkText, Using = "Checkout")]
        private IWebElement checkOut;

        public void waitForPageDisplay()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.PartialLinkText("Checkout")));
        }

        public IList<IWebElement> getCards()
        {
            return cards;
        }

        public By getCardTitle()
        {
            return cardTitle;
        }

        public By addEachProduct()
        {
            return addProduct;
        }

        public By eachProductTitle()
        {
            return eachProduct;
        }

        public CheckOutPage checkOutButton()
        {
            checkOut.Click();
            return new CheckOutPage(driver);
        }

    }
}
