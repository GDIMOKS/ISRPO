using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

public class Song
{
    public int SongId { get; set; }
    
    public string Name { get; set; }
    
    public int Duration { get; set; }
    
    public string AuthorName { get; set; }
    
    public string AlbumName { get; set; }
    
    public string Genre { get; set; }
}


