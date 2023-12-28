using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using FilmReviews.BL.Users;
using FilmReviews.DataAccess.Entities;
using FilmReviews.DataAccess.Repositories;
using BL.UnitTests.FilmDirectors;

namespace FilmReviews.BL.UnitTests.Users
{
    [TestFixture]
    public class UserProviderTests
    {
        [Test]
        public void TestGetAllUsers()
        {
            Expression? expression = null;
            Mock<IRepository<UserEntity>> usersRepository = new();

            usersRepository.Setup(x => x.GetAll(It.IsAny<Expression<Func<UserEntity, bool>>>()))
                .Callback((Expression<Func<UserEntity, bool>> x) => { expression = x; });

            var usersProvider = new UsersProvider(usersRepository.Object, MapperHelper.Mapper);
            var users = usersProvider.Get();

            usersRepository.Verify(x => x.GetAll(It.IsAny<Expression<Func<UserEntity, bool>>>()), Times.Exactly(1));
        }
    }
}
