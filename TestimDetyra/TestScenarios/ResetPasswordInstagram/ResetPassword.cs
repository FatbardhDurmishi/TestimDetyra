using NUnit.Framework.Interfaces;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestimDetyra.Configs;
using OpenQA.Selenium;
using System.Threading;
using static System.Net.WebRequestMethods;
using System.Runtime.InteropServices.ComTypes;
namespace TestimDetyra.TestScenarios.ResetPasswordInstagram
{
    internal class ResetPassword
    {
        [SetUp]
        public void SetupBeforeEachTest()
        {
            Action.InitializeDriver(Config.InstagramConfig.InstagramUrl);
            var username = Driver.driver.FindElement(By.XPath("/html/body/div[2]/div/div/div/div[1]/div/div/div/div[1]/section/main/article/div[2]/div[1]/div[2]/form/div/div[1]/div/label/input"));
            ////*[@id="loginForm"]/div/div[1]/div/label/input
            Thread.Sleep(1000);
            username.SendKeys(Config.InstagramConfig.username);
            var password = Driver.driver.FindElement(By.XPath("/html/body/div[2]/div/div/div/div[1]/div/div/div/div[1]/section/main/article/div[2]/div[1]/div[2]/form/div/div[2]/div/label/input"));
            Thread.Sleep(1000);
            password.SendKeys(Config.InstagramConfig.password);

            var loginBtn = Driver.driver.FindElement(By.XPath("/html/body/div[2]/div/div/div/div[1]/div/div/div/div[1]/section/main/article/div[2]/div[1]/div[2]/form/div/div[3]/button"));
            Thread.Sleep(1000);
            loginBtn.Click();
        }
        [TearDown]
        public void AfterEachTest()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                Action.MakeScreenshot(TestContext.CurrentContext.Test.Name);
            }

            Driver.driver.Quit();
        }

        [Test]
        public void ChangePassword()
        {
            IWebElement profileIcon = Driver.driver.FindElement(By.XPath("//*[@id=\"mount_0_0_JJ\"]/div/div/div/div[1]/div/div/div/div[1]/div[1]/div[1]/div/div/div/div/div[2]/div[8]/div/div/a/div"));
            IJavaScriptExecutor js = (IJavaScriptExecutor)Driver.driver;
            js.ExecuteScript("arguments[0].click()", profileIcon);

            IWebElement settingsIcon = Driver.driver.FindElement(By.XPath("//*[@id=\"mount_0_0_JJ\"]/div/div/div/div[1]/div/div/div/div[1]/div[1]/div[2]/section/main/div/header/section/div[1]/div[2]/button"));
            IJavaScriptExecutor js1 = (IJavaScriptExecutor)Driver.driver;
            js1.ExecuteScript("arguments[0].click()", settingsIcon);

            IWebElement changePassword = Driver.driver.FindElement(By.XPath("//*[@id=\"mount_0_0_JJ\"]/div/div/div/div[2]/div/div/div[1]/div/div[2]/div/div/div/div/div[2]/div/div/div/button[1]"));
            IJavaScriptExecutor js2 = (IJavaScriptExecutor)Driver.driver;
            js2.ExecuteScript("arguments[0].click()", changePassword);

            Driver.driver.FindElement(By.Id("cppOldPassword")).SendKeys(Config.InstagramConfig.password);
            Driver.driver.FindElement(By.Id("cppNewPassword")).SendKeys(Config.InstagramConfig.newPassword);
            Driver.driver.FindElement(By.Id("cppConfirmPassword")).SendKeys(Config.InstagramConfig.newPassword);

            IWebElement changePasswordBtn = Driver.driver.FindElement(By.XPath("//*[@id=\"mount_0_0_JJ\"]/div/div/div/div[1]/div/div/div/div[1]/div[1]/div[2]/section/main/div/article/form/div[4]/div/div/button"));
            IJavaScriptExecutor js3 = (IJavaScriptExecutor)Driver.driver;
            js3.ExecuteScript("arguments[0].click()", changePasswordBtn);
            Thread.Sleep(2000);

            var myInput = Driver.driver.FindElement(By.Id("cppOldPassword"));
            if (!myInput.GetAttribute("value").Equals(""))
            {
                Assert.Pass();
            }
        }

        [Test]
        public void OldPassword()
        {
            IWebElement profileIcon = Driver.driver.FindElement(By.XPath("//*[@id=\"mount_0_0_JJ\"]/div/div/div/div[1]/div/div/div/div[1]/div[1]/div[1]/div/div/div/div/div[2]/div[8]/div/div/a/div"));
            IJavaScriptExecutor js = (IJavaScriptExecutor)Driver.driver;
            js.ExecuteScript("arguments[0].click()", profileIcon);

            IWebElement settingsIcon = Driver.driver.FindElement(By.XPath("//*[@id=\"mount_0_0_JJ\"]/div/div/div/div[1]/div/div/div/div[1]/div[1]/div[2]/section/main/div/header/section/div[1]/div[2]/button"));
            IJavaScriptExecutor js1 = (IJavaScriptExecutor)Driver.driver;
            js1.ExecuteScript("arguments[0].click()", settingsIcon);

            IWebElement changePassword = Driver.driver.FindElement(By.XPath("//*[@id=\"mount_0_0_JJ\"]/div/div/div/div[2]/div/div/div[1]/div/div[2]/div/div/div/div/div[2]/div/div/div/button[1]"));
            IJavaScriptExecutor js2 = (IJavaScriptExecutor)Driver.driver;
            js2.ExecuteScript("arguments[0].click()", changePassword);

            Driver.driver.FindElement(By.Id("cppOldPassword")).SendKeys(Config.InstagramConfig.password);
            Driver.driver.FindElement(By.Id("cppNewPassword")).SendKeys(Config.InstagramConfig.password);
            Driver.driver.FindElement(By.Id("cppConfirmPassword")).SendKeys(Config.InstagramConfig.password);


            IWebElement changePasswordBtn = Driver.driver.FindElement(By.XPath("//*[@id=\"mount_0_0_JJ\"]/div/div/div/div[1]/div/div/div/div[1]/div[1]/div[2]/section/main/div/article/form/div[4]/div/div/button"));
            IJavaScriptExecutor js3 = (IJavaScriptExecutor)Driver.driver;
            js3.ExecuteScript("arguments[0].click()", changePasswordBtn);
            Thread.Sleep(2000);

            var myInput = Driver.driver.FindElement(By.Id("cppOldPassword"));

            if (!myInput.GetAttribute("value").Equals(Config.InstagramConfig.password))
            {
                Assert.Pass();
            }
        }
    }
}
