using DataAccess;
using Models;
using Services.Dtos.Song;
using Services.Interfaces;

namespace Services.Realization;

public class SongService : ISongService
{
    private SongsDbContext _dbContext;
    
    public SongService(SongsDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<SongDto> GetSongs()
    {
        return _dbContext.Songs.Select(x => new SongDto(x)).ToList();
    }

    public SongDto? GetSong(int id)
    {
        var song = _dbContext.Songs.FirstOrDefault(s => s.SongId == id);
        return (song != null) ? new SongDto(song) : null;    
    }

    public void AddSong(string name, int duration, string authorName, string albumName, string genre)
    {
        var song = new Song()
            {Name = name, Duration = duration, AuthorName = authorName, AlbumName = albumName, Genre = genre};
        _dbContext.Songs.Add(song);
        _dbContext.SaveChanges();
    }

    public bool DeleteSong(int id)
    {
        var song = _dbContext.Songs.FirstOrDefault(s => s.SongId == id);
        
        if (song == null) return false;
        
        _dbContext.Songs.Remove(song);
        _dbContext.SaveChanges();
        return true;
    }

    public bool UpdateSong(int id, string name, int duration, string authorName, string albumName, string genre)
    {
        var song = _dbContext.Songs.FirstOrDefault(s => s.SongId == id);
        
        if (song == null) return false;

        song.Name = name;
        song.Duration = duration;
        song.AuthorName = authorName;
        song.AlbumName = albumName;
        song.Genre = genre;
        
        _dbContext.SaveChanges();
        
        return true;
    }
}