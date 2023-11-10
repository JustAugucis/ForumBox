using Shared.Models;

namespace Application.DaoInterfaces;

public interface ICommentDao
{
      Task<Comment> CreateAsync(Comment comment);
      Task<IEnumerable<Comment?>> GetPostByTitle(string postTitle);
}