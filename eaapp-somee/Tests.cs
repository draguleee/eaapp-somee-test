namespace eaapp_somee;

[TestFixture]
public class Tests
{
    [SetUp]
    public void SetUp() { }

    [Test]
    public void SampleWebpage()
    {
        // 1. Create a new instance of Selenium WebDriver and navigate to the local HTML file
        var driver = new ChromeDriver();
        string baseDir = AppDomain.CurrentDomain.BaseDirectory;
        string fullPath = Path.Combine(baseDir, "..", "..", "..", "webpages", "index.html");
        driver.Navigate().GoToUrl(new Uri(fullPath).AbsoluteUri);
        driver.Manage().Window.Maximize();

        // 2. Find the Email and Password fields and enter credentials
        var emailField = driver.FindElement(By.Id("email"));
        emailField.EnterText("test@example.com");
        var passwordField = driver.FindElement(By.Id("password"));
        passwordField.EnterText("password");

        // 3. Select an option from the dropdown
        var country = driver.FindElement(By.Id("country"));
        country.SelectDropdown("Romania", "text");

        // 4. Select one or more options from the multi-select list
        var skills = driver.FindElement(By.Id("skills"));
        skills.MultiSelect(["html", "css", "js"], "value");

        // 5. Print all selected options from the multi-select list
        var selectedOptions = skills.GetSelectedOptions();
        Console.WriteLine("Selected skills: " + string.Join(", ", selectedOptions));

        // 6. Select all checkboxes
        driver.FindElement(By.Name("pref_newsletter")).Click();
        driver.FindElement(By.Name("pref_updates")).Click();
        driver.FindElement(By.Name("pref_marketing")).Click();

        // 7. Select one of the radio buttons
        var email = driver.FindElement(By.XPath("//input[@value='email']"));
        var phone = driver.FindElement(By.XPath("//input[@value='phone']"));
        if (email.Selected)
        {
            phone.ClickElement();
        }
        else
        {
            email.ClickElement();
        }

        // 8. Click the Submit button
        driver.FindElement(By.XPath("//button[@type='submit']")).Submit();
        var status = driver.FindElement(By.Id("status"));
        Assert.That(status.Displayed, Is.True, "Form submission failed.");

    }

    [TearDown]
    public void TearDown() { }
}
