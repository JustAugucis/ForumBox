using System.Net.Http.Json;
using System.Text.Json;
using Domain.DTOs;
using HttpClients.ClientInterfaces;
using Shared.Models;

namespace HttpClients.Implementations;

public class CommentHttpClient : IcommentService
{
    private readonly HttpClient client;
    
    public CommentHttpClient(HttpClient client)
    {
        this.client = client;
    }
    
    public async Task<Comment> CreateAsync(CreateNewCommentAtPostDto commentAtPostDto)
    {
        HttpResponseMessage response = await client.PostAsJsonAsync("/Comment", commentAtPostDto);
        string result = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }

        Comment comment = JsonSerializer.Deserialize<Comment>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return comment;
    }

    public async Task<IEnumerable<Comment?>> GetCommentsByTitle(GetCommentsAtPostDto getCommentsAtPostDto)
    {
        string uri = "/Comment";
        if (!string.IsNullOrEmpty(getCommentsAtPostDto.PostTitle))    // for now only title filtering
        {
            uri += $"?PostTitle={getCommentsAtPostDto.PostTitle}";
        }
        HttpResponseMessage response = await client.GetAsync(uri);
        string result = await response.Content.ReadAsStringAsync();     
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result); // this gets fired
        }

        IEnumerable<Comment> comments = JsonSerializer.Deserialize<IEnumerable<Comment>>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return comments;
    }
}