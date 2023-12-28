using AutoMapper;
using FilmReviews.BL.Films.Entities;
using FilmReviews.BL.Reviews.Entities;
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
    public class ReviewsBLProfile : Profile
    {
        public ReviewsBLProfile()
        {
            CreateMap<ReviewEntity, ReviewModel>()
                .ForMember(review => review.Id, x => x.MapFrom(src => src.ExternalId))
                .ForMember(review => review.User, x => x.MapFrom(src => src.User))
                .ForMember(review => review.Film, x => x.MapFrom(src => src.Film))
                .ForMember(review => review.Title, x => x.MapFrom(src => src.Title))
                .ForMember(review => review.Content, x => x.MapFrom(src => src.Content))
                .ForMember(review => review.Status, x => x.MapFrom(src => src.Status))
                .ForMember(review => review.UserRates, x => x.MapFrom(src => src.UserRates));

            CreateMap<CreateReviewModel, ReviewEntity>()
                .ForMember(review => review.Id, x => x.Ignore())
                .ForMember(review => review.ExternalId, x => x.Ignore())
                .ForMember(review => review.CreationTime, x => x.Ignore())
                .ForMember(review => review.ModificationTime, x => x.Ignore());
        }
    }
}
