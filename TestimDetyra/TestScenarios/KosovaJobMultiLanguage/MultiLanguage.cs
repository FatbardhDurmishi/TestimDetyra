using NUnit.Framework.Interfaces;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestimDetyra.Configs;
using OpenQA.Selenium;
using System.Threading;

namespace TestimDetyra.TestScenarios.KosovaJobMultiLanguage
{
    public class MultiLanguage
    {
        [SetUp]
        public void SetUpBeforeEachTest()
        {
            Action.InitializeDriver(Config.KosovaJobMultiLanguageConfig.Url);
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
        public void EnglishTest()
        {
            Driver.driver.FindElement(By.ClassName("menuAreaUrlsLangs")).Click();
            Thread.Sleep(1000);
            var profileText = Driver.driver.FindElement(By.XPath("/html/body/div[1]/div/div/div/a[7]/div")).Text;
            var productsText = Driver.driver.FindElement(By.CssSelector("body > div.headerArea > div > div > div > div:nth-child(6) > a")).Text;
            var contactText = Driver.driver.FindElement(By.CssSelector("body > div.headerArea > div > div > div > a:nth-child(4) > div")).Text;

            Assert.AreEqual(profileText.Trim(), Config.KosovaJobMultiLanguageConfig.Profile.Trim());
            Assert.AreEqual(contactText.Trim(), Config.KosovaJobMultiLanguageConfig.Contact.Trim());
            Assert.AreEqual(productsText.Trim(), Config.KosovaJobMultiLanguageConfig.Products.Trim());

        }

        [Test]
        public void AlbanianTest()
        {
            Driver.driver.FindElement(By.ClassName("menuAreaUrlsLangs")).Click();
            Thread.Sleep(1000);
            var profileText = Driver.driver.FindElement(By.XPath("/html/body/div[1]/div/div/div/a[7]/div")).Text;
            var productsText = Driver.driver.FindElement(By.CssSelector("body > div.headerArea > div > div > div > div:nth-child(6) > a")).Text;
            var contactText = Driver.driver.FindElement(By.CssSelector("body > div.headerArea > div > div > div > a:nth-child(4) > div")).Text;

            Assert.AreEqual(profileText.Trim(), Config.KosovaJobMultiLanguageConfig.Profili.Trim());
            Assert.AreEqual(contactText.Trim(), Config.KosovaJobMultiLanguageConfig.Kontakt.Trim());
            Assert.AreEqual(productsText.Trim(), Config.KosovaJobMultiLanguageConfig.Produktet.Trim());
        }
    }
}
