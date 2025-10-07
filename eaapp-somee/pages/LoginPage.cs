using SeleniumExtras.WaitHelpers;

namespace eaapp_somee.pages;

public class LoginPage(IWebDriver driver, WebDriverWait wait)
{
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
    IWebElement UserName => wait.Until(ExpectedConditions.ElementExists(By.Name("UserName")));
    IWebElement Password => wait.Until(ExpectedConditions.ElementExists(By.Name("Password")));  
    IWebElement RememberMe => wait.Until(ExpectedConditions.ElementExists(By.Id("RememberMe")));
    IWebElement LoginButton => wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("loginIn")));
    IWebElement Register => wait.Until(ExpectedConditions.ElementToBeClickable(By.PartialLinkText("Register")));
}