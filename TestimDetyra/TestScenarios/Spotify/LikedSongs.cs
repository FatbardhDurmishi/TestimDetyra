using NUnit.Framework.Interfaces;
using NUnit.Framework;
using TestimDetyra.Configs;
using OpenQA.Selenium;
using System.Threading;

namespace TestimDetyra.TestScenarios.PlayListFunctionalityYoutube
{
    public class SaveVideoToPlaylist
    {
        [SetUp]
        public void SetUpBeforeEachTest()
        {
            Action.InitializeDriver(Config.YoutubeConfig.Url);
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


    }
}
