using MovieListApp.ViewModels;

namespace MovieListApp.Views;

public partial class ListsPage : ContentPage
{
    private readonly ListsViewModel _vm;

    public ListsPage(ListsViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
        _vm = vm;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _vm.LoadAsync();
    }
}
