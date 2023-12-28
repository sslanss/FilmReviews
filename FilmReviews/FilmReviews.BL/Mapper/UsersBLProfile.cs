using AutoMapper;
using FilmReviews.BL.Users.Entities;
using FilmReviews.DataAccess.Entities;

namespace FilmReviews.BL.Mapper;

public class UsersBLProfile : Profile
{
    public UsersBLProfile()
    {
        CreateMap<UserEntity, UserModel>()
            .ForMember(user => user.Id, x => x.MapFrom(src => src.ExternalId))
            .ForMember(user => user.Name, x => x.MapFrom(src => src.Name))
            .ForMember(user => user.Surname, x => x.MapFrom(src => src.Surname))
            .ForMember(user => user.Email, x => x.MapFrom(src => src.Email))
            .ForMember(user => user.PasswordHash, x => x.MapFrom(src => src.PasswordHash))
            .ForMember(user => user.Reviews, x => x.MapFrom(src => src.Reviews))
            .ForMember(user => user.IsAdmin, x => x.MapFrom(src => src.IsAdmin))
            .ForMember(user => user.UserRates, x => x.MapFrom(src => src.UserRates));

        CreateMap<CreateUserModel, UserEntity>()
            .ForMember(user => user.Id, x => x.Ignore())
            .ForMember(user => user.ExternalId, x => x.Ignore())
            .ForMember(user => user.CreationTime, x => x.Ignore())
            .ForMember(user => user.ModificationTime, x => x.Ignore());
    }
}


