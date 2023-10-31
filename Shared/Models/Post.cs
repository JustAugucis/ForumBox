namespace Shared.Models;

public class Post
{
    public User Creator { get; set; }
    public string Title { get; set; }
    public string body { get; set; }
    public List<Comment> comments { get; set; }
    

}