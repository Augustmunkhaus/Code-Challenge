namespace MovieSite.Models;

public class Movie
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Overview { get; set; }
    public string PosterPath { get; set; }
    public  DateTime ReleaseDate { get; set; }
    public float VoteAverage { get; set; }
    public string BackdropPath { get; set; }
    public string OriginalTitle { get; set; }
    public bool Adult { get; set; }
    public double Popularity { get; set; }
}

public class MovieDbResponse
{
    public List<Movie> Results { get; set; }
}
