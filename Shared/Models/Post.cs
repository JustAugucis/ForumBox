using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Shared.Models;

public class Post
{
    [ForeignKey("User")]
    public string CreatorName { get; set; }
    [Key]
    public string Title { get; set; }
    public string body { get; set; }
    
    [JsonIgnore]
    public virtual ICollection<Comment> Comment { get; set; }

    
    public Post()
    {
        
    }
        
    
}