using AutoMapper;
using FilmReviews.BL.Reviews.Entities;
using FilmReviews.WebAPI.Controllers.Entities.Reviews;

namespace FilmReviews.WebAPI.Mapper
{
    public class ReviewsServiceProfile : Profile
    {
        public ReviewsServiceProfile()
        {
            CreateMap<ReviewsFilter, ReviewModelFilter>();
            CreateMap<CreateReviewRequest, CreateReviewModel>();
            CreateMap<UpdateReviewRequest, UpdateReviewModel>();
        }
    }
}
