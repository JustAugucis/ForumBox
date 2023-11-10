using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Shared.Models;

public class Post
{
    
    public User User { get; set; }
    [ForeignKey("User")]
    public string Username { get; set; }
    [Key]
    public string Title { get; set; }   // unique?
    public string body { get; set; }
    
    //[JsonIgnore]
    public ICollection<Comment> Comments { get; set; }

    
    public Post()
    {
        
    }
        
    
}