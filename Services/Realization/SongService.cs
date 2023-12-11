using App.Metrics;
using App.Metrics.Registry;
using DataAccess;
using Domain;
using Microsoft.Extensions.Logging;
using Models;
using Services.Dtos.Song;
using Services.Interfaces;

namespace Services.Realization;

public class SongService : ISongService
{
    private SongsDbContext _dbContext;
    private readonly IMetrics _metrics;
    public SongService(SongsDbContext dbContext, IMetrics metrics)
    {
        _dbContext = dbContext;
        _metrics = metrics;
    }

    public List<SongDto> GetSongs()
    {
        _metrics.Measure.Counter.Increment(MetricsRegistry.ReadSongsCounter);
        return _dbContext.Songs.Select(x => new SongDto(x)).ToList();
        
    }

    public SongDto? GetSong(int id)
    {
        var song = _dbContext.Songs.FirstOrDefault(s => s.SongId == id);
        _metrics.Measure.Counter.Increment(MetricsRegistry.ReadSongsCounter);

        return (song != null) ? new SongDto(song) : null;    
    }

    public void AddSong(string name, int duration, string authorName, string albumName, string genre)
    {
        var song = new Song()
            {Name = name, Duration = duration, AuthorName = authorName, AlbumName = albumName, Genre = genre};
        _dbContext.Songs.Add(song);
        _dbContext.SaveChanges();
        _metrics.Measure.Counter.Increment(MetricsRegistry.CreatedSongsCounter);
    }

    public bool DeleteSong(int id)
    {
        var song = _dbContext.Songs.FirstOrDefault(s => s.SongId == id);
        
        if (song == null) return false;
        
        _dbContext.Songs.Remove(song);
        _dbContext.SaveChanges();
        _metrics.Measure.Counter.Increment(MetricsRegistry.DeletedSongsCounter);
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
        _metrics.Measure.Counter.Increment(MetricsRegistry.UpdatedSongsCounter);
        return true;
    }
}