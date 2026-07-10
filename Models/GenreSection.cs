using System.Collections.ObjectModel;
using MovieListApp.Models;

namespace MovieListApp.Models;

public class GenreSection
{
    public string Genre { get; set; } = string.Empty;
    public ObservableCollection<MovieDetail> Movies { get; } = [];
}
