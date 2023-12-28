using BL.UnitTests.FilmDirectors;
using FilmFilms.BL.Films;
using FilmReviews.DataAccess.Entities;
using FilmReviews.DataAccess.Repositories;
using Moq;
using System.Linq.Expressions;

namespace FilmReviews.BL.UnitTests.Films
{

    [TestFixture]
    public class FilmProviderTests
    {
        [Test]
        public void TestGetAllFilms()
        {
            Expression? expression = null;
            Mock<IRepository<FilmEntity>> filmsRepository = new();

            filmsRepository.Setup(x => x.GetAll(It.IsAny<Expression<Func<FilmEntity, bool>>>()))
                .Callback((Expression<Func<FilmEntity, bool>> x) => { expression = x; });

            var filmsProvider = new FilmsProvider(filmsRepository.Object, MapperHelper.Mapper);
            var films = filmsProvider.Get();

            filmsRepository.Verify(x => x.GetAll(It.IsAny<Expression<Func<FilmEntity, bool>>>()), Times.Exactly(1));
        }
    }
}
