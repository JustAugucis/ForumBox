using Domain.DTOs;
using Domain.Models;

namespace Application.LogicInterfaces;

public interface IUserLogic
{
    Task<User> CreateAsync(UserRegisterDto userRegisterDto);
    Task<User?> GetByUsernameAsync(SearchUserParametersDto searchUserParametersDto);
    Task<User?> GetByIdAsync(SearchUserParametersDto searchUserParametersDto);
}