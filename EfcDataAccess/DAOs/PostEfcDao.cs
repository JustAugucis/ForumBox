using Application.DaoInterfaces;
using Domain.DTOs;
using FileData;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Shared.Models;

namespace EfcDataAccess.DAOs;

public class PostEfcDao : IPostDao
{
    private readonly TodoContext context;       // this is db actually

    public PostEfcDao(TodoContext context)
    {
        this.context = context;
    }
    
    
    public async Task<Post> CreateAsync(Post post)
    {
        EntityEntry<Post> added = await context.posts.AddAsync(post);
        await context.SaveChangesAsync();
        return added.Entity;
    }

    public Task<Post?> GetPostByTitle(string postTitle)
    {
        Post? existing = context.posts.FirstOrDefault(u =>
            u.Title.ToLower().Equals(postTitle)
        );
        return Task.FromResult(existing);
        
    }

    public Task<IEnumerable<Post>> GetAsync(SearchPostParametersDto searchParameters)
    {
        IEnumerable<Post> posts = context.posts.AsEnumerable();
        if (searchParameters.Title != null)
        {
            posts = context.posts.Where(u => u.Title.ToLower().Equals(searchParameters.Title));
        }

        return Task.FromResult(posts);
    }
}