using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Domain.DTOs;
using Shared.Models;

namespace Application.Logic;

public class CommentLogic : ICommentLogic
{
    private readonly ICommentDao commentDao;
    
    public CommentLogic(ICommentDao commentDao)
    {
        this.commentDao = commentDao;
    }
    
    public async Task<Comment> CreatePostAsync(CreateNewCommentAtPostDto commentDto) // lacks credibility check (who is request comming from)
    {
        Comment comment = new Comment();
        comment.ownerName = commentDto.ownerName;
        comment.comment = commentDto.comment;
        comment.PostTitle = commentDto.PostTitle;

        
        Comment created = await commentDao.CreateAsync(comment);
        return created;
    }

    public Task<IEnumerable<Comment>> GetAsync(GetCommentsAtPostDto getCommentsAtPostDto)
    {
        return commentDao.GetPostByTitle(getCommentsAtPostDto.PostTitle);
    }
    
}