using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MovieListApp.Models;
using MovieListApp.Services;

namespace MovieListApp.ViewModels;

public partial class HomeViewModel : BaseViewModel
{
    private readonly OmdbService _omdb;
    private bool _loaded;

    public ObservableCollection<GenreSection> Genres { get; } = [];

    public HomeViewModel(OmdbService omdb)
    {
        _omdb = omdb;
        foreach (var genre in GenreData.Genres.Keys)
            Genres.Add(new GenreSection { Genre = genre });
    }

    public async Task LoadAsync()
    {
        if (_loaded) return;
        _loaded = true;

        IsBusy = true;
        try
        {
            var tasks = GenreData.Genres.Select(async kvp =>
            {
                var section = Genres.First(g => g.Genre == kvp.Key);
                var results = await Task.WhenAll(kvp.Value.Select(id => _omdb.GetBasicAsync(id)));
                foreach (var movie in results.Where(m => m is not null && m.Response == "True"))
                    section.Movies.Add(movie!);
            });

            await Task.WhenAll(tasks);
        }
        finally
        {
            IsBusy = false;
        }
    }

    [RelayCommand]
    private async Task GoToDetailAsync(MovieDetail movie)
    {
        if (movie is null) return;
        var searchResult = new SearchResult
        {
            ImdbId = movie.ImdbId,
            Title = movie.Title,
            Year = movie.Year,
            Poster = movie.Poster,
        };
        await Shell.Current.GoToAsync("detail", new Dictionary<string, object>
        {
            ["Movie"] = searchResult
        });
    }
}
