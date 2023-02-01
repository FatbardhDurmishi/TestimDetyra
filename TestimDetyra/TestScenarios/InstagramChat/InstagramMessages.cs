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
using OpenQA.Selenium.Support.UI;

namespace TestimDetyra.TestScenarios.InstagramChat
{
    internal class InstagramMessages
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
        public void InstaChat()
        {
            IWebElement messageIcon = Driver.driver.FindElement(By.XPath("//*[@id=\"mount_0_0_FV\"]/div/div/div/div[1]/div/div/div/div[1]/div[1]/div[1]/div/div/div/div/div[2]/div[5]/div/a/div/div[1]"));
            IJavaScriptExecutor js = (IJavaScriptExecutor)Driver.driver;
            js.ExecuteScript("arguments[0].click()", messageIcon);

            IWebElement sendMessage = Driver.driver.FindElement(By.XPath("/html/body/div[2]/div/div/div/div[1]/div/div/div/div[1]/div[1]/div/div[2]/div/section/div/div/div/div/div[2]/div/div[3]/div/button]"));
            IJavaScriptExecutor js1 = (IJavaScriptExecutor)Driver.driver;
            js1.ExecuteScript("arguments[0].click()", sendMessage);

            IWebElement searchInput = Driver.driver.FindElement(By.XPath("/html/body/div[2]/div/div/div/div[2]/div/div/div[1]/div/div[2]/div/div/div/div/div[2]/div/div[2]/div[1]/div/div[2]/input"));
            searchInput.SendKeys(Config.InstagramConfig.personToChat);
            searchInput.SendKeys(Keys.Enter);

            SelectElement dropDown = new SelectElement(Driver.driver.FindElement(By.ClassName("_abm4")));
            dropDown.SelectByText("bulzaarexhepii");


            IWebElement nextBtn = Driver.driver.FindElement(By.ClassName("_aagz]"));
            IJavaScriptExecutor js2 = (IJavaScriptExecutor)Driver.driver;
            js2.ExecuteScript("arguments[0].click()", nextBtn);

            IWebElement messageText = Driver.driver.FindElement(By.XPath("/html/body/div[2]/div/div/div/div[1]/div/div/div/div[1]/div[1]/div/div[2]/div/section/div/div/div/div/div[2]/div[2]/div/div[2]/div/div/div[2]/textarea"));
            searchInput.SendKeys(Config.InstagramConfig.chatMessage);
            searchInput.SendKeys(Keys.Enter);

            Assert.IsTrue(Driver.driver.PageSource.Contains(Config.InstagramConfig.chatMessage));
        }

        [Test]
        public void InstaGroupChat()
        {
            IWebElement messageIcon = Driver.driver.FindElement(By.XPath("//*[@id=\"mount_0_0_FV\"]/div/div/div/div[1]/div/div/div/div[1]/div[1]/div[1]/div/div/div/div/div[2]/div[5]/div/a/div/div[1]"));
            IJavaScriptExecutor js = (IJavaScriptExecutor)Driver.driver;
            js.ExecuteScript("arguments[0].click()", messageIcon);

            IWebElement sendMessage = Driver.driver.FindElement(By.XPath("/html/body/div[2]/div/div/div/div[1]/div/div/div/div[1]/div[1]/div/div[2]/div/section/div/div/div/div/div[2]/div/div[3]/div/button]"));
            IJavaScriptExecutor js1 = (IJavaScriptExecutor)Driver.driver;
            js1.ExecuteScript("arguments[0].click()", sendMessage);

            IWebElement searchInput = Driver.driver.FindElement(By.XPath("/html/body/div[2]/div/div/div/div[2]/div/div/div[1]/div/div[2]/div/div/div/div/div[2]/div/div[2]/div[1]/div/div[2]/input"));
            searchInput.SendKeys(Config.InstagramConfig.personToChat);
            searchInput.SendKeys(Keys.Enter);
            SelectElement dropDown = new SelectElement(Driver.driver.FindElement(By.ClassName("_abm4")));
            dropDown.SelectByText("bulzaarexhepii");

            IWebElement searchInput2 = Driver.driver.FindElement(By.XPath("/html/body/div[2]/div/div/div/div[2]/div/div/div[1]/div/div[2]/div/div/div/div/div[2]/div/div[2]/div[1]/div/div[2]/input"));
            searchInput.SendKeys(Config.InstagramConfig.personGroup);
            searchInput.SendKeys(Keys.Enter);
            SelectElement dropDown2 = new SelectElement(Driver.driver.FindElement(By.ClassName("_abm4")));
            dropDown2.SelectByText("albaarexhepii");

            IWebElement nextBtn = Driver.driver.FindElement(By.ClassName("_aagz]"));
            IJavaScriptExecutor js2 = (IJavaScriptExecutor)Driver.driver;
            js2.ExecuteScript("arguments[0].click()", nextBtn);

            IWebElement messageText = Driver.driver.FindElement(By.XPath("/html/body/div[2]/div/div/div/div[1]/div/div/div/div[1]/div[1]/div/div[2]/div/section/div/div/div/div/div[2]/div[2]/div/div[2]/div/div/div[2]/textarea"));
            searchInput.SendKeys(Config.InstagramConfig.groupMessage);
            searchInput.SendKeys(Keys.Enter);

            Assert.IsTrue(Driver.driver.PageSource.Contains(Config.InstagramConfig.groupMessage));
        }
    }
}
