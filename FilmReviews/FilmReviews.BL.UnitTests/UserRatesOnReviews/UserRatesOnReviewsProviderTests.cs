using BL.UnitTests.FilmDirectors;
using FilmReviews.DataAccess.Entities;
using FilmReviews.DataAccess.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using FilmReviews.BL.UserRatesOnReviews;

namespace FilmReviews.BL.UnitTests.UserRateOnReviewRatesOnReviews
{

    [TestFixture]
    public class UserRateOnReviewProviderTests
    {
        [Test]
        public void TestGetAllUserRateOnReviews()
        {
            Expression? expression = null;
            Mock<IRepository<UserRateOnReviewEntity>> userRatesRepository = new();

            userRatesRepository.Setup(x => x.GetAll(It.IsAny<Expression<Func<UserRateOnReviewEntity, bool>>>()))
                .Callback((Expression<Func<UserRateOnReviewEntity, bool>> x) => { expression = x; });

            var userRatesProvider = new UserRatesOnReviewsProvider(userRatesRepository.Object, MapperHelper.Mapper);
            var userRates = userRatesProvider.Get();

            userRatesRepository.Verify(x => x.GetAll(It.IsAny<Expression<Func<UserRateOnReviewEntity, bool>>>()), Times.Exactly(1));
        }
    }
}
