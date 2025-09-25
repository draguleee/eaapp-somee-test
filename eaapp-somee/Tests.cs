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
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("file:///C:/Users/ADragu/source/repos/udemy/Selenium%20with%20C%23/eaapp-somee-test/eaapp-somee/webpages/index.html");
            driver.Manage().Window.Maximize();

            // 2. Find the Email and Password fields and enter credentials
            driver.FindElement(By.Id("email")).SendKeys("test@example.com");
            driver.FindElement(By.Id("password")).SendKeys("password");

            // 3. Select an option from the dropdown
            IWebElement country = driver.FindElement(By.Id("country"));
            SelectElement countryDropdown = new SelectElement(country);
            countryDropdown.SelectByText("Romania");

            // 4. Select one or more options from the multi-select list
            IWebElement skills = driver.FindElement(By.Id("skills"));
            SelectElement skillsDropdown = new SelectElement(skills);
            skillsDropdown.SelectByValue("html");
            skillsDropdown.SelectByValue("css");
            skillsDropdown.SelectByValue("js");

            // 5. Print all selected options from the multi-select list
            IList<IWebElement> options = skillsDropdown.AllSelectedOptions;
            Console.Write("Selected options: ");
            foreach (var option in options)
            {
                Console.Write(option.Text + " ");
            }

            // 6. Select all checkboxes
            driver.FindElement(By.Name("pref_newsletter")).Click();
            driver.FindElement(By.Name("pref_updates")).Click();
            driver.FindElement(By.Name("pref_marketing")).Click();

            // 7. Select one of the radio buttons
            IWebElement email = driver.FindElement(By.XPath("//input[@value='email']"));
            IWebElement phone = driver.FindElement(By.XPath("//input[@value='phone']"));
            if (email.Selected)
            {
                phone.Click();
            } else
            {
                email.Click();
            }

            // 8. Click the Submit button
            driver.FindElement(By.XPath("//button[@type='submit']")).Submit();
            IWebElement status = driver.FindElement(By.Id("status"));
            Assert.That(status.Displayed, Is.True, "Form submission failed.");

        }

        [TearDown]
        public void TearDown() { }
    }
}
