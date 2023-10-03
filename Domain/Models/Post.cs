namespace Domain.Models;

public class Post
{
    public int Id { get; set;}
    public User Owner { get; set;}
    public string Description { get; set; }

    public Post(string comment)
    {
        this.Description = comment;
    }
}