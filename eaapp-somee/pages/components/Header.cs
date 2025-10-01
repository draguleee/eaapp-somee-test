namespace eaapp_somee.pages.components
{
    public class Header
    {
        // Create instance for IWebDriver
        private readonly IWebDriver driver;

        // Constructor for Header
        public Header(IWebDriver driver)
        {
            this.driver = driver;
        }

        // Methods to check if the user is logged in (normal user & admin)
        public bool IsLoggedIn()
        {
            try
            {
                return HelloLink.Displayed && LogoffLink.Displayed;
            }
            catch (NoSuchElementException) { return false; }
        }

        public bool IsLoggedInAdmin()
        {
            try
            {
                return ManageUsersLink.Displayed && EmployeeDetailsLink.Displayed && HelloLink.Displayed && LogoffLink.Displayed;
            }
            catch (NoSuchElementException) { return false; }
        }


        // Methods to interact with web elements
        public void ClickHome() => HomeLink.ClickElement();
        public void ClickAbout() => AboutLink.ClickElement();
        public void ClickEmployeeList() => EmployeeListLink.ClickElement();
        public void ClickEmployeeDetails() => EmployeeDetailsLink.ClickElement();
        public void ClickManageUsers() => ManageUsersLink.ClickElement();
        public void ClickHello() => HelloLink.ClickElement();
        public void ClickRegister() => RegisterLink.ClickElement();
        public void ClickLogin() => LoginLink.ClickElement();
        public void ClickLogoff() => LogoffLink.ClickElement();

        // Define web elements using properties
        IWebElement HomeLink => driver.FindElement(By.LinkText("Home"));
        IWebElement AboutLink => driver.FindElement(By.LinkText("About"));
        IWebElement EmployeeListLink => driver.FindElement(By.PartialLinkText("List"));
        IWebElement EmployeeDetailsLink => driver.FindElement(By.PartialLinkText("Details"));
        IWebElement ManageUsersLink => driver.FindElement(By.PartialLinkText("Manage"));
        IWebElement HelloLink => driver.FindElement(By.PartialLinkText("Hello"));
        IWebElement RegisterLink => driver.FindElement(By.Id("registerLink"));
        IWebElement LoginLink => driver.FindElement(By.Id("loginLink"));
        IWebElement LogoffLink => driver.FindElement(By.LinkText("Log off"));
    }
}
