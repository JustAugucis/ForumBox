using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Domain.DTOs;
using Domain.Models;

namespace Application.Logic;

public class UserLogic : IUserLogic
{
    private readonly IUserDao userDao;
    
    public UserLogic(IUserDao userDao)
    {
        this.userDao = userDao;
    }

    public async Task<User> CreateAsync(UserRegisterDto dto)
    {
        User? existing = await userDao.GetByUsernameAsync(dto.UserName);
        if (existing != null)
            throw new Exception("Username already taken!");

        ValidateData(dto);
        User toCreate = new User(dto.UserName, dto.Password);
        
        User created = await userDao.CreateAsync(toCreate);
        
        return created;
    }

    public Task<User?> GetByUsernameAsync(SearchUserParametersDto searchUserParametersDto)
    {
        throw new NotImplementedException();
    }

    public Task<User?> GetByIdAsync(SearchUserParametersDto searchUserParametersDto)
    {
        throw new NotImplementedException();
    }
    
    
    private static void ValidateData(UserRegisterDto dto)
    {
        string userName = dto.UserName;
        string password = dto.Password;

        if (userName.Length < 3)
            throw new Exception("Username must be at least 3 characters!");

        if (userName.Length > 15)
            throw new Exception("Username must be less than 16 characters!");
        
        if (password.Length < 3)
            throw new Exception("Password must be at least 3 characters!");

        if (password.Length > 15)
            throw new Exception("Password must be less than 16 characters!");
    }
}