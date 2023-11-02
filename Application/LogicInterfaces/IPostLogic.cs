using Domain.DTOs;
using Shared.Dtos;
using Shared.Models;

namespace Application.LogicInterfaces;

public interface IPostLogic
{
       public Task<Post> CreatePostAsync(PostDto dto);
       public Task<IEnumerable<Post>> GetAsync(SearchPostParametersDto searchPostParametersDto);
}