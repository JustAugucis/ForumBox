using Shared.Models;

namespace Shared.Dtos;

public class CommentDto
{
    public User owner{get; set; }
    public string comment { get; set; }
}