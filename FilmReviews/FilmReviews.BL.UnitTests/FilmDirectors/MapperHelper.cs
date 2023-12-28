using AutoMapper;
using FilmReviews.WebAPI.Mapper;

namespace BL.UnitTests.FilmDirectors;

public static class MapperHelper
{
    public static IMapper Mapper { get; }

    static MapperHelper()
    {
<<<<<<< HEAD
        var config = new MapperConfiguration(x => x.AddProfile(typeof(FilmDirectorsServiceProfile)));
=======
        var config = new MapperConfiguration(x => x.AddProfile(typeof(UsersServiceProfile)));
>>>>>>> 4394183c875d97a463623a52bf42ea113675f64c
        Mapper = new AutoMapper.Mapper(config);
    }
}