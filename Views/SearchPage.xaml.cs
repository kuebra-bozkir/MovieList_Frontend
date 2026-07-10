using MovieListApp.ViewModels;

namespace MovieListApp.Views;

public partial class SearchPage : ContentPage
{
    public SearchPage(SearchViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}
