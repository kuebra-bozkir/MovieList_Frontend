using MovieListApp.ViewModels;

namespace MovieListApp.Views;

public partial class MovieListPage : ContentPage
{
    public MovieListPage(MovieListViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}
