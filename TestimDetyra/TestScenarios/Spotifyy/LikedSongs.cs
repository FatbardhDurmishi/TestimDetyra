using NUnit.Framework.Interfaces;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestimDetyra.Configs;
using OpenQA.Selenium;
using System.Threading;

namespace TestimDetyra.TestScenarios.Spotifyy
{
    public class LikedSongs
    {
        [SetUp]
        public void SetUpBeforeEachTest()
        {
            Action.InitializeDriver(Config.SpotifyLikedSongsConfig.Url);
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
        public void LikeNewSong()
        {

            //IReadOnlyCollection<IWebElement> resultContainer = Driver.driver.FindElements(By.ClassName("LunqxlFIupJw_Dkx6mNx"));
            //IWebElement element = resultContainer.ElementAt(0);
            //element.Click();
            //Thread.Sleep(2000);


            //IReadOnlyCollection<IWebElement> resultContainer = Driver.driver.FindElements(By.ClassName("vnCew8qzJq3cVGlYFXRI"));
            //IWebElement element = resultContainer.ElementAt(0);
            //element.Click();

            Thread.Sleep(7000);
            Driver.driver.FindElement(By.XPath("//*[@id=\"main\"]/div/div[2]/div[3]/div[1]/div[2]/div[2]/div/div/div[2]/main/section/div/div/section[2]/div[2]/div[1]/div")).Click();
            Thread.Sleep(7000);

            Driver.driver.FindElement(By.XPath("//*[@id=\"main\"]/div/div[2]/div[3]/div[1]/div[2]/div[2]/div/div/div[2]/main/div/section/div[2]/div[3]/div/div[2]/div[2]/div[1]/div/div[5]/button[1]")).Click();
            Thread.Sleep(7000);

            Driver.driver.FindElement(By.XPath("//*[@id=\"main\"]/div/div[2]/nav/div[1]/div[2]/div/div[2]/a")).Click();
            Thread.Sleep(2000);

            var topOfListOfLikedSongs = Driver.driver.FindElement(By.XPath("//*[@id=\"main\"]/div/div[2]/div[3]/div[1]/div[2]/div[2]/div/div/div[2]/main/section/div[4]/div/div[2]/div[2]/div[1]/div/div[2]/div/a/div"));


            Assert.AreEqual("Cinnamon Girl", topOfListOfLikedSongs.Text);
        }
    }
}
