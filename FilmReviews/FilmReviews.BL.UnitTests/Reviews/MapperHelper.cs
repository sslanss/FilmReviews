using AutoMapper;
using FilmReviews.WebAPI.Mapper;

namespace BL.UnitTests.Reviews;

public static class MapperHelper
{
    public static IMapper Mapper { get; }

    static MapperHelper()
    {
        var config = new MapperConfiguration(x => x.AddProfile(typeof(ReviewsServiceProfile)));
        Mapper = new AutoMapper.Mapper(config);
    }
}