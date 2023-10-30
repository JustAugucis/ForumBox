using System.Net.Http.Json;
using System.Text.Json;
using Domain.DTOs;
using HttpClients.ClientInterfaces;
using Shared.Models;

namespace HttpClients.Implementations;

public class UserHttpClient : IUserService
{
    private readonly HttpClient client;

    public UserHttpClient(HttpClient client)
    {
        this.client = client;
    }


    public async Task<User> Register(UserRegisterDto dto)
    {
        HttpResponseMessage response = await client.PostAsJsonAsync("api/CreateUser", dto);
        // HttpClients.Implementations.UserHttpClient.Register(UserRegisterDto dto) in C:\Users\37062\Documents\GitHub\ForumBox\HttpClients\Implementations\UserHttpClient.cs:line 25
        string result = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }

        User user = JsonSerializer.Deserialize<User>(result);
        return user;
    }
}