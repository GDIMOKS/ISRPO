namespace Services.Dtos.Song;

public class SongDto : CreateSongDto
{
    public int SongId { get; set; }

    public SongDto()
    {
        
    }
    public SongDto(int id, string name, int duration, string authorName, string albumName, string genre) : base(name, duration, authorName, albumName, genre)
    {
        SongId = id;
    }
    public SongDto(Models.Song song) 
        : this(song.SongId, song.Name, song.Duration, song.AuthorName, song.AlbumName, song.Genre)
    {
        
    }
}