using Services.Song.Dtos;

namespace Services.Song;

public interface ISongService
{
    List<SongDto> GetSongs();
    SongDto? GetSong(int id);
    void AddSong(string name, int duration, string authorName, string albumName, string genre);
    bool DeleteSong(int id);
    bool UpdateSong(int id, string name, int duration, string authorName, string albumName, string genre);
}