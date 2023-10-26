namespace Domain.DTOs;

public class SearchUserParametersDto
{
    public string? Username { get;}
    public int? UserId { get;}

    public SearchUserParametersDto(string? username, int? userId)
    {
        Username = username;
        UserId = userId;
    }
}