using AutoMapper;
using FilmReviews.BL.Users.Entities;
using FilmReviews.DataAccess.Entities;
using FilmReviews.DataAccess.Repositories;

namespace FilmReviews.BL.Users
{
    public class UsersProvider(IRepository<UserEntity> usersRepository, IMapper mapper) : IProvider<UserModel, UserModelFilter>
    {
        private readonly IRepository<UserEntity> _repository = usersRepository;
        private readonly IMapper _mapper = mapper;

        public IEnumerable<UserModel> Get(UserModelFilter? modelFilter = null)
        {
            string? name = modelFilter?.Name;
            string? surname = modelFilter?.Surname;
            int? minReviewsCount = modelFilter?.MinReviewsCount;
            int? maxReviewsCount = modelFilter?.MaxReviewsCount;
            bool? isAdmin = modelFilter?.IsAdmin;
            int? minRatesCount = modelFilter?.MinRatesCount;
            int? maxRatesCount = modelFilter?.MaxRatesCount;

            var users = _repository.GetAll(user => (
            (name == null || user.Name.Contains(name, StringComparison.OrdinalIgnoreCase)) &&
            (surname == null || user.Surname.Contains(surname, StringComparison.OrdinalIgnoreCase)) &&
            (minReviewsCount == null || user.Reviews != null && user.Reviews.Count >= minReviewsCount) &&
            (maxReviewsCount == null || user.Reviews != null && user.Reviews.Count <= maxReviewsCount) &&
            (isAdmin == null || user.IsAdmin) &&
            (minRatesCount == null || user.UserRates != null && user.UserRates.Count >= minRatesCount) &&
            (maxRatesCount == null || user.UserRates != null && user.UserRates.Count <= maxRatesCount)
            ));

            return _mapper.Map<IEnumerable<UserModel>>(users);
        }

        public UserModel GetInfo(Guid id)
        {
            return _mapper.Map<UserModel>(Find(id));
        }

        private UserEntity Find(Guid id)
        {
            return _repository.GetById(id) ?? throw new InvalidOperationException($"User with ID {id} not found.");
        }
    }
}
