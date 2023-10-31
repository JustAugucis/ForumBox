using Shared.Models;

namespace Shared.Dtos;

public class PostDto
{
    public User Creator { get; set; }
    public string Title { get; set; }
    public string body { get; set; }
    public List<Comment> comments { get; set; }
}