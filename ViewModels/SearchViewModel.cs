using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MovieListApp.Models;
using MovieListApp.Services;

namespace MovieListApp.ViewModels;

public partial class SearchViewModel : BaseViewModel
{
    private readonly OmdbService _omdb;

    [ObservableProperty]
    private string _query = string.Empty;

    [ObservableProperty]
    private string _statusMessage = string.Empty;

    public ObservableCollection<SearchResult> Results { get; } = [];

    public SearchViewModel(OmdbService omdb)
    {
        _omdb = omdb;
    }

    [RelayCommand]
    private async Task SearchAsync()
    {
        if (string.IsNullOrWhiteSpace(Query))
            return;

        IsBusy = true;
        StatusMessage = string.Empty;
        Results.Clear();

        try
        {
            var response = await _omdb.SearchAsync(Query);

            if (response.Response == "True")
            {
                foreach (var item in response.Search)
                    Results.Add(item);
            }
            else
            {
                StatusMessage = response.Error ?? "No results found.";
            }
        }
        catch
        {
            StatusMessage = "Could not connect. Check your internet connection.";
        }
        finally
        {
            IsBusy = false;
        }
    }

    [RelayCommand]
    private async Task GoToDetailAsync(SearchResult movie)
    {
        if (movie is null) return;
        await Shell.Current.GoToAsync("detail", new Dictionary<string, object>
        {
            ["Movie"] = movie
        });
    }
}
