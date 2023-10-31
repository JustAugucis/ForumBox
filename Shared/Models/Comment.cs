namespace Shared.Models;

public class Comment
{
    public User owner{get; set; }
    public string comment { get; set; }
}