using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;
using CsharpSelFrameworl.Utilities;

namespace SeleniumLearning
{
    [Parallelizable(ParallelScope.Self)]
    internal class WindowHandles : Base
    {
        
        [Test]
        public void WindowHandle()
        {
            String email = "mentor@rahulshettyacademy.com";
            driver.Value.FindElement(By.CssSelector(".blinkingText")).Click();
            String parentWindow = driver.Value.CurrentWindowHandle;
           Assert.AreEqual(2, driver.Value.WindowHandles.Count);
           String child = driver.Value.WindowHandles[1];
            driver.Value.SwitchTo().Window(child);
            String[] splittedString = driver.Value.FindElement(By.CssSelector(".red")).Text.Split("at");
           String[] splittedString2 = splittedString[1].Trim().Split(" ");
            Assert.AreEqual(email, splittedString2[0]);
            driver.Value.SwitchTo().Window(parentWindow);
            driver.Value.FindElement(By.Id("username")).SendKeys(splittedString2[0]);
            



        }
    }
}
