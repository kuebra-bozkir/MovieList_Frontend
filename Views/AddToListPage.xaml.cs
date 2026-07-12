using MovieListApp.ViewModels;

namespace MovieListApp.Views;

public partial class AddToListPage : ContentPage
{
    private readonly AddToListViewModel _vm;

    public AddToListPage(AddToListViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
        _vm = vm;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _vm.LoadAndResetAsync();
    }
}
