using NUnit.Framework.Interfaces;
using NUnit.Framework;
using TestimDetyra.Configs;
using OpenQA.Selenium;
using System.Threading;
using OpenQA.Selenium.Interactions;
using System.Collections.Generic;

namespace TestimDetyra.TestScenarios.Udemy_Learning_Curve
{
    public  class LearningProgress
    {

        [SetUp]
        public void SetUpBeforeEachTest()
        {
            Action.InitializeDriver(Config.Udemy.Url);
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

        public void verifyProgression()
        {
            //The nav bar is not clickable-findable 


            //Thread.Sleep(5000);
            //var learningButton = Driver.driver.FindElement(By.Id("u97-popper-trigger--9"));
            //actions.MoveToElement(learningButton).Build().Perform();


            Driver.driver.Navigate().GoToUrl(Config.Udemy.learningPathUrl);
            Thread.Sleep(2000);
            Driver.driver.FindElement(By.XPath("//*[@id=\"tabs--1-content-0\"]/div/div[2]/div[1]/div/div[1]/div[2]/h3/a")).Click();
            Thread.Sleep(2000);

            Driver.driver.FindElement(By.XPath("//*[@id=\"ct-sidebar-scroll-container\"]/div/div/div[1]/div[2]/div/ul/li[1]/div/div[1]")).Click();
            Driver.driver.FindElement(By.XPath("//*[@id=\"ct-sidebar-scroll-container\"]/div/div/div[1]/div[2]/div/ul/li[2]/div/div[1]")).Click();
            Driver.driver.FindElement(By.XPath("//*[@id=\"ct-sidebar-scroll-container\"]/div/div/div[1]/div[2]/div/ul/li[3]/div/div[1]")).Click();
            Driver.driver.FindElement(By.XPath("//*[@id=\"ct-sidebar-scroll-container\"]/div/div/div[1]/div[2]/div/ul/li[4]/div/div[1]")).Click();


            Thread.Sleep(2000);

            var progressionButton = Driver.driver.FindElement(By.XPath("//*[@id=\"udemy\"]/div[1]/div[1]/div/div/div/div/header/div[3]"));
            Actions actions = new Actions(Driver.driver);
            actions.MoveToElement(progressionButton).Click().Build().Perform();

            var text = progressionButton.Text;

            if(text.Contains("6 of 73 complete"))
            {
                Assert.True(true);
                
            }
            else
            {
                Assert.Fail();
            }

        }


        [Test]
        public void leaveNote()
        {
            Driver.driver.Navigate().GoToUrl(Config.Udemy.learningPathUrl);
            Thread.Sleep(2000);

            Driver.driver.FindElement(By.XPath("//*[@id=\"tabs--1-content-0\"]/div/div[2]/div[1]/div/div[1]/div[2]/h3/a")).Click();

            Thread.Sleep(2000);


            Driver.driver.FindElement(By.XPath("//*[@id=\"scroll-port--2\"]/div[4]/div")).Click();
            Thread.Sleep(2000);

            Driver.driver.FindElement(By.XPath("//*[@id=\"tabs--1-content-3\"]/div/div[1]")).Click();

            Driver.driver.FindElement(By.XPath("//*[@id=\"tabs--1-content-3\"]/div/div[1]/div[2]/form/div[1]/div[2]/div")).Click();
            Thread.Sleep(2000);


            var paragraph = Driver.driver.FindElement(By.XPath("//*[@id=\"tabs--1-content-3\"]/div/div[1]/div[2]/form/div[1]/div[2]/div/p"));
            paragraph.Click();

            IReadOnlyCollection<IWebElement> beforeAddingNote = Driver.driver.FindElements(By.XPath("//*[@id=\"tabs--1-content-3\"]/div/div[3]/div[1]"));

            int totalNotes = beforeAddingNote.Count;

            string text = "document.querySelectorAll(\"p\").forEach((element) => (element.innerHTML = \"aaaaaa\")); ";

            ((IJavaScriptExecutor)Driver.driver).ExecuteScript(text);

            Driver.driver.FindElement(By.XPath("//*[@id=\"tabs--1-content-3\"]/div/div[1]/div[2]/form/div[2]/button[2]")).Click();

            Thread.Sleep(2000);

            totalNotes = totalNotes + 1;
            var secondNote = Driver.driver.FindElement(By.XPath("//*[@id=\"tabs--1-content-3\"]/div/div[3]/div["+totalNotes+"]"));


            if (secondNote != null)
            {
                Assert.True(true);
            }
            else
            {
                Assert.Fail();
            }
            
            Thread.Sleep(6000);

        }


        [Test]

        public void openQuestion()
        {

            Driver.driver.Navigate().GoToUrl(Config.Udemy.learningPathUrl);
            Thread.Sleep(1000);

            Driver.driver.FindElement(By.XPath("//*[@id=\"tabs--1-content-0\"]/div/div[2]/div[1]/div/div[1]/div[2]/h3/a")).Click();

            Thread.Sleep(1000);


            Driver.driver.FindElement(By.XPath("//*[@id=\"scroll-port--2\"]/div[4]/div")).Click();
            Thread.Sleep(1000);

            Driver.driver.FindElement(By.XPath("//*[@id=\"scroll-port--2\"]/div[3]/div")).Click();
            Thread.Sleep(1000);

            Driver.driver.FindElement(By.XPath("//*[@id=\"tabs--1-content-2\"]/div/div/button")).Click();
            Thread.Sleep(1000);

            Driver.driver.FindElement(By.XPath("//*[@id=\"tabs--1-content-2\"]/div/div/form/fieldset/label[1]")).Click();
            Thread.Sleep(1000);

            Driver.driver.FindElement(By.XPath("//*[@id=\"tabs--1-content-2\"]/div/div/form/button")).Click();
            Thread.Sleep(1000);

            var input = Driver.driver.FindElement(By.XPath("/html/body/div[1]/div[1]/div/div/main/div/div[3]/div/div/section/div/div[4]/div/div/div[2]/div[1]/div/input"));
            input.Click();
            input.SendKeys("AAAA");



            Driver.driver.FindElement(By.XPath("//*[@id=\"tabs--1-content-2\"]/div/div/div[2]/div[3]/button")).Click();
            Thread.Sleep(2000);
            //string text = "document.querySelectorAll(\"input\").forEach((element) => (element.innerHTML = \"aaaaaa\")); ";
            //((IJavaScriptExecutor)Driver.driver).ExecuteScript(text);


            var newQuestionDivPopUp = Driver.driver.FindElement(By.XPath("//*[@id=\"tabs--1-content-2\"]/div/div/div[2]"));
            //*[@id="tabs--1-content-2"]/div/div/div[2]

            if(newQuestionDivPopUp != null)
            {
                Assert.True(true); ;
            }
            else
            {
                Assert.Fail();
            }

        }
    }
}
