using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL;

public class NewsSiteContext(DbContextOptions<NewsSiteContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<News>()
        .HasMany(e => e.Tags)
        .WithMany(e => e.News)
        .UsingEntity<NewsWithTag>();

        base.OnModelCreating(modelBuilder);
    }
    public DbSet<Author> Authors { get; set; }
    public DbSet<News> News { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<Rubric> Rubrics { get; set; }
    public DbSet<NewsWithTag> NewsWithTags { get; set; }

}
