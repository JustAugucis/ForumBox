using System.Net.Http.Json;
using System.Text.Json;
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
        HttpResponseMessage response = await client.PostAsJsonAsync("/Posts", dto);
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

    
}