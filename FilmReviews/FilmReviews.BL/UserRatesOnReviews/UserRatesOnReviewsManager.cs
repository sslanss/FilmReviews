using FilmReviews.DataAccess.Entities;
using FilmReviews.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilmReviews.BL.UserRates.Entities;
using FilmReviews.BL.UserRatesOnReviews.Entities;
using FilmReviews.BL.Reviews.Entities;
using AutoMapper;
using FilmReviews.DataAccess.Repositories;

namespace FilmReviews.BL.UserRatesOnReviews
{
    public class UserRatesOnReviewsManager(IRepository<UserRateOnReviewEntity> userRatesRepository, IMapper mapper) : IManager<UserRateOnReviewModel, CreateUserRateOnReviewModel>
    {
        private readonly IRepository<UserRateOnReviewEntity> _userRatesRepository = userRatesRepository;
        private readonly IMapper _mapper = mapper;

        public UserRateOnReviewModel Create(CreateUserRateOnReviewModel model)
        {
            var entity = _mapper.Map<UserRateOnReviewEntity>(model);

            _userRatesRepository.Save(entity);

            return _mapper.Map<UserRateOnReviewModel>(entity);
        }

        public UserRateOnReviewModel Update(Guid id, UserRateOnReviewModel model)
        {
            var userRate = Find(id);

            userRate.Rate = model.Rate;

            _userRatesRepository.Save(userRate);

            return _mapper.Map<UserRateOnReviewModel>(userRate);
        }

        public void Delete(Guid id)
        {
            _userRatesRepository.Delete(Find(id));
        }

        private UserRateOnReviewEntity Find(Guid id)
        {
            return _userRatesRepository.GetById(id) ?? throw new InvalidOperationException($"UserRateOnReview with ID {id} not found.");
        }
    }
}
