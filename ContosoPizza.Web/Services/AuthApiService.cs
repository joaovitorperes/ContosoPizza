using ContosoPizza.Web.Models;
using System.Net.Http.Json;

namespace ContosoPizza.Web.Services;

public class AuthApiService
{
    private readonly IHttpClientFactory _factory;

    public AuthApiService(IHttpClientFactory factory)
    {
        _factory = factory;
    }

    public async Task<string?> LoginAsync(LoginDto login)
    {
        var client = _factory.CreateClient("PizzaApi");

        var response =
            await client.PostAsJsonAsync("Auth/login", login);

        if (!response.IsSuccessStatusCode)
            return null;

        var result =
            await response.Content.ReadFromJsonAsync<AuthResponseDto>();

        return result?.Token;
    }
}