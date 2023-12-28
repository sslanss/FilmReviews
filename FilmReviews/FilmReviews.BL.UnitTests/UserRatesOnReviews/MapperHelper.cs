using AutoMapper;
using FilmReviews.WebAPI.Mapper;

namespace BL.UnitTests.UserRatesOnReviews;

public static class MapperHelper
{
    public static IMapper Mapper { get; }

    static MapperHelper()
    {
        var config = new MapperConfiguration(x => x.AddProfile(typeof(UserRatesOnReviewsServiceProfile)));
        Mapper = new AutoMapper.Mapper(config);
    }
}