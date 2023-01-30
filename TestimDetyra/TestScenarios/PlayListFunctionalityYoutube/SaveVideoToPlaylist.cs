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

        [Test]
        public void SaveVideoToNewPlaylist()
        {
            Driver.driver.FindElement(By.Id("video-title")).Click();
            Thread.Sleep(1000);
            Driver.driver.FindElement(By.XPath("/html/body/ytd-app/div[1]/ytd-page-manager/ytd-watch-flexy/div[5]/div[1]/div/div[2]/ytd-watch-metadata/div/div[2]/div[2]/div/div/ytd-menu-renderer/yt-button-shape/button")).Click();
            Thread.Sleep(1000);
            Driver.driver.FindElement(By.CssSelector("#items > ytd-menu-service-item-renderer:nth-child(1)")).Click();
            Thread.Sleep(1000);
            Driver.driver.FindElement(By.XPath("/html/body/ytd-app/ytd-popup-container/tp-yt-paper-dialog/ytd-add-to-playlist-renderer/div[3]/ytd-add-to-playlist-create-renderer/ytd-compact-link-renderer/a/tp-yt-paper-item/div[1]")).Click();
            Thread.Sleep(1000);
            Driver.driver.FindElement(By.CssSelector("#input-1 > input")).SendKeys(Config.YoutubeConfig.PlaylistName);
            Thread.Sleep(1000);
            Driver.driver.FindElement(By.CssSelector("#actions > ytd-button-renderer > yt-button-shape > button")).Click();
            Thread.Sleep(1000);
            Assert.IsTrue(Driver.driver.PageSource.Contains(Config.YoutubeConfig.AddedSuccessfully));
        }

        [Test]
        public void SaveVideoToExistingPlaylist()
        {
            Driver.driver.FindElement(By.Id("video-title")).Click();
            Thread.Sleep(1000);
            Driver.driver.FindElement(By.XPath("/html/body/ytd-app/div[1]/ytd-page-manager/ytd-watch-flexy/div[5]/div[1]/div/div[2]/ytd-watch-metadata/div/div[2]/div[2]/div/div/ytd-menu-renderer/yt-button-shape/button")).Click();
            Thread.Sleep(1000);
            Driver.driver.FindElement(By.CssSelector("#items > ytd-menu-service-item-renderer:nth-child(1)")).Click();
            Thread.Sleep(1000);
            Driver.driver.FindElement(By.CssSelector("#playlists > ytd-playlist-add-to-option-renderer:nth-child(2)")).Click();
            Thread.Sleep(1000);
            Assert.IsTrue(Driver.driver.PageSource.Contains(Config.YoutubeConfig.AddedSuccessfully));
        }
    }
}
