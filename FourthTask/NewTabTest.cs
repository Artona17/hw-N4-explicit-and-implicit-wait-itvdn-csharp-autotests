using OpenQA.Selenium.Chrome;

namespace FourthTask
{
    [Author("Ludmila")]
    [TestFixture]
    public class Tests
    {
        /// <summary>
        /// Setting up a Selenium Chrome WebDriver with an implicit wait timeout.
        /// </summary>
        private IWebDriver driver;
        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            driver.Navigate().GoToUrl("https://google.com");
        }

        /// <summary>
        /// Test that checks if we successfully open two test tabs in one browser -
        /// with google.com and saucedemo.com - and that we have a particular text on the second one
        /// after login.
        /// </summary>
        [Test]
        public void NewTabTest()
        {
            string TitleOfNewPage = "Products";
            driver.SwitchTo().NewWindow(WindowType.Tab);
            var tabs = driver.WindowHandles;
            driver.Navigate().GoToUrl("https://google.com");
            IWebElement searchTxt = driver.FindElement(By.Name("q"));
            searchTxt.SendKeys("Armenian wine");
            searchTxt.SendKeys(Keys.Enter);
            driver.SwitchTo().Window(tabs[0]);
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            IWebElement loginTxt = driver.FindElement(By.XPath("//input[@name='user-name']"));
            IWebElement passwordTxt = driver.FindElement(By.XPath("//input[@name='password']"));

            loginTxt.SendKeys("standard_user");
            passwordTxt.SendKeys("secret_sauce");
            loginTxt.SendKeys(Keys.Enter);

            IWebElement newPageTitle = driver.FindElement(By.XPath("//span[@class='title']"));

            Assert.That(newPageTitle.Text == TitleOfNewPage);
        }

        /// <summary>
        /// Quitting our Chrome driver.
        /// </summary>
        [TearDown]
        public void Teardown()
        {
            driver.Quit();
        }
    }
}