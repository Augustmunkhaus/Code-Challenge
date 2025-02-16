using MovieSite.Models;

namespace MovieSite.ApiClient;

public interface IApiClient
{
    Task<List<Movie>> GetPopularMoviesAsync();
    Task<List<Genre>> GetMovieGenresAsync();

    Task<int> GetMovieCountByGenreAsync(int genreId);
    
    Task<List<Movie>> GetMoviesByGenreAsync(int genreId, int page = 1);

    Task<Movie> GetMovieByIdAsync(int Id);
    
    Task<MovieCredits> GetMovieCreditsAsync(int movieId);
}