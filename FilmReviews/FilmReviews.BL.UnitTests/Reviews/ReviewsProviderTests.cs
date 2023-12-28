using Moq;
using BL.UnitTests.FilmDirectors;
using FilmReviews.DataAccess.Entities;
using FilmReviews.DataAccess.Repositories;
using System.Linq.Expressions;
using FilmReviews.BL.Reviews;

namespace FilmReviews.BL.UnitTests.Reviews
{

    [TestFixture]
    public class ReviewProviderTests
    {
        [Test]
        public void TestGetAllReviews()
        {
            Expression? expression = null;
            Mock<IRepository<ReviewEntity>> reviewsRepository = new();

            reviewsRepository.Setup(x => x.GetAll(It.IsAny<Expression<Func<ReviewEntity, bool>>>()))
                .Callback((Expression<Func<ReviewEntity, bool>> x) => { expression = x; });

            var reviewsProvider = new ReviewsProvider(reviewsRepository.Object, MapperHelper.Mapper);
            var reviews = reviewsProvider.Get();

            reviewsRepository.Verify(x => x.GetAll(It.IsAny<Expression<Func<ReviewEntity, bool>>>()), Times.Exactly(1));
        }
    }
}
