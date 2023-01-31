using NUnit.Framework.Interfaces;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestimDetyra.Configs;
using OpenQA.Selenium;
using System.Threading;

namespace TestimDetyra.TestScenarios.Gmail
{
    public class SendingEmails
    {
        [SetUp]
        public void SetUpBeforeEachTest()
        {
            Action.InitializeDriver(Config.GmailConfing.Url);
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
        public void SendEmailToValidAccount()
        {
            Driver.driver.FindElement(By.CssSelector("body > div:nth-child(21) > div.nH > div > div.nH.aqk.aql.bkL > div.aeN.WR.nH.oy8Mbf > div.aic > div > div")).Click();
            Thread.Sleep(1000);
            Driver.driver.FindElement(By.ClassName("agP")).SendKeys(Config.GmailConfing.Receiver);
            Driver.driver.FindElement(By.ClassName("aoT")).SendKeys(Config.GmailConfing.Subject);
            Driver.driver.FindElement(By.ClassName("editable")).SendKeys(Config.GmailConfing.Body);
            Driver.driver.FindElement(By.XPath("/html/body/div[24]/div/div/div/div[1]/div[2]/div[1]/div[1]/div/div/div/div[3]/div/div/div[4]/table/tbody/tr/td[2]/table/tbody/tr[2]/td/div/div/div[4]/table/tbody/tr/td[1]/div/div[2]/div[1]")).Click();
            Thread.Sleep(5000);
            Assert.IsTrue(Driver.driver.PageSource.Contains(Config.GmailConfing.MessageSent));
        }

        [Test]
        public void SendEmailToInvalidAccount()
        {
            Driver.driver.FindElement(By.CssSelector("body > div:nth-child(21) > div.nH > div > div.nH.aqk.aql.bkL > div.aeN.WR.nH.oy8Mbf > div.aic > div > div")).Click();
            Thread.Sleep(1000);
            Driver.driver.FindElement(By.ClassName("agP")).SendKeys(Config.GmailConfing.InvalidEmail);
            Driver.driver.FindElement(By.ClassName("aoT")).SendKeys(Config.GmailConfing.Subject);
            Driver.driver.FindElement(By.ClassName("editable")).SendKeys(Config.GmailConfing.Body);
            Driver.driver.FindElement(By.ClassName("dC")).Click();
            Thread.Sleep(100000);
            Driver.driver.FindElement(By.XPath("//*[@id=\":th\"]")).Click();
            Assert.IsTrue(Driver.driver.PageSource.Contains(Config.GmailConfing.AddressNotFount));
        }
        [Test]
        public void SendScheduledEmail()
        {
            var time = System.DateTime.Now.AddMinutes(5).ToShortTimeString();
            Thread.Sleep(1000);
            Driver.driver.FindElement(By.CssSelector("body > div:nth-child(21) > div.nH > div > div.nH.aqk.aql.bkL > div.aeN.WR.nH.oy8Mbf > div.aic > div > div")).Click();
            Thread.Sleep(1000);
            Driver.driver.FindElement(By.ClassName("agP")).SendKeys(Config.GmailConfing.Receiver);
            //Driver.driver.FindElement(By.XPath("/html/body/div[27]/div/div/div/div[1]/div[2]/div[1]/div[1]/div/div/div/div[3]/div/div/div[4]/table/tbody/tr/td[2]/form/div[1]/table/tbody/tr[1]/td[2]/div/div/div[1]/div/div[3]/div/div/div/div/div/input")).SendKeys(Config.GmailConfing.Receiver);
            Driver.driver.FindElement(By.ClassName("aoT")).SendKeys(Config.GmailConfing.Subject);
            Driver.driver.FindElement(By.ClassName("editable")).SendKeys(Config.GmailConfing.Body);
            Thread.Sleep(1000);
            Driver.driver.FindElement(By.XPath("/html/body/div[25]/div/div/div/div[1]/div[2]/div[1]/div[1]/div/div/div/div[3]/div/div/div[4]/table/tbody/tr/td[2]/table/tbody/tr[2]/td/div/div/div[4]/table/tbody/tr/td[1]/div/div[2]/div[2]/div")).Click();
            //Driver.driver.FindElement(By.Id(":pg")).Click();
            Driver.driver.FindElement(By.ClassName("q8NmZb")).Click();
            Driver.driver.FindElement(By.ClassName("AM")).Click();
            Driver.driver.FindElement(By.XPath("/html/body/div[39]/div[2]/div[2]/div/div[3]/input")).Clear();
            Driver.driver.FindElement(By.XPath("/html/body/div[39]/div[2]/div[2]/div/div[3]/input")).SendKeys(time);
            Driver.driver.FindElement(By.Name("datetimepicker_dialog_confirm")).Click();
            Thread.Sleep(1000);
            Assert.IsTrue(Driver.driver.PageSource.Contains(Config.GmailConfing.EmailScheduledMessage + time));
            //Driver.driver.FindElement(By.Id(":pk")).Click();
            //Thread.Sleep(100000);
            //Driver.driver.FindElement(By.XPath("//*[@id=\":th\"]")).Click();
            //Assert.IsTrue(Driver.driver.PageSource.Contains(Config.GmailConfing.AddressNotFount));
        }
    }
}
