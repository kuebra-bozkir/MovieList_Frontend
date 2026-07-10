using System.Text.Json.Serialization;

namespace MovieListApp.Models;

public class SearchResponse
{
    [JsonPropertyName("Search")]
    public List<SearchResult> Search { get; set; } = [];

    [JsonPropertyName("totalResults")]
    public string TotalResults { get; set; } = "0";

    [JsonPropertyName("Response")]
    public string Response { get; set; } = "False";

    [JsonPropertyName("Error")]
    public string? Error { get; set; }
}
