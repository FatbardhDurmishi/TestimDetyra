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
            Driver.driver.FindElement(By.XPath(Config.SpotifyLikedSongsConfig.RandomPlaylist)).Click();
            Thread.Sleep(1000);

            //IReadOnlyCollection<IWebElement> resultContainer = Driver.driver.FindElements(By.ClassName("LunqxlFIupJw_Dkx6mNx"));
            //IWebElement element = resultContainer.ElementAt(0);
            //element.Click();
            //Thread.Sleep(2000);


            IReadOnlyCollection<IWebElement> resultContainer = Driver.driver.FindElements(By.ClassName("vnCew8qzJq3cVGlYFXRI"));
            IWebElement element = resultContainer.ElementAt(0);
            element.Click();
            Thread.Sleep(2000);

            


        }
    }
}
