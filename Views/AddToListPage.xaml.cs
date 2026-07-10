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

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _vm.Reset();
    }
}
