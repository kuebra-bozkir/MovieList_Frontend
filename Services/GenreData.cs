namespace MovieListApp.Services;

public static class GenreData
{
    public static readonly Dictionary<string, string[]> Genres = new()
    {
        ["Action"] =
        [
            "tt0468569", // The Dark Knight
            "tt1392190", // Mad Max: Fury Road
            "tt2911666", // John Wick
            "tt0095016", // Die Hard
            "tt0172495", // Gladiator
            "tt4154796", // Avengers: Endgame
        ],
        ["Comedy"] =
        [
            "tt2278388", // The Grand Budapest Hotel
            "tt0829482", // Superbad
            "tt0099785", // Home Alone
            "tt0107048", // Groundhog Day
            "tt3416742", // The Nice Guys
            "tt1478338", // Bridesmaids
        ],
        ["Drama"] =
        [
            "tt0111161", // The Shawshank Redemption
            "tt0109830", // Forrest Gump
            "tt0108052", // Schindler's List
            "tt0119217", // Good Will Hunting
            "tt2582802", // Whiplash
            "tt0993846", // The Wolf of Wall Street
        ],
        ["Sci-Fi"] =
        [
            "tt0816692", // Interstellar
            "tt0133093", // The Matrix
            "tt1375666", // Inception
            "tt3659388", // The Martian
            "tt2543164", // Arrival
            "tt1856101", // Blade Runner 2049
        ],
        ["Horror"] =
        [
            "tt5052448", // Get Out
            "tt0081505", // The Shining
            "tt7784604", // Hereditary
            "tt4549572", // A Quiet Place
            "tt8772262", // Midsommar
            "tt1457767", // The Conjuring
        ],
        ["Animation"] =
        [
            "tt0110357", // The Lion King
            "tt0114709", // Toy Story
            "tt0245429", // Spirited Away
            "tt1049413", // Up
            "tt2380307", // Coco
            "tt4633694", // Spider-Man: Into the Spider-Verse
        ],
        ["Thriller"] =
        [
            "tt6751668", // Parasite
            "tt2267998", // Gone Girl
            "tt0114369", // Se7en
            "tt1392214", // Prisoners
            "tt8946378", // Knives Out
            "tt3741700", // The Revenant
        ],
    };
}
