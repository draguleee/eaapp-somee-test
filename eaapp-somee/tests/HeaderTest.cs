namespace eaapp_somee.tests
{
    [TestFixture]
    public class HeaderTest
    {
        private IWebDriver driver;
        private Header header;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://eaapp.somee.com/");
            driver.Manage().Window.Maximize();
            header = new Header(driver);
        }

        [Test, Category("Header")]
        public void ClickHeaderElementsLoggedOut()
        {
            header.ClickHomeElement();
            Assert.Multiple(() =>
            {
                Assert.That(driver.Url, Is.EqualTo("http://eaapp.somee.com/"), "Home URL is incorrect.");
                Assert.That(driver.Title, Does.Contain("Home"), "Home title is incorrect.");
                Assert.That(driver.PageSource.Contains("EA Employee App"), Is.True, "Home page source does not contain expected text.");
            });

            header.ClickAbout();
            Assert.Multiple(() =>
            {
                Assert.That(driver.Url, Is.EqualTo("http://eaapp.somee.com/Home/About"), "About URL is incorrect.");
                Assert.That(driver.Title, Does.Contain("About"), "About title is incorrect.");
                Assert.That(driver.PageSource.Contains("web application"), Is.True, "About page source does not contain expected text.");
            });

            header.ClickEmployeeList();
            Assert.Multiple(() =>
            {
                Assert.That(driver.Url, Is.EqualTo("http://eaapp.somee.com/Employee"), "Employee List URL is incorrect.");
                Assert.That(driver.Title, Does.Contain("Employee"), "Employee List title is incorrect.");
                Assert.That(driver.PageSource.Contains("Search"), Is.True, "Employee List page source does not contain a Search field / button.");
            });

            header.ClickRegister();
            Assert.Multiple(() =>
            {
                Assert.That(driver.Url, Is.EqualTo("http://eaapp.somee.com/Account/Register"), "Register URL is incorrect.");
                Assert.That(driver.Title, Does.Contain("Register"), "Register title is incorrect.");
                Assert.That(driver.PageSource.Contains("new account"), Is.True, "Register page source does not contain expected text.");
            });

            header.ClickLogin();
            Assert.Multiple(() =>
            {
                Assert.That(driver.Url, Is.EqualTo("http://eaapp.somee.com/Account/Login"), "Login URL is incorrect.");
                Assert.That(driver.Title, Does.Contain("Login"), "Login title is incorrect.");
                Assert.That(driver.PageSource.Contains("Remember me"), Is.True, "Login page source does not contain expected text.");
            });

        }

        [TearDown]
        public void TearDown()
        {
            driver.Dispose();
        }
    }
}
