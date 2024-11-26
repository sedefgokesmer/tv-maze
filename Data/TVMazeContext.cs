using Microsoft.EntityFrameworkCore;
using TVMazeScraper.Models;

namespace TVMazeScraper.Data;

public class TVMazeContext : DbContext
{
    public TVMazeContext(DbContextOptions<TVMazeContext> options) : base(options) { }
    public DbSet<Show> Shows { get; set; }
    public DbSet<CastInfo> CastInfo { get; set; }
    public DbSet<Person> Person { get; set; }

     protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Show>().HasKey(s => s.id);
        modelBuilder.Entity<CastInfo>().HasKey(c => c.id);
        modelBuilder.Entity<Person>().HasKey(p => p.id);
    }
}
