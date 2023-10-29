namespace Domain.Models;

public class UserLegacy
{
    public int Id { get; set; } 
    public string UserName { get; set; }
    public string Password { get; set; }

    public UserLegacy(string userName, string password)
    {
        this.UserName = userName;
        this.Password = password;
    }
}