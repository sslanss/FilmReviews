using FilmReviews.BL.UserRatesOnReviews.Entities;
using FilmReviews.DataAccess.Entities;
using FilmReviews.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilmReviews.BL.Reviews.Entities;
using AutoMapper;
using FilmReviews.DataAccess.Repositories;

namespace FilmReviews.BL.Reviews
{
    public class ReviewsProvider(IRepository<ReviewEntity> reviewsRepository, IMapper mapper) : IProvider<ReviewModel, ReviewModelFilter>
    {
        private readonly IRepository<ReviewEntity> _repository = reviewsRepository;
        private readonly IMapper _mapper = mapper;

        public IEnumerable<ReviewModel> Get(ReviewModelFilter? modelFilter = null)
        {
            string? userName = modelFilter?.UserName;
            string? filmName = modelFilter?.FilmName;
            string? title = modelFilter?.Title;
            ReviewEntity.ReviewStatus? status = modelFilter?.Status;

            var reviews = _repository.GetAll(review => (
            (userName == null || review.User.Name.Contains(userName, StringComparison.OrdinalIgnoreCase)) &&
            (filmName == null || review.Film.Name.Contains(filmName, StringComparison.OrdinalIgnoreCase)) &&
            (title == null || review.Title.Contains(title, StringComparison.OrdinalIgnoreCase)) &&
            (status == null || review.Status >= status)
            ));

            return _mapper.Map<IEnumerable<ReviewModel>>(reviews);
        }

        public ReviewModel GetInfo(Guid id)
        {
            return _mapper.Map<ReviewModel>(Find(id));
        }

        private ReviewEntity Find(Guid id)
        {
            return _repository.GetById(id) ?? throw new InvalidOperationException($"Review with ID {id} not found.");
        }
    }
}

