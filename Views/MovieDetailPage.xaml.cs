using MovieListApp.ViewModels;

namespace MovieListApp.Views;

public partial class MovieDetailPage : ContentPage
{
    public MovieDetailPage(MovieDetailViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}
