using DataAccess;
using Services.Song;
using Services.Song.Dtos;

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
        return new List<SongDto>();
    }

    public SongDto? GetSong(int id)
    {
        return new SongDto();
    }

    public void AddSong(string name, int duration, string authorName, string albumName, string genre)
    {
        
    }

    public bool DeleteSong(int id)
    {
        return true;
    }

    public bool UpdateSong(int id, string name, int duration, string authorName, string albumName, string genre)
    {
        return true;
    }
}