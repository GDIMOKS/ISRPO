using Microsoft.EntityFrameworkCore;
using Models;

namespace DataAccess;

public class SongsDbContext : DbContext
{
    public SongsDbContext()
    {
  
    }
    public SongsDbContext(DbContextOptions<SongsDbContext> options) : base(options)
    {

    }

    public DbSet<Song> Songs { get; set; } = null!;
  

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;User ID=postgres;Password=postgres;Database=isrpo;");
        }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
    }
}