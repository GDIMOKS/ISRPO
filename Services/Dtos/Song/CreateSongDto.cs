namespace Services.Song.Dtos;

public class CreateSongDto
{
    public string? Name { get; set; }
    public int Duration { get; set; }
    public string? AuthorName { get; set; }
    public string? AlbumName { get; set; }
    
    public string? Genre { get; set; }
}