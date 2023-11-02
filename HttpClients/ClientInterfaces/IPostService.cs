using Shared.Dtos;
using Shared.Models;

namespace HttpClients.ClientInterfaces;

public interface IPostService
{
    Task<Post> Create(PostDto dto);
}