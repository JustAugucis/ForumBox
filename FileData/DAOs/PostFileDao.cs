using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Domain.DTOs;
using Shared.Models;

namespace FileData.DAOs;

public class PostFileDao : IPostDao
{
    private readonly FileContext context;

    public PostFileDao(FileContext context)
    {
        this.context = context;
    }

    public Task<Post> CreateAsync(Post post)
    {
        

        context.Posts.Add(post);
        context.SaveChanges();

        return Task.FromResult(post);
    }
    

    public Task<Post?> GetPostByTitle(string postTitle)
    {
        Post? existing = context.Posts.FirstOrDefault(u =>
            u.Title.Equals(postTitle, StringComparison.OrdinalIgnoreCase)
        );
        return Task.FromResult(existing);
    }

    public Task<IEnumerable<Post>> GetAsync(SearchPostParametersDto searchParameters)
    {
        IEnumerable<Post> posts = context.Posts.AsEnumerable();
        if (searchParameters.Title != null)
        {
            posts = context.Posts.Where(u => u.Title.Contains(searchParameters.Title, StringComparison.OrdinalIgnoreCase));
        }

        return Task.FromResult(posts);
    }

    
}