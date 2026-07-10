using System.Net.Http.Json;
using MovieListApp.Models;

namespace MovieListApp.Services;

public class OmdbService
{
    private const string ApiKey = "1b1d3a5";
    private const string BaseUrl = "https://www.omdbapi.com/";

    private readonly HttpClient _http;

    public OmdbService(HttpClient http)
    {
        _http = http;
    }

    public async Task<SearchResponse> SearchAsync(string query)
    {
        var url = $"{BaseUrl}?s={Uri.EscapeDataString(query)}&apikey={ApiKey}";
        var response = await _http.GetFromJsonAsync<SearchResponse>(url);
        return response ?? new SearchResponse();
    }

    public async Task<MovieDetail?> GetDetailAsync(string imdbId)
    {
        var url = $"{BaseUrl}?i={imdbId}&plot=full&apikey={ApiKey}";
        return await _http.GetFromJsonAsync<MovieDetail>(url);
    }

    public async Task<MovieDetail?> GetBasicAsync(string imdbId)
    {
        var url = $"{BaseUrl}?i={imdbId}&apikey={ApiKey}";
        return await _http.GetFromJsonAsync<MovieDetail>(url);
    }
}
