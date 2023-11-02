using System.Net.Http.Json;
using System.Text.Json;
using Domain.DTOs;
using HttpClients.ClientInterfaces;
using Shared.Dtos;
using Shared.Models;

namespace HttpClients.Implementations;

public class PostHttpClient : IPostService
{
    private readonly HttpClient client;
    
    public PostHttpClient(HttpClient client)
    {
        this.client = client;
    }
    public async Task<Post> Create(PostDto dto)
    {
        HttpResponseMessage response = await client.PostAsJsonAsync("/Post", dto);
        string result = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }

        Post post = JsonSerializer.Deserialize<Post>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return post;
    }

    public async Task<IEnumerable<Post>> GetPosts(SearchPostParametersDto postParameters)
    {
        string uri = "/Post";
        if (!string.IsNullOrEmpty(postParameters.Title))    // for now only title filtering
        {
            uri += $"?username={Uri.EscapeDataString(postParameters.Title)}";
        }
        HttpResponseMessage response = await client.GetAsync(uri);
        string result = await response.Content.ReadAsStringAsync();     
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result); // this gets fired
        }

        IEnumerable<Post> posts = JsonSerializer.Deserialize<IEnumerable<Post>>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return posts;
    }
}