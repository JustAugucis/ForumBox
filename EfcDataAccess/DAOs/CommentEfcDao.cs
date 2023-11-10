using Application.DaoInterfaces;
using FileData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Shared.Models;

namespace EfcDataAccess.DAOs;

public class CommentEfcDao : ICommentDao
{
    private readonly TodoContext context;       // this is db actually

    public CommentEfcDao(TodoContext context)
    {
        this.context = context;
    }
    
    public async Task<Comment> CreateAsync(Comment comment) // have to fix this 11-08
    {
        EntityEntry<Comment> added = await context.Comments.AddAsync(comment);
        await context.SaveChangesAsync();
        return added.Entity;
    }

    public async Task<IEnumerable<Comment?>> GetPostByTitle(string postTitle)
    {
        IQueryable<Comment> query = context.Comments.AsQueryable();
        
        query = query.Where(post =>
            post.Post.Title.ToLower().Equals(postTitle.ToLower()));

        List<Comment> result = await query.ToListAsync();
        return result;
    }
    
    
}