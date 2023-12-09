namespace Services.Dtos.Song;

public class CreateSongDto
{
    public string? Name { get; set; }
    public int Duration { get; set; }
    public string? AuthorName { get; set; }
    public string? AlbumName { get; set; }
    public string? Genre { get; set; }
    
    public CreateSongDto()
    {
        
    }
    public CreateSongDto(string name, int duration, string authorName, string albumName, string genre) : this()
    {
        Name = name;
        Duration = duration;
        AuthorName = authorName;
        AlbumName = albumName;
        Genre = genre;
    }

}