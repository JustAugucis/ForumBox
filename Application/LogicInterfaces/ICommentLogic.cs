using Domain.DTOs;
using Shared.Dtos;
using Shared.Models;

namespace Application.LogicInterfaces;

public interface ICommentLogic
{
    public Task<Comment> CreatePostAsync(CreateNewCommentAtPostDto commentDto);
    public Task<IEnumerable<Comment>> GetAsync(GetCommentsAtPostDto createNewCommentAtPostDtoDto);
}