namespace eaapp_somee.tests;

[TestFixture]
public class LoginPageTests
{
    // Create instance for IWebDriver, Header and LoginPage
    private IWebDriver driver;
    private WebDriverWait wait;
    private Header header;
    private LoginPage loginPage;

    [SetUp]
    public void SetUp()
    {
        driver = new ChromeDriver();
        driver.Navigate().GoToUrl("http://eaapp.somee.com/");
        driver.Manage().Window.Maximize();
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10))
        {
            PollingInterval = TimeSpan.FromMilliseconds(200),
            Message = "Element to be searched not found"

        };
        header = new Header(driver);
        loginPage = new LoginPage(driver, wait);
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
            // header.IsLoggedIn().Should().BeTrue();           // With FluentAssertions
            // header.IsLoggedInAdmin().Should().BeFalse();     // With FluentAssertions
        }
        else if (header.IsLoggedInAdmin())
        {
            TestContext.Out.WriteLine("Admin is logged in.");
            Assert.That(header.IsLoggedInAdmin(), Is.True);
            // header.IsLoggedInAdmin().Should().BeTrue();      // With FluentAssertions
            // header.IsLoggedIn().Should().BeFalse();          // With FluentAssertions
        }
        else if (!header.IsLoggedIn() && !header.IsLoggedInAdmin())
        {
            TestContext.Out.WriteLine("Login failed for user: " + loginModel.UserName);
            Assert.That(header.IsLoggedIn(), Is.False);
            Assert.That(header.IsLoggedInAdmin(), Is.False);
            // header.IsLoggedIn().Should().BeFalse();          // With FluentAssertions
            // header.IsLoggedInAdmin().Should().BeFalse();     // With FluentAssertions
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
        if (driver != null)
        {
            driver.Quit();          
            driver.Dispose();
        }
    }
}