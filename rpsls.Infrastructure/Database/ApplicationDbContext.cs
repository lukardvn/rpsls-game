using Microsoft.EntityFrameworkCore;
using rpsls.Domain.Models;

namespace rpsls.Infrastructure.Database;

public class RpslsDbContext(DbContextOptions<RpslsDbContext> options) : DbContext(options)
{
    public DbSet<GameResult> Results => Set<GameResult>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<GameResult>().ToTable("Results");
    }
}

