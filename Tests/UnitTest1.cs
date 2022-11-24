using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Support.UI;
using CsharpSelFrameworl.Utilities;
using CsharpSelFrameworl.PageObjects;

namespace SeleniumLearning
{
    [Parallelizable(ParallelScope.Self)]
    public class E2ETests : Base
    {

       
        [Test, TestCaseSource("AddTestDataConfig"), Category("Regression")]
        // [TestCase("rahulshettyacademy", "learning")]
        // [TestCase("rahulshetty", "learning")]
        // [TestCaseSource("AddTestDataConfig")]
        //[Parallelizable(ParallelScope.All)]
        public void EndTOEndFlow(String username, String password, String[] expectedProducts)
        {
          // String[] expectedProducts = { "iphone X", "Blackberry" };
            String[] actualProducts = new String[2];
            // driver.FindElement(By.Id("username")).SendKeys("rahulshettyacademy");
            LoginPage lp = new LoginPage(getDriver());
           ProductsPage pp = lp.validLogin(username, password);

            // lp.getUserName().SendKeys("rahulshettyacademy");
            // driver.FindElement(By.Name("password")).SendKeys("learning");
            // driver.FindElement(By.XPath("//div[@class='form-group'][5]/label/span/input")).Click();
            // driver.FindElement(By.CssSelector("input[type='submit']")).Click();

              WebDriverWait wait = new WebDriverWait(driver.Value, TimeSpan.FromSeconds(5));
            // wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.PartialLinkText("Checkout")));
            // IList<IWebElement> products = driver.FindElements(By.TagName("app-card"));

            pp.waitForPageDisplay();
            IList<IWebElement> products = pp.getCards();

            foreach (IWebElement eachProduct in products)
            {
                // if (expectedProducts.Contains(eachProduct.FindElement(By.CssSelector(".card-title a")).Text))
                if (expectedProducts.Contains(eachProduct.FindElement(pp.getCardTitle()).Text))
                {
                    eachProduct.FindElement(pp.addEachProduct()).Click();
                }

                TestContext.Progress.WriteLine(eachProduct.FindElement(pp.eachProductTitle()).Text);
            }

            //  driver.FindElement(By.PartialLinkText("Checkout")).Click();
            CheckOutPage cop = pp.checkOutButton();

            //IList<IWebElement> checkOutProducts = driver.FindElements(By.CssSelector("h4 a"));
            IList<IWebElement> checkOutProducts = cop.allcheckOutProducts();

            for (int i = 0; i < checkOutProducts.Count; i++)
            {
                actualProducts[i] = checkOutProducts[i].Text;
            }
            Assert.AreEqual(expectedProducts, actualProducts);

            // driver.FindElement(By.CssSelector(".btn-success")).Click();
            ConfirmationPage cp = cop.checkOutButton();

            //  driver.FindElement(By.CssSelector("#country")).SendKeys("Ind");
            cp.locationText().SendKeys("Ind");
            // wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.LinkText("India")));
            cp.waitUntilElementVisible();
            // driver.FindElement(By.LinkText("India")).Click();
            cp.clickOnDropDownValue();
            //driver.FindElement(By.CssSelector("label[for='checkbox2']")).Click();
            cp.clickCheckBox();
            //   driver.FindElement(By.CssSelector(".btn-success")).Click();
            cp.purchaseButton();
            // String successMessage = driver.FindElement(By.CssSelector(".alert-success")).Text;
            String successMessage = cp.getSuccessMessage().Text;
            StringAssert.Contains("Success", successMessage);

        }

        [Test,Category("Smoke")]
        public void Test()
        {
            driver.Value.FindElement(By.Id("username")).SendKeys("Mahesh");
            driver.Value.FindElement(By.Name("password")).SendKeys("Password");
            driver.Value.FindElement(By.XPath("//div[@class='form-group'][5]/label/span/input")).Click();

            driver.Value.FindElement(By.CssSelector("input[type='submit']")).Click();
            // Thread.Sleep(3000);
            WebDriverWait wait = new WebDriverWait(driver.Value, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TextToBePresentInElementValue(driver.Value.FindElement(By.CssSelector("input[type='submit']")), "Sign In"));
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            String errorMessage = driver.Value.FindElement(By.CssSelector("div[class='alert alert-danger col-md-12']")).Text;
            TestContext.Progress.WriteLine(errorMessage);

        }

            public static IEnumerable<TestCaseData> AddTestDataConfig()
        {

            // yield  return new TestCaseData("rahulshettyacademy", "learning");
            JasonRedear jr =  new JasonRedear();
            yield return new TestCaseData(jr.extractData("username"), jr.extractData("password"), jr.extractDataArray("products"));
            yield return new TestCaseData(jr.extractData("username"), jr.extractData("password"), jr.extractDataArray("products"));
            yield return new TestCaseData(jr.extractData("username_wrong"), jr.extractData("password_wrong"), jr.extractDataArray("products"));

            //  yield return new TestCaseData("rahulshettyacademy", "learning");
            //  yield return new TestCaseData("rahulshetty", "learning");
        }
    }
}
