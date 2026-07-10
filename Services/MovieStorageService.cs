using System.Text.Json;
using MovieListApp.Models;

namespace MovieListApp.Services;

public class MovieStorageService
{
    private readonly string _filePath =
        Path.Combine(FileSystem.AppDataDirectory, "movie_lists.json");

    public async Task<List<MovieList>> LoadListsAsync()
    {
        if (!File.Exists(_filePath))
            return [];

        var json = await File.ReadAllTextAsync(_filePath);
        return JsonSerializer.Deserialize<List<MovieList>>(json) ?? [];
    }

    public async Task SaveListsAsync(List<MovieList> lists)
    {
        var json = JsonSerializer.Serialize(lists);
        await File.WriteAllTextAsync(_filePath, json);
    }
}
