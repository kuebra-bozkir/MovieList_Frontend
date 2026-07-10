using System.Text.Json.Serialization;

namespace MovieListApp.Models;

public class MovieDetail
{
    [JsonPropertyName("Title")]
    public string Title { get; set; } = string.Empty;

    [JsonPropertyName("Year")]
    public string Year { get; set; } = string.Empty;

    [JsonPropertyName("Rated")]
    public string Rated { get; set; } = string.Empty;

    [JsonPropertyName("Runtime")]
    public string Runtime { get; set; } = string.Empty;

    [JsonPropertyName("Genre")]
    public string Genre { get; set; } = string.Empty;

    [JsonPropertyName("Director")]
    public string Director { get; set; } = string.Empty;

    [JsonPropertyName("Actors")]
    public string Actors { get; set; } = string.Empty;

    [JsonPropertyName("Plot")]
    public string Plot { get; set; } = string.Empty;

    [JsonPropertyName("Poster")]
    public string Poster { get; set; } = string.Empty;

    [JsonPropertyName("imdbRating")]
    public string ImdbRating { get; set; } = string.Empty;

    [JsonPropertyName("imdbID")]
    public string ImdbId { get; set; } = string.Empty;

    [JsonPropertyName("Response")]
    public string Response { get; set; } = "False";

    [JsonIgnore]
    public string PosterOrPlaceholder =>
        string.IsNullOrEmpty(Poster) || Poster == "N/A"
            ? "https://via.placeholder.com/300x450?text=No+Image"
            : Poster;

    [JsonIgnore]
    public string RatingDisplay =>
        ImdbRating == "N/A" ? "N/A" : $"⭐ {ImdbRating} / 10";
}
