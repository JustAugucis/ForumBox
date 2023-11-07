using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Shared.Models;



public class Comment
{
    [Key]
    public int id { get; set; }
    public String ownerName{get; set; }
    public string comment { get; set; }
    

    public Comment()
    {
        
    }
}