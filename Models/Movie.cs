
using System.Text.Json.Serialization;

namespace MovieSite.Models;

public class Movie
{
    public bool adult { get; set; }
    public string backdrop_path { get; set; }
    public List<int> genre_ids { get; set; } = new List<int>();
    
    [JsonPropertyName("Id")]
    public int MovieId { get; set; }
    public string original_language { get; set; }
    public string original_title { get; set; }
    public string Overview { get; set; }
    public double Popularity { get; set; }
    public string poster_path { get; set; }
    public string release_date { get; set; }
    public string Title { get; set; }
    public bool Video { get; set; }
    public float Vote_average { get; set; }
    public int Vote_count { get; set; }
    
    public List<Genre> Genres { get; set; }
    
}


public class MovieDbResponse
{
    public List<Movie> Results { get; set; }
    public int total_results { get; set; }
}
