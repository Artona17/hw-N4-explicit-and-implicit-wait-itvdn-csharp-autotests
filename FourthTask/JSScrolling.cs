using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace FourthTask
{
    [Author("Ludmila")]
    [TestFixture]
    public class JSTests
    {

        /// <summary>
        /// Setting up a Selenium Chrome WebDriver.
        /// </summary>
        private IWebDriver driver;
        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://testprovider.com/ru");
        }
        /// <summary>
        /// Test that checks that we have particular text on the page after explicit wait for the load of
        /// the page.
        /// </summary>
        [Test]
        public void JSScrollingTest()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollBy(0,4500)");

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement result = wait.Until(e => e.FindElement(By.LinkText("Каталог тестов")));
            Assert.That(result.Text == "Каталог тестов");
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