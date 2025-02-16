using Blazored.LocalStorage;
using MovieSite.Models;
using MovieSite.ApiClient;

namespace MovieSite;

public class ApiService : IApiService
{
    private readonly IApiClient _apiClient;
    private readonly ILocalStorageService _localStorage;

    public ApiService(IApiClient apiClient, ILocalStorageService localStorage)
    {
        _apiClient = apiClient;
        _localStorage = localStorage;
    }

    //all service tasks for transforming data
    public async Task<List<Genre>> SelectedGenresAsync(List<int> selectedGenreIds)
    { 
        //fetches movies and filters them based on the desired Id's
        var selectedGenres = await _apiClient.GetMovieGenresAsync();

        var filteredGenres = selectedGenres.Where(g => selectedGenreIds.Contains(g.Id)).ToList();

        return filteredGenres;
    }

    public async Task AddToWishlist(Movie movie)
    {
        // Get current wishlist
        var wishlist = await _localStorage.GetItemAsync<List<Movie>>("wishlist");

        if (wishlist == null)
        {
            wishlist = new List<Movie>();
        }

        // Check if already on wishlist
        if (!wishlist.Any(m => m.MovieId == movie.MovieId))
        {
            wishlist.Add(movie);
            await _localStorage.SetItemAsync("wishlist", wishlist); // Save
        }
        else
        {
            Console.WriteLine($"Movie '{movie.Title}' is already on the wishlist.");
            
        }
    }
}