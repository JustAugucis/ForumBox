namespace Domain.Models;

public class SubRedit
{
    public int Id { get; set;}
    public User Owner { get; set;}
    public string Title { get; set;}
    public List<Post> Posts { get; set;}

    public SubRedit(string title)
    {
        this.Title = title;
    }
    
}