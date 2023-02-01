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
using OpenQA.Selenium.Interactions;

namespace TestimDetyra.TestScenarios.PaymentGjirafa
{
    internal class Payment
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
        public void MultipleSelections()
        {
            var firstProduct = Driver.driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div[4]/div/div[3]/div/div/div/div/div[5]/div/form/div[1]/div[1]/a/img"));
            Thread.Sleep(1000);
            firstProduct.Click();
            IWebElement button = Driver.driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div[4]/div/div[2]/div/div[2]/div[2]/div/div[3]/div/a"));
            IJavaScriptExecutor js = (IJavaScriptExecutor)Driver.driver;
            js.ExecuteScript("arguments[0].click()", button);


            var isSelectedRaiffeisen = Driver.driver.FindElement(By.XPath("/html/body/div[10]/div[2]/div/div/form/div[5]/div/label[4]/div"));
            Actions action = new Actions(Driver.driver);
            action.MoveToElement(isSelectedRaiffeisen).Build().Perform();

            var isSelectedTEB = Driver.driver.FindElement(By.XPath("/html/body/div[10]/div[2]/div/div/form/div[5]/div/label[5]/div"));
            action.MoveToElement(isSelectedTEB).Build().Perform();

            Assert.IsFalse(isSelectedRaiffeisen.Selected);
        }
        [Test]
        public void NullValues()
        {
            var firstProduct = Driver.driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div[4]/div/div[3]/div/div/div/div/div[5]/div/form/div[1]/div[1]/a/img"));
            Thread.Sleep(1000);
            firstProduct.Click();
            IWebElement button = Driver.driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div[4]/div/div[2]/div/div[2]/div[2]/div/div[3]/div/a"));
            IJavaScriptExecutor js = (IJavaScriptExecutor)Driver.driver;
            js.ExecuteScript("arguments[0].click()", button);

            Driver.driver.FindElement(By.Id("cr_product_data_call_request_198841_name")).SendKeys(Config.GjirafaConfig.Name);
            Driver.driver.FindElement(By.Id("cr_product_data_call_request_198841_lastname")).SendKeys(Config.GjirafaConfig.Surname);
            Driver.driver.FindElement(By.Id("cr_product_data_call_request_198841_email")).SendKeys(Config.GjirafaConfig.Email);
            Driver.driver.FindElement(By.Id("cr_product_data_call_request_198841_address")).SendKeys(Config.GjirafaConfig.Address);
            Driver.driver.FindElement(By.Id("cr_product_data_call_request_198841_phone")).SendKeys(Config.GjirafaConfig.Tel);


            var isSelectedRaiffeisen = Driver.driver.FindElement(By.XPath("/html/body/div[10]/div[2]/div/div/form/div[5]/div/label[4]"));
            Actions action = new Actions(Driver.driver);
            action.MoveToElement(isSelectedRaiffeisen).Build().Perform();

            IWebElement checkTerms = Driver.driver.FindElement(By.XPath("/html/body/div[10]/div[2]/div/div/form/div[7]/div/label/input"));
            IJavaScriptExecutor js1 = (IJavaScriptExecutor)Driver.driver;
            js1.ExecuteScript("arguments[0].click()", checkTerms);

            IWebElement clickButton = Driver.driver.FindElement(By.XPath("/html/body/div[10]/div[2]/div/div/form/div[8]"));
            IJavaScriptExecutor js2 = (IJavaScriptExecutor)Driver.driver;
            js2.ExecuteScript("arguments[0].click()", clickButton);

            Assert.AreEqual(Driver.driver.Url, "https://gjirafa50.com/kompjuter-laptop-server-1/laptop-5/aksesore-37/canta-mbrojtese-1/canta-2/%C3%A7ant%C3%AB-shpine-lenovo-1b210-p%C3%ABr-laptop-15.6-gri/?def");

        }
    }
}
