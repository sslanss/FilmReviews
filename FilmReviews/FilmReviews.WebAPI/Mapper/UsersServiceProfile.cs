using AutoMapper;
using FilmReviews.BL.Users.Entities;
using FilmReviews.WebAPI.Controllers.Entities.Users;

namespace FilmReviews.WebAPI.Mapper
{
    public class UsersServiceProfile : Profile
    {
        public UsersServiceProfile()
        {
            CreateMap<UsersFilter, UserModelFilter>();
            CreateMap<CreateUserRequest, CreateUserModel>();
            CreateMap<UpdateUserRequest, UpdateUserModel>();
        }
    }
}
