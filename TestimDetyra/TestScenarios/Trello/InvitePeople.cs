using NUnit.Framework.Interfaces;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestimDetyra.Configs;
using OpenQA.Selenium;
using System.Threading;
using OpenQA.Selenium.Interactions;

namespace TestimDetyra.TestScenarios.Trello
{
    public class InvitePeople
    {

        [SetUp]
        public void SetUpBeforeEachTest()
        {
            Action.InitializeDriver(Config.Trello.Url);
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

        public void invitePeopleToWorkspace()
        {
            //The dropdown is remembered by the chache and should not be clicked for second time
            //Driver.driver.FindElement(By.XPath("//*[@id=\"content\"]/div/div[2]/div/div/div/div/div[1]/nav/div[2]/div/ul/li[2]/a")).Click();
            //Thread.Sleep(1000);
            Driver.driver.FindElement(By.XPath("//*[@id=\"content\"]/div/div[2]/div/div/div/div/div[1]/nav/div[2]/div/ul/li[2]/ul/li[4]/a")).Click();
            Thread.Sleep(1000);
            Driver.driver.FindElement(By.XPath("//*[@id=\"content\"]/div[3]/div[2]/div[2]/div/div/div/div/div[2]/div[1]/div/div[1]/div/div[2]/div/button")).Click();
            Thread.Sleep(1000);


            var spanConfirmingCopiedLink = Driver.driver.FindElement(By.XPath("//*[@id=\"content\"]/div[3]/div[2]/div[2]/div/div/div/div/div[2]/div[1]/div/div[1]/div/div[2]/div/span"));


            var filterNameInput = Driver.driver.FindElement(By.XPath("//*[@id=\"content\"]/div[3]/div[2]/div[2]/div/div/div/div/div[2]/div[1]/div/div[1]/div/div[3]/div/input"));
            filterNameInput.SendKeys(Keys.Control);
            filterNameInput.SendKeys("V");



            if (spanConfirmingCopiedLink != null)
            {
                Assert.True(true);
                Assert.IsTrue(filterNameInput.Text != null);
            }
            else
            {
                Assert.Fail();
            }
            //*[@id="content"]/div[3]/div[2]/div[2]/div/div/div/div/div[2]/div[1]/div/div[1]/div/div[2]/div/span
            //*[@id="content"]/div/div[2]/div/div/div/div/div[1]/nav/div[2]/div/ul/li[2]/a
        }


        [Test]
        public void removePeopleFromWorkspace()
        {
            Driver.driver.FindElement(By.XPath("//*[@id=\"content\"]/div/div[2]/div/div/div/div/div[1]/nav/div[2]/div/ul/li[2]/ul/li[4]/a")).Click();
            Thread.Sleep(1000);

            Driver.driver.FindElement(By.XPath("//*[@id=\"content\"]/div[3]/div[2]/div[2]/div/div/div/div/div[2]/div[2]/div[1]/div[3]/a[2]")).Click();



            Assert.IsTrue(Driver.driver.FindElement(By.XPath("//*[@id=\"chrome-container\"]/div[4]")) != null);
        }


        [Test]
        public void leaveWorkSpace()
        {
            Driver.driver.FindElement(By.XPath("//*[@id=\"content\"]/div/div[2]/div/div/div/div/div[1]/nav/div[2]/div/ul/li[2]/ul/li[4]/a")).Click();
            Thread.Sleep(1000);

            Driver.driver.FindElement(By.XPath("//*[@id=\"content\"]/div[3]/div[2]/div[2]/div/div/div/div/div[2]/div[2]/div[3]/div[3]/a[2]")).Click();

            


            Assert.IsTrue(Driver.driver.FindElement(By.XPath("//*[@id=\"chrome-container\"]/div[4]")) != null);
        }

    }
}
