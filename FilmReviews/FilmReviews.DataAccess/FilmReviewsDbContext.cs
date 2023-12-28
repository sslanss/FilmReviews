using FilmReviews.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace FilmReviews.DataAccess;

public class FilmReviewsDbContext : DbContext
{
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<ReviewEntity> Reviews { get; set; }
    public DbSet<FilmEntity> Films { get; set; }
    public DbSet<UserRateOnReviewEntity> UserRates { get; set; }
    public DbSet<FilmDirectorEntity> FilmDirectors { get; set; }


    public FilmReviewsDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<FilmEntity>()
            .HasMany(film => film.Reviews)
            .WithOne(review => review.Film)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<FilmDirectorEntity>()
            .HasMany(director => director.Films)
            .WithOne(film => film.Director)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<UserEntity>()
            .HasMany(user => user.Reviews)
            .WithOne(review => review.User)
            .OnDelete(DeleteBehavior.SetNull); 

        modelBuilder.Entity<UserEntity>()
            .HasMany(user => user.UserRates)
            .WithOne(rate => rate.User)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<ReviewEntity>()
            .HasMany(review => review.UserRates)
            .WithOne(rate => rate.Review)
            .OnDelete(DeleteBehavior.SetNull);
    }
}
