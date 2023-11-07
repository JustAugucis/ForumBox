using Application.DaoInterfaces;
using Domain.DTOs;
using FileData;
using Microsoft.EntityFrameworkCore;
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

    public async Task<IEnumerable<Post>> GetAsync(SearchPostParametersDto searchParameters)
    {
        IQueryable<Post> query = context.posts.AsQueryable();
        
        //IQueryable<Post> query = context.posts.Include(post => post.CreatorName).AsQueryable();
    
        if (!string.IsNullOrEmpty(searchParameters.CreatorName))
        {
            // we know username is unique, so just fetch the first
            query = query.Where(post =>
                post.CreatorName.ToLower().Equals(searchParameters.CreatorName.ToLower()));
        }
    
        if (searchParameters.Title != null)
        {
            query = query.Where(t => t.Title == searchParameters.Title);
        }
    
        if (!string.IsNullOrEmpty(searchParameters.body))
        {
            query = query.Where(t =>
                t.body.ToLower().Contains(searchParameters.body.ToLower()));
        }

        List<Post> result = await query.ToListAsync();
        return result;
    }
}