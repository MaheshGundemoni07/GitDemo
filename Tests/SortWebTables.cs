using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Support.UI;
using System.Collections;
using CsharpSelFrameworl.Utilities;

namespace SeleniumLearning
{
    [Parallelizable(ParallelScope.Self)]
    public class SortWebTables : Base
    {

       
        [Test]
        public void sortTables()
        {
            ArrayList a = new ArrayList();

          IWebElement dropDown =  driver.Value.FindElement(By.Id("page-menu"));
            SelectElement s1 = new SelectElement(dropDown);
            s1.SelectByText("20");
         IList<IWebElement> allVeggies = driver.Value.FindElements(By.XPath("//td[1]"));

            foreach(IWebElement eachVeggie in allVeggies)
            {
                a.Add(eachVeggie.Text);
            }

            foreach(String v in a)
            {
                TestContext.Progress.WriteLine(v);
            }

            a.Sort();

            foreach (String z in a)
            {
                TestContext.Progress.WriteLine(z);
            }

            driver.Value.FindElement(By.CssSelector("th[aria-label*='Veg/fruit name']")).Click();

            ArrayList b = new ArrayList();

            IList<IWebElement> sortedVeggies = driver.Value.FindElements(By.XPath("//td[1]"));

            foreach (IWebElement eachVeggie in sortedVeggies)
            {
                b.Add(eachVeggie.Text);
            }

            Assert.That(a, Is.EqualTo(b));
        }


    }
}
