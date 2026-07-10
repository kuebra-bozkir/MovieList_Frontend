using System.Text.Json.Serialization;

namespace MovieListApp.Models;

public class SearchResult
{
    [JsonPropertyName("Title")]
    public string Title { get; set; } = string.Empty;

    [JsonPropertyName("Year")]
    public string Year { get; set; } = string.Empty;

    [JsonPropertyName("imdbID")]
    public string ImdbId { get; set; } = string.Empty;

    [JsonPropertyName("Type")]
    public string Type { get; set; } = string.Empty;

    [JsonPropertyName("Poster")]
    public string Poster { get; set; } = string.Empty;

    [JsonIgnore]
    public string PosterOrPlaceholder =>
        string.IsNullOrEmpty(Poster) || Poster == "N/A"
            ? "https://via.placeholder.com/92x138?text=No+Image"
            : Poster;
}
