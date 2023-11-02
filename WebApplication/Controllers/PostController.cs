using System.Security.Claims;
using Application.LogicInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Dtos;
using Shared.Models;

namespace WebApplication1.Controllers;


[ApiController]
[Route("[controller]")]
public class PostController : ControllerBase
{
    private readonly IPostLogic postLogic;

    public PostController(IPostLogic postLogic)
    {
        this.postLogic = postLogic;
    }

    [HttpPost]
    public async Task<ActionResult<Post>> CreateAsync(PostDto dto)
    {
        try
        {
            Post post = await postLogic.CreatePostAsync(dto); 
            return Created($"/Post/{post.Title}", post); // tried messing witht this
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }


}