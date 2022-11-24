using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using System.Configuration;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using NUnit.Framework.Interfaces;

namespace CsharpSelFrameworl.Utilities
{
    public class Base
    {

        //public  IWebDriver driver;
        public ThreadLocal<IWebDriver> driver = new ThreadLocal<IWebDriver>();

        String browserName;
       public ExtentReports extent;
        public ExtentTest test;

        [OneTimeSetUp]
        public void Setup()
        {
            String workingDirectory = Environment.CurrentDirectory;
            String projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            String reportPath = projectDirectory + "//index.html";
            var htmlReporter = new ExtentHtmlReporter(reportPath);
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
            extent.AddSystemInfo("Host Name", "Local Host");
            extent.AddSystemInfo(" Test Environment", "Chrome");
            extent.AddSystemInfo("Tester", "Mahesh");


        }

        [SetUp]
        public void StartBrowser()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
            browserName = TestContext.Parameters["browserName"];
            if (browserName == null)
            {
                browserName = ConfigurationManager.AppSettings["browser"];
            }
            InitBrowser(browserName);
            //  driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            //  driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Value.Manage().Window.Maximize();
            driver.Value.Url = "https://rahulshettyacademy.com/loginpagePractise/";
        }

        public void InitBrowser(String browserName)
        {
            switch (browserName)
            {
                case "Firefox":
                    new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
                    driver.Value = new FirefoxDriver();
                    break;

                case "Chrome":
                    new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                    driver.Value = new ChromeDriver();
                    break;

                case "Edge":
                    new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
                    driver.Value = new EdgeDriver();
                    break;

            }

        }

        public IWebDriver getDriver()
        {
            return driver.Value;
        }

        /* public static JasonRedear GetData()
         {
            return new JasonRedear();
         } */

        [TearDown]
        public void AfterMehtod()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stackTrace = TestContext.CurrentContext.Result.StackTrace;//whenever test is failed, all log details will get stored in StackTrace
            DateTime time = DateTime.Now;
            String fileName = "Screenshot_" + time.ToString("h_mm_ss") + ".png";

            if (status == TestStatus.Failed)
            {
                test.Fail("Test Failed", CaptureScreenshot(driver.Value, fileName));
                test.Log(Status.Fail, "test failed with logtrace" + stackTrace);
            }
            else if (status == TestStatus.Passed)
            {

            }
            extent.Flush();
            driver.Value.Quit();
        }

        public MediaEntityModelProvider CaptureScreenshot(IWebDriver driver, String screenShotName)
        {
            ITakesScreenshot ts =(ITakesScreenshot)driver;
            var screenShot = ts.GetScreenshot().AsBase64EncodedString;
            return MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenShot, screenShotName).Build();
            
        }
            
    }
}
