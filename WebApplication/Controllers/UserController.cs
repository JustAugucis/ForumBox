using Application.LogicInterfaces;
using Domain.DTOs;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;

namespace WebApplication1.Controllers;

[ApiController]
//[Route("[controller]")]
[Route("api/CreateUser")]
public class UsersController : ControllerBase
{
    private readonly IUserLogic userLogic;

    public UsersController(IUserLogic userLogic)
    {
        this.userLogic = userLogic;
    }
    
    [HttpPost]
    public async Task<ActionResult<User>> CreateAsync(UserRegisterDto dto)
    {
        try
        {
            User user = await userLogic.CreateAsync(dto); // dies
            return Created($"api/CreateUser{user}", user); // tried messing witht this
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

}