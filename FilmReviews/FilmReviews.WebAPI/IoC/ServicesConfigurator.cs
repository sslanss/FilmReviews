using FilmDirectorFilmDirectors.BL.FilmDirectors;
using FilmFilms.BL.Films;
using FilmReviews.BL.FilmDirectors.Entities;
using FilmReviews.BL.Films.Entities;
using FilmReviews.BL;
using FilmReviews.BL.Mapper;
using FilmReviews.BL.Reviews.Entities;
using FilmReviews.BL.Reviews;
using FilmReviews.BL.UserRates.Entities;
using FilmReviews.BL.UserRatesOnReviews.Entities;
using FilmReviews.BL.Users.Entities;
using FilmReviews.BL.Users;
using FilmReviews.DataAccess.Repositories;
using FilmReviews.WebAPI.Mapper;
using AutoMapper;
using FilmReviews.BL.Auth;
using FilmReviews.DataAccess.Entities;
using Microsoft.AspNetCore.Identity;
using FilmReviews.WebAPI.Settings;
using FilmReviews.BL.UserRatesOnReviews;

namespace Service.IoC;

public static class ServicesConfigurator
{
    public static void ConfigureService(IServiceCollection services, FilmReviewsSettings settings)
    {
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

        services.AddScoped<IProvider<UserModel, UserModelFilter>>(x => new UsersProvider(x.GetRequiredService<IRepository<UserEntity>>(), x.GetRequiredService<IMapper>()));

        services.AddScoped<IAuthProvider>(x =>
                new AuthProvider(x.GetRequiredService<SignInManager<UserEntity>>(),
                x.GetRequiredService<UserManager<UserEntity>>(),
                x.GetRequiredService<IHttpClientFactory>(),
                settings.IdentityServerUri,
                settings.ClientId,
                settings.ClientSecret));

        services.AddScoped<IProvider<UserModel, UserModelFilter>>();
        services.AddScoped<IManager<UserModel, CreateUserModel>, UsersManager>();

        services.AddScoped<IProvider<ReviewModel, ReviewModelFilter>>();
        services.AddScoped<IManager<ReviewModel, CreateReviewModel>, ReviewsManager>();

        services.AddScoped<IProvider<FilmModel, FilmModelFilter>>();
        services.AddScoped<IManager<FilmModel, CreateFilmModel>, FilmsManager>();

        services.AddScoped<IProvider<FilmDirectorModel, FilmDirectorModelFilter>>();
        services.AddScoped<IManager<FilmDirectorModel, CreateFilmDirectorModel>, FilmDirectorsManager>();

        services.AddScoped<IProvider<UserRateOnReviewModel, UserRateOnReviewModelFilter>>();
        services.AddScoped<IManager<UserRateOnReviewModel, CreateUserRateOnReviewModel>, UserRatesOnReviewsManager>();
    }
}
