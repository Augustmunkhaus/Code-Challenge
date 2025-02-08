using MovieSite.Models;

namespace MovieSite.ApiClient;

public class ApiClient : IApiClient
{
    private readonly HttpClient _HttpClient;
    private readonly IConfiguration _configuration;

    public ApiClient(HttpClient httpClient, IConfiguration configuration)
    {
        _HttpClient = httpClient;
        _configuration = configuration;

    }
    //all tasks for fetching data from TMDB
    public async Task<List<Movie>> GetPopularMoviesAsync()
    {
        var apiKey = _configuration["MovieDb:ApiKey"];
        
        var response = await _HttpClient.GetFromJsonAsync<MovieDbResponse>(
            $"https://api.themoviedb.org/3/movie/popular?api_key={apiKey}");

        return response?.Results?.Take(10).ToList() ?? new List<Movie>();
    }
    public async Task<List<Genre>> GetMovieGenresAsync()
    {
        var apiKey = _configuration["MovieDb:ApiKey"];
        
        var response = await _HttpClient.GetFromJsonAsync<GenreDbResponse>(
            $"https://api.themoviedb.org/3/genre/movie/list?api_key={apiKey}");
        
        return response?.Genres?.ToList() ?? new List<Genre>();
    }
    
    public async Task<int> GetMovieCountByGenreAsync(int genreId)
    {
        var apiKey = _configuration["MovieDb:ApiKey"];
        //made url variable to fit in the URL
        var url = $"https://api.themoviedb.org/3/discover/movie?with_genres={genreId}&language=en-US&api_key={apiKey}";
        
        var response = await _HttpClient.GetFromJsonAsync<MovieDbResponse>(url);
        
        return response.total_results;
    }
    
    public async Task<List<Movie>> GetMoviesByGenreAsync(int genreId, int page = 1)
    {
        var apiKey = _configuration["MovieDb:ApiKey"];
        var response = await _HttpClient.GetFromJsonAsync<MovieDbResponse>(
            $"https://api.themoviedb.org/3/discover/movie?with_genres={genreId}&page={page}&api_key={apiKey}");

        return response?.Results?.ToList() ?? new List<Movie>();
    }

    public async Task<Movie> GetMovieByIdAsync(int movieId)
    {
        var apiKey = _configuration["MovieDb:ApiKey"];
        var response = await _HttpClient.GetFromJsonAsync<Movie>(
            $"https://api.themoviedb.org/3/movie/{movieId}?api_key={apiKey}");

        return response;
    }
}
    