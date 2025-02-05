using MovieSite.Models;

namespace MovieSite.ApiClient;

public class ApiClient: IApiClient
{
    private readonly HttpClient _HttpClient;
    private readonly string _ApiKey;

    public ApiClient(HttpClient httpClient, IConfiguration configuration)
    {
        _HttpClient = httpClient;
        _ApiKey = configuration["MovieDb:ApiKey"];
    }

    public async Task<List<Movie>> GetPopularMoviesAsync()
    {
        var response = await _HttpClient.GetFromJsonAsync<MovieDbResponse>(
            $"https://api.themoviedb.org/3/movie/popular?api_key=d01843eeda129ce915de3ad0cab62288");
        
        return response?.Results?.Take(10).ToList() ?? new List<Movie>();
    }
}
