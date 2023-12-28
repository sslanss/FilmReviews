using BL.UnitTests.FilmDirectors;
using FilmDirectorReviews.BL.FilmDirectorDirectors;
using FilmReviews.DataAccess.Entities;
using FilmReviews.DataAccess.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FilmReviews.BL.UnitTests.FilmDirectors
{

    [TestFixture]
    public class FilmDirectorProviderTests
    {
        [Test]
        public void TestGetAllFilmDirectors()
        {
            Expression? expression = null;
            Mock<IRepository<FilmDirectorEntity>> directorsRepository = new();

            directorsRepository.Setup(x => x.GetAll(It.IsAny<Expression<Func<FilmDirectorEntity, bool>>>()))
                .Callback((Expression<Func<FilmDirectorEntity, bool>> x) => { expression = x; });

            var directorsProvider = new FilmDirectorsProvider(directorsRepository.Object, MapperHelper.Mapper);
            var directors = directorsProvider.Get();

            directorsRepository.Verify(x => x.GetAll(It.IsAny<Expression<Func<FilmDirectorEntity, bool>>>()), Times.Exactly(1));
        }
    }
}
