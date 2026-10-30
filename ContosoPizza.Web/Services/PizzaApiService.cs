using ContosoPizza.Web.Models;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace ContosoPizza.Web.Services;

public class PizzaApiService
{
    private readonly IHttpClientFactory _factory;
    private readonly ProtectedSessionStorage _sessionStorage;

    public PizzaApiService(
        IHttpClientFactory factory,
        ProtectedSessionStorage sessionStorage)
    {
        _factory = factory;
        _sessionStorage = sessionStorage;
    }

    private async Task<string?> GetTokenAsync()
    {
        var result =
            await _sessionStorage.GetAsync<string>("token");

        return result.Success
            ? result.Value
            : null;
    }

    public async Task<List<PizzaDto>> GetPizzasAsync()
    {
        var client = _factory.CreateClient("PizzaApi");

        return await client.GetFromJsonAsync<List<PizzaDto>>("Pizza")
               ?? new List<PizzaDto>();
    }

    public async Task AddPizzaAsync(CreatePizzaDto pizza)
    {
        var client = _factory.CreateClient("PizzaApi");

        await client.PostAsJsonAsync("Pizza", pizza);
    }

    public async Task UpdatePizzaAsync(int id, UpdatePizzaDto pizza)
    {
        var token = await GetTokenAsync();

        var client = _factory.CreateClient("PizzaApi");

        if (!string.IsNullOrEmpty(token))
        {
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue(
                    "Bearer",
                    token);
        }

        var response =
            await client.PutAsJsonAsync(
                $"Pizza/{id}",
                pizza);

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(response.StatusCode.ToString());
        }
    }

    public async Task DeletePizzaAsync(int id)
    {
        var token = await GetTokenAsync();

        var client = _factory.CreateClient("PizzaApi");

        if (!string.IsNullOrEmpty(token))
        {
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue(
                    "Bearer",
                    token);
        }

        var response = await client.DeleteAsync($"Pizza/{id}");

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(response.StatusCode.ToString());
        }
    }
}