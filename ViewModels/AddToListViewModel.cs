using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MovieListApp.Models;
using MovieListApp.Services;

namespace MovieListApp.ViewModels;

[QueryProperty(nameof(Movie), "Movie")]
public partial class AddToListViewModel : BaseViewModel
{
    private readonly MovieStorageService _storage;
    private readonly ListsViewModel _listsVm;

    [ObservableProperty]
    private SearchResult? _movie;

    [ObservableProperty]
    private MovieList? _selectedList;

    [ObservableProperty]
    private string _newListName = string.Empty;

    [ObservableProperty]
    private int _userRating = 5;

    [ObservableProperty]
    private string _userNote = string.Empty;

    [ObservableProperty]
    private string _statusMessage = string.Empty;

    public ObservableCollection<MovieList> Lists => _listsVm.Lists;

    public AddToListViewModel(MovieStorageService storage, ListsViewModel listsVm)
    {
        _storage = storage;
        _listsVm = listsVm;
    }

    public void Reset()
    {
        SelectedList = Lists.Count > 0 ? Lists[0] : null;
        NewListName = string.Empty;
        UserRating = 5;
        UserNote = string.Empty;
        StatusMessage = string.Empty;
    }

    [RelayCommand]
    private async Task SaveAsync()
    {
        if (Movie is null) return;

        MovieList? target = SelectedList;

        if (!string.IsNullOrWhiteSpace(NewListName))
        {
            target = new MovieList { Name = NewListName.Trim() };
            _listsVm.Lists.Add(target);
        }

        if (target is null)
        {
            StatusMessage = "Please select or create a list first.";
            return;
        }

        var saved = SavedMovie.FromSearchResult(Movie);
        saved.UserRating = UserRating;
        saved.UserNote = UserNote;

        target.Movies.Add(saved);
        await _storage.SaveListsAsync([.. _listsVm.Lists]);

        await Shell.Current.GoToAsync("..");
    }
}
