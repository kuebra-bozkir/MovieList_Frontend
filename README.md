# MovieListApp

A cross-platform mobile application for discovering movies, organizing personal movie lists, and rating films. Built with .NET MAUI, targeting iOS, Android, macOS, and Windows from a single C# codebase.

---

## Purpose

MovieListApp lets users browse movies by genre, search the OMDB database, and build personal curated lists with ratings and notes. The app works fully offline for saved data — no backend server is required.

---

## Tech Stack

| Layer | Technology |
|---|---|
| Framework | .NET 9 / .NET MAUI |
| Language | C# |
| UI Markup | XAML |
| Architecture Pattern | MVVM (Model-View-ViewModel) |
| MVVM Toolkit | CommunityToolkit.Mvvm 8.4.2 |
| External API | OMDB API (Open Movie Database) |
| Local Storage | JSON file on device filesystem |
| Dependency Injection | Microsoft.Extensions.DependencyInjection (built into MAUI) |

---

## Architecture

The project follows a strict **MVVM** architecture:

```
Views (XAML)  →  ViewModels (C#)  →  Services  →  Models
```

- **Views** are pure XAML — no business logic. Data binding connects them to ViewModels.
- **ViewModels** hold all UI state and logic. They extend `BaseViewModel` which provides an `IsBusy` flag for loading indicators.
- **Services** handle external concerns (API calls, file I/O) and are injected via constructor.
- **Models** are plain C# classes representing domain objects.

Navigation uses MAUI Shell with a tab bar for the three main sections and hierarchical routing for detail pages.

---

## Features

### Home Tab
Displays curated movie collections organized by genre (Action, Comedy, Drama, Sci-Fi, Horror, and more). Each genre row is a horizontal scrollable list of movie cards. Movies are pre-selected via IMDB IDs mapped to OMDB API lookups.

### Search Tab
A full-text search powered by the OMDB API. Results appear as a vertical list showing poster, title, year, and media type. Tapping any result opens the detail view.

### My Lists Tab
Users can create named movie lists (e.g., "Favorites", "To Watch"), view them, and delete them. Each list shows how many movies it contains.

### Movie Detail View
Shows comprehensive info fetched from OMDB: poster, title, year, runtime, MPAA rating, genre, director, cast, plot, and IMDB rating. From here, the user can add the movie to any of their lists.

### Add to List Flow
When saving a movie, the user picks an existing list or creates a new one inline, sets a personal rating (1–10), and optionally writes a note. This metadata is stored locally alongside the movie data.

---

## Project Structure

```
MovieListApp/
├── Views/              # XAML pages (HomePage, SearchPage, ListsPage,
│                       #   MovieDetailPage, MovieListPage, AddToListPage)
├── ViewModels/         # One ViewModel per View + BaseViewModel
├── Models/             # SavedMovie, MovieList, MovieDetail, SearchResult, ...
├── Services/
│   ├── OmdbService.cs        # OMDB API integration
│   ├── MovieStorageService.cs# JSON persistence to AppDataDirectory
│   └── GenreData.cs          # Static genre → IMDB ID mappings
├── Converters/         # Value converters for data binding (StringNotEmpty, etc.)
├── Resources/
│   ├── Styles/         # Colors.xaml (dark theme) and Styles.xaml
│   └── Fonts/          # OpenSans Regular & Semibold
├── Platforms/          # iOS, Android, Windows, MacCatalyst, Tizen entry points
├── AppShell.xaml       # Shell navigation container
├── MauiProgram.cs      # DI container and app bootstrap
└── MovieListApp.csproj # Project / target platform configuration
```

---

## Key Design Decisions

**Local-first data** — all user lists and saved movies are persisted as a single JSON file on the device at `FileSystem.AppDataDirectory/movie_lists.json`. No network dependency for accessing saved data.

**Dark theme only** — the app uses a fixed dark color scheme (`#141414` background, `#1E1E1E` surface, `#0F6FFF` accent). Light mode is not implemented.

**Singleton vs. Transient ViewModels** — ViewModels that hold state shared across the session (`HomeViewModel`, `ListsViewModel`) are registered as singletons. ViewModels that receive route parameters (`SearchViewModel`, `MovieDetailViewModel`) are transient so each navigation creates a fresh instance.

**Source-generated MVVM** — `CommunityToolkit.Mvvm` uses C# source generators to eliminate boilerplate `INotifyPropertyChanged` code. Properties are declared with `[ObservableProperty]` and the backing implementation is generated at compile time.

---

## Running the App

**Prerequisites:**
- .NET 9 SDK
- Visual Studio 2022 (Windows) or Visual Studio for Mac / Rider with MAUI workload installed

**Build and run:**
```bash
dotnet build MovieListApp/MovieListApp.csproj
dotnet run --project MovieListApp/MovieListApp.csproj -f net9.0-android   # or -ios, -maccatalyst, -windows
```

Or open the solution in Visual Studio, select a target platform, and press Run.

---

## External Dependencies

- **OMDB API** (`http://www.omdbapi.com`) — provides movie search and detail data. An API key is required and is currently hardcoded in `OmdbService.cs`.
