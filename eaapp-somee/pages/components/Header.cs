namespace eaapp_somee.pages.components
{
    public class Header
    {
        protected readonly IWebDriver _driver;
        protected readonly WebDriverWait _wait;

        public Header(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }

        public Header ClickHomeElement()
        {
            Home.ClickElement();
            return this;
        }

        public Header ClickAbout()
        {
            About.ClickElement();
            return this;
        }

        public Header ClickEmployeeList()
        {
            EmployeeList.ClickElement();
            return this;
        }

        public Header ClickRegister()
        {
            Register.ClickElement();
            return this;
        }

        public Header ClickLogin()
        {
            Login.ClickElement();
            return this;
        }

        IWebElement Home => _driver.FindElement(By.LinkText("Home"));
        IWebElement About => _driver.FindElement(By.LinkText("About"));
        IWebElement EmployeeList => _driver.FindElement(By.PartialLinkText("Employee"));
        IWebElement Register => _driver.FindElement(By.Id("registerLink"));  
        IWebElement Login => _driver.FindElement(By.Id("loginLink"));   
    }
}
