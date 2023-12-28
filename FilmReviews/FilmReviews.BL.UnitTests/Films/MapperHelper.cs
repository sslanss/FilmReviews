using AutoMapper;
using FilmReviews.WebAPI.Mapper;

namespace BL.UnitTests.Films;

public static class MapperHelper
{
    public static IMapper Mapper { get; }

    static MapperHelper()
    {
        var config = new MapperConfiguration(x => x.AddProfile(typeof(FilmsServiceProfile)));
        Mapper = new AutoMapper.Mapper(config);
    }
}