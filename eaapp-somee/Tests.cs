using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eaapp_somee
{
    [TestFixture]
    public class Tests
    {
        [SetUp]
        public void SetUp() { }

        [Test]
        public void FirstTest()
        {
            // 1. Create a new instance of Selenium WebDriver
            IWebDriver driver = new ChromeDriver();

            // 2. Navigate to the specified URL (EA App)
            driver.Navigate().GoToUrl("https://www.google.com/");

            // 3. Maximize the browser window
            driver.Manage().Window.Maximize();

            // 4. Find the element 
            driver.FindElement(By.ClassName("sy4vM")).Click();
            var search = driver.FindElement(By.Name("q"));

            // 5. Type "Selenium" in the search box
            search.SendKeys("Selenium");
            search.SendKeys(Keys.Enter);
        }

        [Test]
        public void EaTest()
        {
            // 1. Create a new instance of Selenium WebDriver and navigate to the EA App URL
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://eaapp.somee.com/");
            driver.Manage().Window.Maximize();

            // 2. Find and click the Login link
            driver.FindElement(By.Id("loginLink")).Click(); 

            // 3. Find the UserName and Password fields and enter credentials
            driver.FindElement(By.Name("UserName")).SendKeys("admin");
            driver.FindElement(By.Name("Password")).SendKeys("password");

            // 4. Submit the login form by clicking the Login button
            driver.FindElement(By.Id("loginIn")).Submit();
            // driver.FindElement(By.ClassName("btn")).Submit();
            // driver.FindElement(By.CssSelector(".btn")).Submit();
        }

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
            skills.MultiSelect([ "html", "css", "js" ], "value");

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
            } else
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
}
