namespace MovieListApp.Models;

public class MovieList
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Name { get; set; } = string.Empty;
    public List<SavedMovie> Movies { get; set; } = [];

    public string MovieCountDisplay =>
        Movies.Count == 1 ? "1 movie" : $"{Movies.Count} movies";
}
