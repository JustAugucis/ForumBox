using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Shared.Dtos;
using Shared.Models;

namespace Application.Logic;

public class PostLogic : IPostLogic
{
    private readonly IPostDao postDao;
    
    public PostLogic(IPostDao postDao)
    {
        this.postDao = postDao;
    }
    public async Task<Post> CreatePostAsync(PostDto dto)
    {
        
        Post? existing = await postDao.GetPostByTitle(dto.Title);
        
        if (existing != null)
            throw new Exception("Post title already exists!");

        
        Post toCreate = new Post();
        toCreate.Title = dto.Title;
        toCreate.CreatorName = dto.CreatorName;
        toCreate.body = dto.body;
        toCreate.comments = new List<Comment>();
        
        Post created = await postDao.CreateAsync(toCreate);
        
        return created;
    }
    
    
}