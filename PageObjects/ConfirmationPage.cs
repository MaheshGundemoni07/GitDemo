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
    internal class ConfirmationPage
    {
        IWebDriver driver;
        public ConfirmationPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        //driver.FindElement(By.CssSelector("#country")).SendKeys("Ind");
        //driver.FindElement(By.LinkText("India")).Click();
        //driver.FindElement(By.CssSelector("label[for='checkbox2']")).Click();
        //driver.FindElement(By.CssSelector(".btn-success")).Click();
        //driver.FindElement(By.CssSelector(".alert-success")).Text;

        [FindsBy(How = How.CssSelector, Using = "#country")]
        private IWebElement location;

        [FindsBy(How = How.LinkText, Using = "India")]
        private IWebElement dropDownValue;

        [FindsBy(How = How.CssSelector, Using = "label[for='checkbox2']")]
        private IWebElement checkBox;

        [FindsBy(How = How.CssSelector, Using = ".btn-success")]
        private IWebElement purchase;

        [FindsBy(How = How.CssSelector, Using = ".alert-success")]
            private IWebElement successMessage;

        public IWebElement locationText()
    {
        return location;
    }

        public void clickOnDropDownValue()
        {
            dropDownValue.Click();
        }

        public void clickCheckBox()
        {
            checkBox.Click();
        }

        public void purchaseButton()
        {
            purchase.Click();
        }

        public IWebElement getSuccessMessage()
        {
            return successMessage;
        }


        public void waitUntilElementVisible()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.LinkText("India")));
        }
    }
}
