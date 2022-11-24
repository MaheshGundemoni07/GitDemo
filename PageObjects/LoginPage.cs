using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpSelFrameworl.PageObjects
{
    internal class LoginPage
    {
        IWebDriver driver;
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        //driver.FindElement(By.Id("username")).SendKeys("rahulshettyacademy");
       // driver.FindElement(By.Name("password")).SendKeys("learning");
       // driver.FindElement(By.XPath("//div[@class='form-group'][5]/label/span/input")).Click();
       // driver.FindElement(By.CssSelector("input[type='submit']")).Click();

        [FindsBy(How = How.Id, Using = "username")]
        private IWebElement userName;

        [FindsBy(How = How.Name, Using = "password")]
        private IWebElement password;

        [FindsBy(How = How.XPath, Using = "//div[@class='form-group'][5]/label/span/input")]
        private IWebElement checkBox;

        [FindsBy(How = How.CssSelector, Using = "input[type='submit']")]
        private IWebElement signIn;

        public ProductsPage validLogin(String user, String pass)
        {
            userName.SendKeys(user);
            password.SendKeys(pass);
            checkBox.Click();
            signIn.Click();
            return new ProductsPage(driver);
        }

      /*  public IWebElement getUserName()
        {
            return userName;
        } */
        


    }
}
