using Domain.DTOs;
using Shared.Models;

namespace HttpClients.ClientInterfaces;

public interface IcommentService
{
    Task<Comment> CreateAsync(CreateNewCommentAtPostDto commentAtPostDto);
    Task<IEnumerable<Comment?>> GetCommentsByTitle(GetCommentsAtPostDto getCommentsAtPostDto);
}