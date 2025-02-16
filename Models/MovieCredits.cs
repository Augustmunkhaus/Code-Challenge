namespace MovieSite.Models;
public class MovieCredits
{
    public List<Cast> Cast { get; set; }
    public List<Crew> Crew { get; set; }
}

public class Cast
{
    public string Name { get; set; }
    public string Character { get; set; }
    public string ProfilePath { get; set; }
}

public class Crew
{
    public string Name { get; set; }
    public string Job { get; set; }
    public string ProfilePath { get; set; }
}