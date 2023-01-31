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

namespace TestimDetyra.TestScenarios.Git
{
    public class RepositoryFunctionalities
    {
        [SetUp]
        public void SetUpBeforeEachTest()
        {
            Action.InitializeDriver(Config.GitConfig.Url);
        }

        //[TearDown]
        //public void AfterEachTest()
        //{
        //    if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
        //    {
        //        Action.MakeScreenshot(TestContext.CurrentContext.Test.Name);
        //    }
        //    Driver.driver.Quit();
        //}
        [Test]
        public void CreateRepo()
        {
            Thread.Sleep(1000);
            Driver.driver.FindElement(By.CssSelector("body > div.logged-in.env-production.page-responsive.full-width > div.application-main > div > aside > div > loading-context > div > div.mb-4.Details.js-repos-container.mt-5 > div > h2 > a")).Click();
            Driver.driver.FindElement(By.Name("repository[name]")).SendKeys(Config.GitConfig.RepositoryName);
            Thread.Sleep(1000);
            Driver.driver.FindElement(By.XPath("/html/body/div[1]/div[5]/main/div/form/div[5]/button")).Click();
            Thread.Sleep(1000);

            Assert.AreEqual(Driver.driver.Url, Config.GitConfig.AfterRepoCreatedUrl);
            var reponame = Driver.driver.FindElement(By.CssSelector("#repository-container-header > div.d-flex.flex-wrap.flex-justify-end.mb-3.px-3.px-md-4.px-lg-5 > div > div > strong > a")).Text;
            Assert.AreEqual(reponame.Trim(), Config.GitConfig.RepositoryName.Trim());
        }

        [Test]
        public void ChangeVisibilityOfRepo()
        {
            Thread.Sleep(1000);
            Driver.driver.FindElement(By.CssSelector(".Header-item:nth-child(7)")).Click();
            Thread.Sleep(3000);
            Driver.driver.FindElement(By.CssSelector("body > div.logged-in.env-production.page-responsive.full-width > div.position-relative.js-header-wrapper > header > div.Header-item.position-relative.mr-0.d-none.d-md-flex > details > details-menu > a:nth-child(6)")).Click();
            Thread.Sleep(1000);
            Driver.driver.FindElement(By.XPath("/html/body/div[1]/div[5]/main/div[2]/div/div[2]/turbo-frame/div/div[2]/ul/li[1]/div[1]/div[1]/h3/a")).Click();
            Thread.Sleep(1000);
            var repoName = Driver.driver.FindElement(By.XPath("/html/body/div[1]/div[5]/div/main/div/div[1]/div/div/strong/a")).Text;
            Driver.driver.FindElement(By.Id("settings-tab")).Click();
            Thread.Sleep(1000);
            Driver.driver.FindElement(By.Id("visibility_menu-text")).Click();
            Driver.driver.FindElement(By.ClassName("js-repo-change-visibility-button")).Click();
            Thread.Sleep(1000);
            Driver.driver.FindElement(By.ClassName("js-repo-visibility-proceed-button")).Click();
            Thread.Sleep(100);
            Driver.driver.FindElement(By.ClassName("js-repo-visibility-proceed-button")).Click();
            Thread.Sleep(100);
            Driver.driver.FindElement(By.ClassName("js-repo-visibility-proceed-button")).Click();
            Thread.Sleep(3000);
            if(Driver.driver.Url == $"https://github.com/FatbardhDurmishi/{repoName}/settings/set_visibility")
            {
                Driver.driver.FindElement(By.Name("sudo_password")).SendKeys(Config.GitConfig.Password);
                Driver.driver.FindElement(By.ClassName("btn-primary")).Click();
            }
          
            var repoVisibility = Driver.driver.FindElement(By.XPath("/html/body/div[1]/div[5]/div/main/div/div[1]/div/div/span[4]")).Text;
            Assert.AreEqual(repoVisibility.Trim(), Config.GitConfig.Private);

        }

        [Test]
        public void AddCollaborator()
        {
            Thread.Sleep(2000);
            Driver.driver.FindElement(By.CssSelector(".Header-item:nth-child(7)")).Click();
            Thread.Sleep(3000);
            Driver.driver.FindElement(By.CssSelector("body > div.logged-in.env-production.page-responsive.full-width > div.position-relative.js-header-wrapper > header > div.Header-item.position-relative.mr-0.d-none.d-md-flex > details > details-menu > a:nth-child(6)")).Click();
            Thread.Sleep(3000);
            Driver.driver.FindElement(By.XPath("/html/body/div[1]/div[5]/main/div[2]/div/div[2]/turbo-frame/div/div[2]/ul/li[1]/div[1]/div[1]/h3/a")).Click();
            Thread.Sleep(1000);
            Driver.driver.FindElement(By.Id("settings-tab")).Click();
            Thread.Sleep(2000);
            Driver.driver.FindElement(By.XPath("/html/body/div[1]/div[5]/div/main/turbo-frame/div/div/div[1]/div/ul/li[3]/nav-list/ul/li[2]/ul/li[1]/a")).Click();
            Thread.Sleep(3000);
            Driver.driver.FindElement(By.XPath("/html/body/div[1]/div[5]/div/main/turbo-frame/div/div/div[2]/div/div/div[4]/details/summary")).Click();
            Thread.Sleep(2000);
            Driver.driver.FindElement(By.ClassName("js-repo-add-access-search-input")).SendKeys(Config.GitConfig.Collaborator);
            Thread.Sleep(1000);
            Driver.driver.FindElement(By.Id("repo-add-access-search-results-user-option-0")).Click();
            Thread.Sleep(3000);
            Driver.driver.FindElement(By.XPath("/html/body/div[1]/div[5]/div/main/turbo-frame/div/div/div[2]/div/div/div[4]/details/details-dialog/div/form/div/div[2]/div[2]/button")).Click();
            Assert.IsTrue(Driver.driver.PageSource.Contains(Config.GitConfig.Collaborator));
        }
    }
}
