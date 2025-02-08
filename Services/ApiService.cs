using MovieSite.Models;
using MovieSite.ApiClient;

namespace MovieSite;

public class ApiService : IApiService
{
    private readonly IApiClient _apiClient;

    public ApiService(IApiClient apiClient)
    {
         _apiClient = apiClient;
    }
    //all service tasks for transforming data
    public async Task<List<Genre>> SelectedGenresAsync(List<int> selectedGenreIds)
    {
        var selectedGenres = await _apiClient.GetMovieGenresAsync();
        
        var filteredGenres = selectedGenres.Where(g => selectedGenreIds.Contains(g.Id)).ToList();
        
        return filteredGenres;
    }
    
    
}
