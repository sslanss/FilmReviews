using FilmReviews.DataAccess.Entities;
using FilmReviews.DataAccess;
using FilmReviews.BL.Users.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilmReviews.BL.Reviews.Entities;
using FilmReviews.BL.UserRatesOnReviews.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using AutoMapper;
using FilmReviews.DataAccess.Repositories;

namespace FilmReviews.BL.Users
{
    public class UsersManager(IRepository<UserEntity> usersRepository, IMapper mapper) : IManager<UserModel, CreateUserModel>
    {
        private readonly IRepository<UserEntity> _usersRepository = usersRepository;
        private readonly IMapper _mapper = mapper;

        public UserModel Create(CreateUserModel model)
        {
            var entity = _mapper.Map<UserEntity>(model);

            _usersRepository.Save(entity);

            return _mapper.Map<UserModel>(entity);
        }

        public UserModel Update(Guid id, UserModel model)
        {
            var user = Find(id);

            user.Name = model.Name;
            user.Surname = model.Surname;
            user.Email = model.Email;
            user.PasswordHash = model.PasswordHash;
            user.Reviews = (ICollection<ReviewEntity>?)model.Reviews;
            user.IsAdmin = model.IsAdmin;
            user.UserRates = (ICollection<UserRateOnReviewEntity>?)model.UserRates;

            _usersRepository.Save(user);

            return _mapper.Map<UserModel>(user);
        }

        public void Delete(Guid id)
        {
            _usersRepository.Delete(Find(id));
        }

        private UserEntity Find(Guid id)
        {
            return _usersRepository.GetById(id) ?? throw new InvalidOperationException($"User with ID {id} not found.");
        }
    }
}
