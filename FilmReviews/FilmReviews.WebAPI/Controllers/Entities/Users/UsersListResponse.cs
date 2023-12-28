using FilmReviews.BL.Users.Entities;

namespace FilmReviews.WebAPI.Controllers.Entities.Users
{
    public class UsersListResponse
    {
        public List<UserModel>? Users { get; set; }
    }
}
