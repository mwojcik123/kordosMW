public class Movie
{
    public string Title { get; set; }
    public string Genre { get; set; }

    public Movie(string title, string genre)
    {
        Title = title;
        Genre = genre;
    }
}
