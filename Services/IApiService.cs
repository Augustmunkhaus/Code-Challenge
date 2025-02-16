using MovieSite.Models;
namespace MovieSite;

public interface IApiService
{
    Task<List<Genre>> SelectedGenresAsync(List<int> selectedGenreAsync);

    Task AddToWishlist(Movie movie);
}