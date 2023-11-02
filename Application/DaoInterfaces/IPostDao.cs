using Domain.DTOs;
using Shared.Models;

namespace Application.DaoInterfaces;

public interface IPostDao
{
    Task<Post> CreateAsync(Post post);
    Task<Post?> GetPostByTitle(string postTitle);
    public Task<IEnumerable<Post>> GetAsync(SearchPostParametersDto searchParameters);
}