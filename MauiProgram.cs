using Microsoft.Extensions.Logging;
using MovieListApp.Services;
using MovieListApp.ViewModels;
using MovieListApp.Views;

namespace MovieListApp;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        // Services
        builder.Services.AddSingleton<HttpClient>();
        builder.Services.AddSingleton<OmdbService>();
        builder.Services.AddSingleton<MovieStorageService>();

        // ViewModels
        builder.Services.AddSingleton<ListsViewModel>();
        builder.Services.AddSingleton<HomeViewModel>();
        builder.Services.AddTransient<SearchViewModel>();
        builder.Services.AddTransient<MovieDetailViewModel>();
        builder.Services.AddTransient<MovieListViewModel>();
        builder.Services.AddTransient<AddToListViewModel>();

        // Pages
        builder.Services.AddSingleton<ListsPage>();
        builder.Services.AddSingleton<HomePage>();
        builder.Services.AddTransient<SearchPage>();
        builder.Services.AddTransient<MovieDetailPage>();
        builder.Services.AddTransient<MovieListPage>();
        builder.Services.AddTransient<AddToListPage>();

        // Shell
        builder.Services.AddSingleton<AppShell>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
