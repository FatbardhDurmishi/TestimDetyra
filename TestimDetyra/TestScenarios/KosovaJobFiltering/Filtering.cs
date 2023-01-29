using NUnit.Framework.Interfaces;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;
using TestimDetyra.Configs;
using System.Threading;

namespace TestimDetyra.TestScenarios.KosovaJobFiltering
{
    public class Filtering
    {

        [SetUp]
        public void SetUpBeforeEachTest()
        {
            Action.InitializeDriver(Config.KosovaJobConfig.Url);
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
        public void ByJobPosition()
        {
            var searchBar = Driver.driver.FindElement(By.ClassName("chosen-search-input"));
            searchBar.Click();
            Driver.driver.FindElement(By.XPath("/html/body/div[8]/div/div/div[3]/div/div[2]/div[2]/div/ul/li[2]")).Click();
            //jobPosition.Click();
            var button = Driver.driver.FindElement(By.ClassName("submitNone"));
            button.Click();
            IReadOnlyCollection<IWebElement> jobTitle = Driver.driver.FindElements(By.ClassName("jobListTitle"));

            Assert.AreEqual(Driver.driver.Url.ToString(), "https://kosovajob.com/?jobPosition=3");

            //qetu mujna me bo sikurse te metoda 3 qe mu kon ma te sakte,por po mer shume kohe deri sa te perfundohet se ka shume rezultate
            foreach (IWebElement job in jobTitle)
            {
                Assert.IsTrue(job.Text.Contains(Config.KosovaJobConfig.JobPositon));
            }
        }


        [Test]
        public void ByLocation()
        {
            var searchBar = Driver.driver.FindElement(By.XPath("/html/body/div[8]/div/div/div[3]/div/div[3]/div[2]/ul/li/input"));
            searchBar.Click();
            Driver.driver.FindElement(By.XPath("/html/body/div[8]/div/div/div[3]/div/div[3]/div[2]/div/ul/li[1]")).Click();
            var button = Driver.driver.FindElement(By.ClassName("submitNone"));
            button.Click();
            IReadOnlyCollection<IWebElement> locations = Driver.driver.FindElements(By.ClassName("jobListCity"));

            Assert.AreEqual(Driver.driver.Url.ToString(), "https://kosovajob.com/?cityID=1");

            foreach (IWebElement city in locations)
            {
                Assert.AreEqual(city.Text, Config.KosovaJobConfig.JobLocation);
            }
        }

        [Test]
        public void ApplyEveryOption()
        {
            var JobsearchBar = Driver.driver.FindElement(By.ClassName("chosen-search-input"));
            JobsearchBar.Click();
            Driver.driver.FindElement(By.XPath("/html/body/div[8]/div/div/div[3]/div/div[2]/div[2]/div/ul/li[2]")).Click();

            var CitysearchBar = Driver.driver.FindElement(By.XPath("/html/body/div[8]/div/div/div[3]/div/div[3]/div[2]/ul/li/input"));
            CitysearchBar.Click();
            Driver.driver.FindElement(By.XPath("/html/body/div[8]/div/div/div[3]/div/div[3]/div[2]/div/ul/li[1]")).Click();

            var timeSearchBar = Driver.driver.FindElement(By.XPath("/html/body/div[8]/div/div/div[3]/div/div[4]/div[2]/ul/li/input"));
            timeSearchBar.Click();
            Driver.driver.FindElement(By.XPath("/html/body/div[8]/div/div/div[3]/div/div[4]/div[2]/div/ul/li")).Click();
            var button = Driver.driver.FindElement(By.ClassName("submitNone"));
            button.Click();
            Thread.Sleep(1000);
            int jobs = Driver.driver.FindElements(By.ClassName("jobListCnts")).Count();

            //masi orari spe qet ne home page a qysh mi thon, po klikojna ne qdo rezultat individualisht edhe e kshyrum a e ka orarin,kategorin edhe lokacionin qysh e kena kerku
            //qetu e bona masi nuk po ka shum rezultate e vanon ma pak se kom mujt edhe te dy testet tjera amo vanohet shume
            for (int i = 1; i < jobs; i++)
            {
                Thread.Sleep(1000);
                Driver.driver.FindElement(By.CssSelector($"div.jobListCnts:nth-child({i})")).Click();
                Thread.Sleep(1000);
                var jobPosition = Driver.driver.FindElement(By.XPath("/html/body/div[8]/div/div/div[2]/div[1]/div[3]/b"));
                var time = Driver.driver.FindElement(By.XPath("/html/body/div[8]/div/div/div[2]/div[1]/div[5]/b"));
                var location = Driver.driver.FindElement(By.XPath("/html/body/div[8]/div/div/div[2]/div[1]/div[6]/span/a"));

                Assert.AreEqual(jobPosition.Text, Config.KosovaJobConfig.JobCategory);
                Assert.AreEqual(time.Text, Config.KosovaJobConfig.Time);
                Assert.AreEqual(location.Text,Config.KosovaJobConfig.JobLocation);
                Driver.driver.Navigate().GoToUrl("https://kosovajob.com/?jobPosition=3&cityID=1&orariID=1");
            }
        }
    }
}
