using FilmReviews.DataAccess.Entities;
using FilmReviews.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilmReviews.BL.Reviews.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using AutoMapper;
using FilmReviews.BL.UserRatesOnReviews.Entities;
using FilmReviews.DataAccess.Repositories;

namespace FilmReviews.BL.Reviews
{
    public class ReviewsManager(IRepository<ReviewEntity> reviewsRepository, IMapper mapper) : IManager<ReviewModel, CreateReviewModel>
    {
        private readonly IRepository<ReviewEntity> _reviewsRepository = reviewsRepository;
        private readonly IMapper _mapper = mapper;

        public ReviewModel Create(CreateReviewModel model)
        {
            var entity = _mapper.Map<ReviewEntity>(model);

            _reviewsRepository.Save(entity);

            return _mapper.Map<ReviewModel>(entity);
        }

        public ReviewModel Update(Guid id, ReviewModel model)
        {
            var review = Find(id);

            review.Title = model.Title;
            review.Content = model.Content;
            review.Status = model.Status;
            review.UserRates = (ICollection<UserRateOnReviewEntity>?)model.UserRates;

            _reviewsRepository.Save(review);

            return _mapper.Map<ReviewModel>(review);
        }

        public void Delete(Guid id)
        {
            _reviewsRepository.Delete(Find(id));
        }

        private ReviewEntity Find(Guid id)
        {
            return _reviewsRepository.GetById(id) ?? throw new InvalidOperationException($"Review with ID {id} not found.");
        }
    }
}
