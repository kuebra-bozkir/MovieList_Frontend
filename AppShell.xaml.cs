using MovieListApp.Views;

namespace MovieListApp;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute("detail", typeof(MovieDetailPage));
        Routing.RegisterRoute("movielist", typeof(MovieListPage));
        Routing.RegisterRoute("addtolist", typeof(AddToListPage));
    }
}
