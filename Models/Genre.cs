namespace MovieSite.Models;

public class Genre
{
    public string name { get; set; }
    public int Id { get; set; }
}

public class GenreDbResponse
{
    public List<Genre> Genres { get; set; }
}