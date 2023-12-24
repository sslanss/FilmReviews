using FilmReviews.DataAccess;
using FilmReviews.WebAPI.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmReviews.UnitTest.DataAccess
{
    public class RepositoryTestsBaseClass
    {
        public RepositoryTestsBaseClass()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false)
                .Build();

            Settings = FilmReviewsSettingsReader.Read(configuration);
            ServiceProvider = ConfigureServiceProvider();

            DbContextFactory = ServiceProvider.GetRequiredService<IDbContextFactory<FilmReviewsDbContext>>();
        }

        private IServiceProvider ConfigureServiceProvider()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddDbContextFactory<FilmReviewsDbContext>(
                options => { options.UseSqlServer(Settings.FilmReviewsDbContextConnectionString); },
                ServiceLifetime.Scoped);
            return serviceCollection.BuildServiceProvider();
        }

        protected readonly FilmReviewsSettings Settings;
        protected readonly IDbContextFactory<FilmReviewsDbContext> DbContextFactory;
        protected readonly IServiceProvider ServiceProvider;
    }
}
