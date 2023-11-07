using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace FileData;

public class TodoContext : DbContext
{
    
    
    
    public DbSet<User> Users { get; set; }
    public DbSet<Post> posts { get; set; }
    public DbSet<Comment> Comments { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source = ../EfcDataAccess/Todo.db");
    }
    
    
    
}