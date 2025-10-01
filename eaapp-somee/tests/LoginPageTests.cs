using eaapp_somee.models;
using System.Text.Json;

namespace eaapp_somee.tests
{
    [TestFixture]
    public class LoginPageTests
    {
        // Create instance for IWebDriver, Header and LoginPage
        private IWebDriver driver;
        private Header header;
        private LoginPage loginPage;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://eaapp.somee.com/");
            driver.Manage().Window.Maximize();
            header = new Header(driver);
            loginPage = new LoginPage(driver);
        }

        [Test]
        [Category("smoke")]
        [TestCaseSource(nameof(LoginJson))]
        public void TestLogin(LoginModel loginModel)
        {
            header.ClickLogin();
            loginPage.Login(loginModel.UserName, loginModel.Password);
            if (header.IsLoggedIn())
            {
                TestContext.Out.WriteLine("User is logged in as: " + loginModel.UserName);
                Assert.That(header.IsLoggedIn(), Is.True);
            } else if (header.IsLoggedInAdmin())
            {
                TestContext.Out.WriteLine("Admin is logged in.");
                Assert.That(header.IsLoggedInAdmin(), Is.True);

            } else if (!header.IsLoggedIn() && !header.IsLoggedInAdmin())
            {
                TestContext.Out.WriteLine("Login failed for user: " + loginModel.UserName);
                Assert.That(header.IsLoggedIn(), Is.False);
                Assert.That(header.IsLoggedInAdmin(), Is.False);
            }
        }

        private static IEnumerable<TestCaseData> LoginJson()
        {
            var jsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data", "login.json");
            var jsonString = File.ReadAllText(jsonFilePath);
            var loginModel = JsonSerializer.Deserialize<List<LoginModel>>(jsonString);
            foreach (var loginData in loginModel)
            {
                yield return new TestCaseData(loginData).SetName(loginData.TestName);
            }
        }

        [TearDown]
        public void TearDown()
        {
            if (driver != null) {
                driver.Quit();
                driver.Dispose();
            }
        }
    }
}
