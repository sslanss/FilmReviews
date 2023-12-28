using AutoMapper;
using FilmReviews.BL.Reviews.Entities;
using FilmReviews.BL.UserRates.Entities;
using FilmReviews.BL.UserRatesOnReviews.Entities;
using FilmReviews.BL.Users.Entities;
using FilmReviews.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmReviews.BL.Mapper
{
    public class UserRatesOnReviewsBLProfile : Profile
    {
        public UserRatesOnReviewsBLProfile()
        {
            CreateMap<UserRateOnReviewEntity, UserRateOnReviewModel>()
                .ForMember(userRate => userRate.Id, x => x.MapFrom(src => src.ExternalId))
                .ForMember(userRate => userRate.User, x => x.MapFrom(src => src.User))
                .ForMember(userRate => userRate.Review, x => x.MapFrom(src => src.Review))
                .ForMember(userRate => userRate.Rate, x => x.MapFrom(src => src.Rate));

            CreateMap<CreateUserRateOnReviewModel, UserRateOnReviewEntity>()
                .ForMember(userRate => userRate.Id, x => x.Ignore())
                .ForMember(userRate => userRate.ExternalId, x => x.Ignore())
                .ForMember(userRate => userRate.CreationTime, x => x.Ignore())
                .ForMember(userRate => userRate.ModificationTime, x => x.Ignore());
        }
    }
}
