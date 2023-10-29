

using Shared.Models;

public interface IAuthService
{
    Task RegisterUser(User user);
    Task<Shared.Models.User> ValidateUser(string username, string password);
}