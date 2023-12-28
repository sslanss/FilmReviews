using AutoMapper;
using FilmReviews.BL.UserRates.Entities;
using FilmReviews.BL.UserRatesOnReviews.Entities;
using FilmReviews.WebAPI.Controllers.Entities.UserRatesOnReviews;

namespace FilmReviews.WebAPI.Mapper
{
    public class UserRatesOnReviewsServiceProfile : Profile
    {
        public UserRatesOnReviewsServiceProfile()
        {
            CreateMap<UserRatesOnReviewsFilter, UserRateOnReviewModelFilter>();
            CreateMap<CreateUserRateOnReviewRequest, CreateUserRateOnReviewModel>();
            CreateMap<UpdateUserRateOnReviewRequest, UpdateUserRateOnReviewModel>();
        }
    }
}
