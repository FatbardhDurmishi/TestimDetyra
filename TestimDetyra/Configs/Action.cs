using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestimDetyra.Configs
{
    public static class Action
    {
        public static void InitializeDriver(string url)
        {
            var userDataDir = @"C:\Users\fatba\AppData\Local\Google\Chrome\User Data";

            ChromeOptions options = new ChromeOptions();
            options.AddArgument($"--user-data-dir={userDataDir}");
            //options.AddArgument("--no-sandbox"); // Bypass OS security model
            //options.AddArgument("--disable-dev-shm-usage"); // overcome limited resource problems
            //options.AddArgument("--headless");
            Driver.driver = new ChromeDriver(options);


            Driver.driver.Manage().Window.Maximize();
            Driver.driver.Navigate().GoToUrl(url);
        }

        public static void MakeScreenshot(string filename)
        {
            string dir = Config.ScreenshotDir;
            Screenshot browserScreenshot = ((ITakesScreenshot)Driver.driver).GetScreenshot();
            browserScreenshot.SaveAsFile(dir + @"\" + filename + ".png", ScreenshotImageFormat.Png);
        }
    }
}
