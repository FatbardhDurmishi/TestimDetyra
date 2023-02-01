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

namespace TestimDetyra.TestScenarios.GjirafaSearch
{
    internal class Search
    {

        [SetUp]
        public void SetupBeforeEachTest()
        {
            Action.InitializeDriver(Config.GjirafaConfig.GjirafaUrl);
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
        public void RelevantResults()
        {
            IWebElement searchInput = Driver.driver.FindElement(By.Id("search_input2580"));
            searchInput.SendKeys("Laptop");
            searchInput.SendKeys(Keys.Enter);

            IWebElement resultsContainer = Driver.driver.FindElement(By.ClassName("grid-list"));
            IReadOnlyCollection<IWebElement> titles = resultsContainer.FindElements(By.ClassName("product-title"));

            foreach (IWebElement item in titles)
            {
                Assert.IsTrue(item.Text.ToLower().Contains("laptop"));
            }
        }

        [Test]
        public void SpecialCharacters()
        {
            IWebElement searchInput = Driver.driver.FindElement(By.Id("search_input2580"));
            searchInput.SendKeys("@#$%");
            searchInput.SendKeys(Keys.Enter);

            Assert.AreEqual(Driver.driver.FindElement(By.XPath("//*[@id=\"products_search_11\"]/div/h3")).Text, "Nuk është gjetur asnjë produkt që përshtatet me kriteret e kërkimit tuaj");
            Assert.AreEqual(Driver.driver.FindElement(By.XPath("//*[@id=\"products_search_11\"]/div/ul/li[1]")).Text, "Kontrolloni për gabime gjatë shkrimit te fjalëve");
            Assert.AreEqual(Driver.driver.FindElement(By.XPath("//*[@id=\"products_search_11\"]/div/ul/li[2]")).Text, "Provoni një fjalë tjetër");
            Assert.AreEqual(Driver.driver.FindElement(By.XPath("//*[@id=\"products_search_11\"]/div/ul/li[3]")).Text, "Provoni më pak shkronja");
            Assert.AreEqual(Driver.driver.FindElement(By.XPath("//*[@id=\"products_search_11\"]/div/ul/li[4]")).Text, "Provoni fjali më gjenerale");
        }
    }
}

