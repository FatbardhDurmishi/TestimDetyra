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

namespace TestimDetyra.TestScenarios.HelpDesk
{
    class HelpDesk
    {

        [SetUp]
        public void SetupBeforeEachTest()
        {
            Action.InitializeDriver(Config.HelpDeskConfig.HelpDeskUrl);
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
        public void NewTicket()
        {
            IWebElement newTicket = Driver.driver.FindElement(By.XPath("//*[@id=\"landing_page\"]/div/div[2]/a[1]"));
            IJavaScriptExecutor js = (IJavaScriptExecutor)Driver.driver;
            js.ExecuteScript("arguments[0].click()", newTicket);

            Driver.driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div/div/form/h3/div[1]/div[2]/div/div[1]/div[2]/input")).SendKeys(Config.HelpDeskConfig.fullName);
            Driver.driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div/div/form/h3/div[1]/div[2]/div/div[2]/div[2]/input")).SendKeys(Config.HelpDeskConfig.email);

            SelectElement dropDown = new SelectElement(Driver.driver.FindElement(By.Id("topicId")));
            dropDown.SelectByValue("24");

            //Driver.driver.FindElement(By.XPath("//*[@id=\"dynamic-form\"]/div/div[2]/div/div/div[2]/span/div/div[2]/p")).SendKeys(Config.HelpDeskConfig.statement);

            IWebElement createTicket = Driver.driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div/div/form/h3/p/input[1]"));
            IJavaScriptExecutor js1 = (IJavaScriptExecutor)Driver.driver;
            js1.ExecuteScript("arguments[0].click()", createTicket);


            Assert.AreEqual(Driver.driver.Url, "https://helpdesk.riinvest.net/open.php");
            Assert.AreEqual(Driver.driver.FindElement(By.Id("msg_notice")).Text, Config.HelpDeskConfig.confirmationCreate);
        }
        [Test]
        public void CheckStatus()
        {
            IWebElement newTicket = Driver.driver.FindElement(By.XPath("//*[@id=\"landing_page\"]/div/div[2]/a[2]"));
            IJavaScriptExecutor js = (IJavaScriptExecutor)Driver.driver;
            js.ExecuteScript("arguments[0].click()", newTicket);

            Driver.driver.FindElement(By.Id("email")).SendKeys(Config.HelpDeskConfig.email);
            Driver.driver.FindElement(By.Id("ticketno")).SendKeys(Config.HelpDeskConfig.ticketNum);

            IWebElement getStatus = Driver.driver.FindElement(By.XPath("//*[@id=\"clientLogin\"]/div/div[1]/div[4]/p/input"));
            IJavaScriptExecutor js1 = (IJavaScriptExecutor)Driver.driver;
            js1.ExecuteScript("arguments[0].click()", getStatus);

            Assert.AreEqual(Driver.driver.FindElement(By.Id("msg_notice")).Text, Config.HelpDeskConfig.confirmationStatus);
        }
    }
}