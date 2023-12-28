using FilmReviews.DataAccess.Entities;
using FilmReviews.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilmReviews.BL.UserRatesOnReviews.Entities;
using FilmReviews.BL.Reviews.Entities;
using AutoMapper;
using FilmReviews.DataAccess.Repositories;

namespace FilmReviews.BL.UserRatesOnReviews
{
    public class UserRatesOnReviewsProvider(IRepository<UserRateOnReviewEntity> userRatesRepository, IMapper mapper) : IProvider<UserRateOnReviewModel, UserRateOnReviewModelFilter>
    {
        private readonly IRepository<UserRateOnReviewEntity> _repository = userRatesRepository;
        private readonly IMapper _mapper = mapper;

        public IEnumerable<UserRateOnReviewModel> Get(UserRateOnReviewModelFilter? modelFilter = null)
        {

            string? userName = modelFilter?.UserName;
            string? reviewTitle = modelFilter?.ReviewTitle;
            int? minRate = modelFilter?.MinRate;
            int? maxRate = modelFilter?.MaxRate;

            var userRates = _repository.GetAll(userRate => (
            (userName == null || userRate.User.Name.Contains(userName, StringComparison.OrdinalIgnoreCase)) &&
            (reviewTitle == null || userRate.Review.Title.Contains(reviewTitle, StringComparison.OrdinalIgnoreCase)) &&
            (minRate == null || userRate.Rate >= minRate) &&
            (maxRate == null || userRate.Rate >= maxRate)
            ));

            return _mapper.Map<IEnumerable<UserRateOnReviewModel>>(userRates);
        }

        public UserRateOnReviewModel GetInfo(Guid id)
        {
            return _mapper.Map<UserRateOnReviewModel>(Find(id));
        }

        private UserRateOnReviewEntity Find(Guid id)
        {
            return _repository.GetById(id) ?? throw new InvalidOperationException($"UserRateOnReview with ID {id} not found.");
        }
    }
}
