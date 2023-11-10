using Application.LogicInterfaces;
using Domain.DTOs;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;

namespace WebApplication1.Controllers;


[ApiController]
[Route("[controller]")]
public class CommentController : ControllerBase
{

    private readonly ICommentLogic commentLogic;

    public CommentController(ICommentLogic commentLogic)
    {
        this.commentLogic = commentLogic;
    }

    [HttpPost]
    public async Task<ActionResult<Comment>> CreateAsync(CreateNewCommentAtPostDto dto)
    {
        try
        {
            Comment comment = await commentLogic.CreatePostAsync(dto);
            return Created($"/Post/{comment.PostTitle}/{comment.id}", comment); 
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Comment>>> GetAsync([FromQuery] GetCommentsAtPostDto? dto) // supports filtering only by title for now
    {
        try
        {
            IEnumerable<Comment> posts = await commentLogic.GetAsync(dto);
            return Ok(posts);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }

    }


}