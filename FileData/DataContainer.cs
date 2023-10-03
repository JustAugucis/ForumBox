using Domain.Models;

namespace FileData;

public class DataContainer
{ 
    public ICollection<User> Users { get; set; }
    public ICollection<SubRedit> SubRedits { get; set; }
    public ICollection<Post> Posts { get; set; }
    
}