using System.Security.Claims;
using Application.LogicInterfaces;
using Domain.DTOs;
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

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Post>>> GetAsync([FromQuery] SearchPostParametersDto? dto) // supports filtering only by title for now
    {
        try
        {
            SearchPostParametersDto parameters = new();
            parameters.Title = dto.Title;
            parameters.CreatorName = dto.CreatorName;
            parameters.body = dto.body;

            IEnumerable<Post> posts = await postLogic.GetAsync(parameters);
            return Ok(posts);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }

    }
}