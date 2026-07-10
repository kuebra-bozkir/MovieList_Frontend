using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MovieListApp.Models;
using MovieListApp.Services;

namespace MovieListApp.ViewModels;

[QueryProperty(nameof(MovieList), "MovieList")]
public partial class MovieListViewModel : BaseViewModel
{
    private readonly MovieStorageService _storage;
    private readonly ListsViewModel _listsVm;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(PageTitle))]
    private MovieList? _movieList;

    public string PageTitle => MovieList?.Name ?? "My List";

    public ObservableCollection<SavedMovie> Movies { get; } = [];

    public MovieListViewModel(MovieStorageService storage, ListsViewModel listsVm)
    {
        _storage = storage;
        _listsVm = listsVm;
    }

    partial void OnMovieListChanged(MovieList? value)
    {
        Movies.Clear();
        if (value is null) return;
        foreach (var m in value.Movies)
            Movies.Add(m);
    }

    [RelayCommand]
    private async Task RemoveMovieAsync(SavedMovie movie)
    {
        MovieList?.Movies.Remove(movie);
        Movies.Remove(movie);
        await _storage.SaveListsAsync([.. _listsVm.Lists]);
    }

    [RelayCommand]
    private async Task GoToDetailAsync(SavedMovie movie)
    {
        if (movie is null) return;
        var searchResult = new SearchResult
        {
            ImdbId = movie.ImdbId,
            Title = movie.Title,
            Year = movie.Year,
            Poster = movie.Poster,
            Type = movie.Type,
        };
        await Shell.Current.GoToAsync("detail", new Dictionary<string, object>
        {
            ["Movie"] = searchResult
        });
    }
}
