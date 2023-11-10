namespace Domain.DTOs;

public class CreateNewCommentAtPostDto
{
    public string PostTitle { get; set; }
    public string comment { get; set; }
    public string ownerName { get; set; }
}