using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MovieListApp.Models;
using MovieListApp.Services;

namespace MovieListApp.ViewModels;

public partial class ListsViewModel : BaseViewModel
{
    private readonly MovieStorageService _storage;

    public ObservableCollection<MovieList> Lists { get; } = [];

    public ListsViewModel(MovieStorageService storage)
    {
        _storage = storage;
    }

    public async Task LoadAsync()
    {
        var lists = await _storage.LoadListsAsync();
        Lists.Clear();
        foreach (var list in lists)
            Lists.Add(list);
    }

    [RelayCommand]
    private async Task CreateListAsync()
    {
        var name = await Shell.Current.DisplayPromptAsync(
            "New List",
            "Enter a name for your list:",
            placeholder: "e.g. Favourites");

        if (string.IsNullOrWhiteSpace(name)) return;

        var list = new MovieList { Name = name.Trim() };
        Lists.Add(list);
        await _storage.SaveListsAsync([.. Lists]);
    }

    [RelayCommand]
    private async Task DeleteListAsync(MovieList list)
    {
        bool confirmed = await Shell.Current.DisplayAlert(
            "Delete List",
            $"Delete \"{list.Name}\"?",
            "Delete", "Cancel");

        if (!confirmed) return;

        Lists.Remove(list);
        await _storage.SaveListsAsync([.. Lists]);
    }

    [RelayCommand]
    private async Task GoToListAsync(MovieList list)
    {
        if (list is null) return;
        await Shell.Current.GoToAsync("movielist", new Dictionary<string, object>
        {
            ["MovieList"] = list
        });
    }
}
