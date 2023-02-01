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
    public class TrelloCards
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

        public void createCardViaTemplate()
        {
            //The dropdown is remembered by the chache and should not be clicked for second time
            //Driver.driver.FindElement(By.XPath("//*[@id=\"content\"]/div/div[2]/div/div/div/div/div[1]/nav/div[2]/div/ul/li[2]/a")).Click();
            //Thread.Sleep(1000);

            
            Driver.driver.FindElement(By.XPath("//*[@id=\"content\"]/div/div[2]/div/div/div/div/div[1]/nav/div[2]/div/ul/li[2]/ul/li[1]/a")).Click();
            Thread.Sleep(1000);
            Driver.driver.FindElement(By.XPath("//*[@id=\"content\"]/div/div[2]/div/div/div/div/div[2]/div/div/div/div[3]/div[2]/div[2]/ul/li/a")).Click();
            Thread.Sleep(1000);
            

            var board = Driver.driver.FindElement(By.XPath("//*[@id=\"board\"]/div[16]/div/div[2]"));
            IReadOnlyCollection<IWebElement> countBeforeAdding = board.FindElements(By.CssSelector("#board > div:nth-child(16) > div > div.list-cards.u-fancy-scrollbar.u-clearfix.js-list-cards.js-sortable.ui-sortable > a:nth-child(1)"));
            Thread.Sleep(2000);

            Driver.driver.FindElement(By.XPath("//*[@id=\"board\"]/div[16]/div/div[3]/div/div/div/a")).Click();
            Thread.Sleep(2000);
            
            Driver.driver.FindElement(By.XPath("/html/body/div[7]/div/section/div/div/div/a/div")).Click();
            Thread.Sleep(2000);

            Driver.driver.FindElement(By.XPath("/html/body/div[7]/div/section/div/div/button")).Click();
            Thread.Sleep(2000);

            IReadOnlyCollection<IWebElement> countAfterAdding = board.FindElements(By.CssSelector("#board > div:nth-child(16) > div > div.list-cards.u-fancy-scrollbar.u-clearfix.js-list-cards.js-sortable.ui-sortable > a:nth-child(1)"));

            if (countAfterAdding.Count() > countBeforeAdding.Count())
            {
                Assert.True(true);
            }
            else
            {
                Assert.Fail();
            }
        }


        [Test]

        public void makeCardTemplate()
        {
            Driver.driver.FindElement(By.XPath("//*[@id=\"content\"]/div/div[2]/div/div/div/div/div[1]/nav/div[2]/div/ul/li[2]/ul/li[1]/a")).Click();
            Thread.Sleep(1000);
            Driver.driver.FindElement(By.XPath("//*[@id=\"content\"]/div/div[2]/div/div/div/div/div[2]/div/div/div/div[3]/div[2]/div[2]/ul/li/a")).Click();
            Thread.Sleep(1000);
                                                
            Driver.driver.FindElement(By.XPath("//*[@id=\"board\"]/div[16]/div/div[2]/a[1]/div[3]")).Click();
            Thread.Sleep(1000);
            
            Driver.driver.FindElement(By.XPath("//*[@id=\"chrome-container\"]/div[3]/div/div/div/div[5]/div[5]/div/a[3]")).Click();
            Thread.Sleep(2000);

            Driver.driver.FindElement(By.XPath("//*[@id=\"board\"]/div[16]/div/div[2]/a[3]/div[3]/div[2]/span[1]/div[1]")).Click();

            var popUpHeaderTemplate = Driver.driver.FindElement(By.XPath("//*[@id=\"chrome-container\"]/div[3]/div/div/div/div[2]/div/div/div/h3"));

            Assert.AreEqual("This is a Template card.", popUpHeaderTemplate.Text);

            
        }



    }
}
