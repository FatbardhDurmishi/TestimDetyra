using NUnit.Framework.Interfaces;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestimDetyra.Configs;
using OpenQA.Selenium;
using System.Threading;
using OpenQA.Selenium.Interactions;

namespace TestimDetyra.TestScenarios.Udemy_Shopping_Card
{
    public class ShopingCard
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
        public void AddToCard()
        {
            Driver.driver.FindElement(By.XPath("//*[@id=\"udemy\"]/div[1]/div[2]/div/nav/ul/li[1]")).Click();
            Thread.Sleep(1000);

            Driver.driver.FindElement(By.XPath(Config.Udemy.MostPopularCourseNumber1Xpath)).Click();
            Thread.Sleep(1000);

            var addCartButton = Driver.driver.FindElement(By.XPath("//*[@id=\"udemy\"]/div[1]/div[2]/div/div/div[1]/div[2]/div[1]/div/div[1]/div[2]/div/div/div[1]/div/div[4]/div[1]/button"));
            addCartButton.Click();

            Thread.Sleep(1000);

            var popUpConfirm = Driver.driver.FindElement(By.XPath("//*[@id=\"udemy\"]/div[9]/div/div[2]/button"));

            Assert.True(popUpConfirm != null);
            Thread.Sleep(5000);
            var closePopUpButton = Driver.driver.FindElement(By.ClassName("modal--close-button--3l8Mg"));


            //For some reasons using //closePopUpButton.Click(); would not work
            //Throwing element not clickable at point (x,y), other element would recieve the click
            //Stackoverflow says element not visible to click 
            Actions actions = new Actions(Driver.driver);
            actions.MoveToElement(closePopUpButton).Click().Build().Perform();



            Assert.AreEqual("Go to cart", addCartButton.Text);

            addCartButton.Click();
            Thread.Sleep(1000);

            var itemOnCard = Driver.driver.FindElement(By.XPath("//*[@id=\"udemy\"]/div[1]/div[2]/div/div/div[3]/div[1]/div[1]/div/ul[1]/div[2]/div/div[2]/h3/a"));
            Assert.True(itemOnCard != null);

        }

        [Test]
        public void ApplyDiscount()
        {
            //*[@id="u98-popper-trigger--13"]
            //*[@id="u98-popper-trigger--13"]
            //*[@id="u168-popper-trigger--13"]

            //Driver.driver.FindElement(By.XPath("//*[@id=\"udemy\"]/div[1]/div[1]/div[3]/div[7]")).Click();

            Driver.driver.Navigate().GoToUrl(Config.Udemy.cartURL);

            Thread.Sleep(2000);
            var discountInput2 = Driver.driver.FindElement(By.XPath("//*[@id=\"udemy\"]/div[1]/div[2]/div/div/div[3]/div[2]/div/div[3]/div/div[3]/form"));
            discountInput2.SendKeys("TEST");

            var applyDiscountButton = Driver.driver.FindElement(By.XPath("//*[@id=\"udemy\"]/div[1]/div[2]/div/div/div[3]/div[2]/div/div[3]/div/div[3]/form/button"));
            applyDiscountButton.Click();

            Assert.IsTrue(Driver.driver.PageSource.Contains(AlertMessages.DiscountCantApply.InvalidCouptonError));


        }

        [Test]
        public void MoveToWishList()
        {
            Driver.driver.Navigate().GoToUrl(Config.Udemy.cartURL);
            //var itemOnCard = Driver.driver.FindElement(By.XPath("//*[@id=\"udemy\"]/div[1]/div[2]/div/div/div[3]/div[1]/div[1]/div/ul[1]/div[2]/div/div[2]/h3/a"));
            Thread.Sleep(2000);
            Driver.driver.FindElement(By.XPath("//*[@id=\"udemy\"]/div[1]/div[2]/div/div/div[3]/div[1]/div[1]/div/ul[1]/div/div/div[6]/button[3]")).Click();
            //*[@id="udemy"]/div[1]/div[2]/div/div/div[3]/div[1]/div[1]/div/ul[1]/div/div/div[6]/button[3]
            //*[@id="udemy"]/div[1]/div[2]/div/div/div[3]/div[1]/div[1]/div/ul[1]/div/div/div[6]/button[3]

            //*[@id="udemy"]/div[1]/div[2]/div/div/div[3]/div[1]/div[1]/div/ul[1]/div/div/div[6]/button[3]
        }
    }
}
