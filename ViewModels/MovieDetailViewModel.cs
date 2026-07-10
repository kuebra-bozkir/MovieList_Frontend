using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MovieListApp.Models;
using MovieListApp.Services;

namespace MovieListApp.ViewModels;

[QueryProperty(nameof(Movie), "Movie")]
public partial class MovieDetailViewModel : BaseViewModel
{
    private readonly OmdbService _omdb;

    [ObservableProperty]
    private SearchResult? _movie;

    [ObservableProperty]
    private MovieDetail? _detail;

    public MovieDetailViewModel(OmdbService omdb)
    {
        _omdb = omdb;
    }

    partial void OnMovieChanged(SearchResult? value)
    {
        if (value is null) return;
        _ = LoadDetailAsync(value.ImdbId);
    }

    private async Task LoadDetailAsync(string imdbId)
    {
        IsBusy = true;
        try
        {
            Detail = await _omdb.GetDetailAsync(imdbId);
        }
        catch
        {
            // detail stays null; page shows basic info from SearchResult
        }
        finally
        {
            IsBusy = false;
        }
    }

    [RelayCommand]
    private async Task AddToListAsync()
    {
        if (Movie is null) return;
        await Shell.Current.GoToAsync("addtolist", new Dictionary<string, object>
        {
            ["Movie"] = Movie
        });
    }
}
