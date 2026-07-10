namespace MovieListApp.Models;

public class SavedMovie
{
    public string ImdbId { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Year { get; set; } = string.Empty;
    public string Poster { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public int? UserRating { get; set; }
    public string UserNote { get; set; } = string.Empty;

    public string PosterOrPlaceholder =>
        string.IsNullOrEmpty(Poster) || Poster == "N/A"
            ? "https://via.placeholder.com/92x138?text=No+Image"
            : Poster;

    public string RatingDisplay =>
        UserRating.HasValue ? $"{UserRating}/10" : "Not rated";

    public static SavedMovie FromSearchResult(SearchResult r) => new()
    {
        ImdbId = r.ImdbId,
        Title = r.Title,
        Year = r.Year,
        Poster = r.Poster,
        Type = r.Type,
    };
}
