using AutoMapper;
using FilmReviews.BL.Films.Entities;
using FilmReviews.WebAPI.Controllers.Entities.Films;

namespace FilmReviews.WebAPI.Mapper
{
    public class FilmsServiceProfile : Profile
    {
        public FilmsServiceProfile()
        {
            CreateMap<FilmsFilter, FilmModelFilter>();
            CreateMap<CreateFilmRequest, CreateFilmModel>();
            CreateMap<UpdateFilmRequest, UpdateFilmModel>();
        }
    }
}
