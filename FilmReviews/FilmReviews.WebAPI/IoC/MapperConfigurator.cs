using FilmReviews.BL.Users.Entities;
using FilmReviews.BL.Users;
using FilmReviews.BL;
using FilmReviews.DataAccess;
using FilmReviews.BL.Reviews.Entities;
using FilmReviews.BL.Reviews;
using FilmReviews.BL.Films.Entities;
using FilmFilms.BL.Films;
using FilmReviews.BL.FilmDirectors.Entities;
using FilmDirectorFilmDirectors.BL.FilmDirectors;
using FilmReviews.BL.UserRatesOnReviews.Entities;
using FilmReviews.BL.UserRates.Entities;
using FilmReviews.BL.Mapper;
using FilmReviews.DataAccess.Repositories;
using FilmReviews.WebAPI.Mapper;
using FilmReviews.BL.UserRatesOnReviews;

namespace FilmReviews.Service.IoC;

public static class MapperConfigurator
{
    public static void ConfigureServices(IServiceCollection services)
    {
        services.AddAutoMapper(config =>
        {
            config.AddProfile<UsersBLProfile>();
            config.AddProfile<UsersServiceProfile>();
        });
    }
}