namespace Domain.Models;

public class Post
{
    public int Id { get; set;}
    public User Owner { get; set;}
    public string Comment { get; set; }

    public Post(string comment)
    {
        this.Comment = comment;
    }
}