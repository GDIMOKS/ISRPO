using Microsoft.AspNetCore.Mvc;
using Services.Dtos.Song;
using Services.Interfaces;

namespace Domain.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SongsController : ControllerBase
{
    private readonly ISongService _songService;

    public SongsController(ISongService songService)
    {
        _songService = songService;
    }

    [HttpGet]
    public IEnumerable<SongDto> GetSongs()
    {
        return _songService.GetSongs();
    }
    
    [HttpGet("{id}")]
    public IActionResult GetSong([FromRoute]int id)
    {
        var song = _songService.GetSong(id);
        return (song != null) ? Ok(song) : NotFound();    
    }

    [HttpPost]
    public void AddSong([FromBody]CreateSongDto dto)
    {
        _songService.AddSong(dto.Name, dto.Duration, dto.AuthorName, dto.AlbumName, dto.Genre);
    }
    
    [HttpDelete("{id}")]
    public void DeleteSong([FromRoute]int id)
    {
        _songService.DeleteSong(id);
    }
    
    [HttpPut("{id}")]
    public void UpdateSong([FromRoute]int id, [FromBody]CreateSongDto dto)
    {
        _songService.UpdateSong(id, dto.Name, dto.Duration, dto.AuthorName, dto.AlbumName, dto.Genre);
    }
}