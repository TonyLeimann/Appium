using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Appium.Enums;


namespace PitManager_tests// пространство имен
    
{
    [TestFixture]
    public class CheckingChangelog
    {
        private AndroidDriver _driver;

        [OneTimeSetUp]
        public void Setup()
        {
            var serverUri = new Uri(Environment.GetEnvironmentVariable("APPIUM_HOST") ?? "http://127.0.0.1:4808/wd/hub");
            var driverOptions = new AppiumOptions()
            {
                AutomationName = AutomationName.AndroidUIAutomator2,
                PlatformName = "Android",
                DeviceName = "Medium Tablet API 28",

            };
            driverOptions.AddAdditionalAppiumOption("appPackage", "com.rit.pitmanager");
            driverOptions.AddAdditionalAppiumOption("appActivity", "67d42dc com.rit.pitmanager/.ui.AppActivity filter bbfbe42");
            driverOptions.AddAdditionalAppiumOption("noReset", true);

            _driver = new AndroidDriver(serverUri, driverOptions, TimeSpan.FromSeconds(180));
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);

        }
                

        [Test]
          public void CheckChangelog()
        {
            OpenChangelo();
            CloseChangelog();
            ChangeEye();

        }

        private void ChangeEye()
        {
            var eye = _driver.FindElement(By.Id("com.rit.pitmanager:id/text_input_end_icon"));
            eye.Click();
            eye.Click();
        }

        private void CloseChangelog()
        {
            var OK_but = _driver.FindElement(By.XPath("//*[@text='OK']"));
            OK_but.Click();
        }

        private void OpenChangelo()
        {
            var сhanges_but = _driver.FindElement(By.Id("com.rit.pitmanager:id/bt_changelog"));
            сhanges_but.Click();
        }

        [OneTimeTearDown]
         public void TearDown()
         {
            Thread.Sleep(TimeSpan.FromMinutes(5));
            _driver.Dispose();
         }

    }
}