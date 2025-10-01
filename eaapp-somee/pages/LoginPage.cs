namespace eaapp_somee.pages
{
    public class LoginPage
    {
        // Create instance for IWebDriver
        private readonly IWebDriver driver;
        private readonly Header header;

        // Constructor for LoginPage
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        // Method to log the user into the application
        public void Login(string username, string password)
        {
            UserName.EnterText(username);
            Password.EnterText(password);
            if (!RememberMe.Selected) RememberMe.ClickElement();
            LoginButton.SubmitForm();
        }

        // Method to navigate to the registration page
        public void ClickRegister() => Register.ClickElement();

        // Define web elements using properties
        IWebElement UserName => driver.FindElement(By.Name("UserName"));
        IWebElement Password => driver.FindElement(By.Name("Password"));
        IWebElement RememberMe => driver.FindElement(By.Id("RememberMe"));
        IWebElement LoginButton => driver.FindElement(By.Id("loginIn"));
        IWebElement Register => driver.FindElement(By.PartialLinkText("Register"));
    }
}
