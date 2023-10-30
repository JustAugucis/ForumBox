using Domain.DTOs;
using Shared.Models;


namespace HttpClients.ClientInterfaces;

public interface IUserService
{
    Task<User> Register(UserRegisterDto dto);
}