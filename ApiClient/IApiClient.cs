using MovieSite.Models;

namespace MovieSite.ApiClient;

public interface IApiClient
{
    Task<List<Movie>> GetPopularMoviesAsync();
}