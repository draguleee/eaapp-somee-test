namespace eaapp_somee.models;

public class LoginModel
{
    public required string TestName { get; set; }
    public required string UserName { get; set; }
    public required string Password { get; set; }
    public bool RememberMe { get; set; }
}