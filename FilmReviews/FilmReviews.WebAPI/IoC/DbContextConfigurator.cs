using FilmReviews.DataAccess;
using FilmReviews.WebAPI.Settings;
using Microsoft.EntityFrameworkCore;

namespace FilmReviews.WebAPI.IoC
{
    public static class DbContextConfigurator
    {
        public static void ConfigureService(IServiceCollection services, FilmReviewsSettings settings)
        {
            services.AddDbContextFactory<FilmReviewsDbContext>(
                options => { options.UseSqlServer(settings.FilmReviewsDbContextConnectionString); },
                ServiceLifetime.Scoped);
        }

        public static void ConfigureApplication(IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var contextFactory = scope.ServiceProvider.GetRequiredService<IDbContextFactory<FilmReviewsDbContext>>();
            using var context = contextFactory.CreateDbContext();
            context.Database.Migrate();
        }
    }
}
