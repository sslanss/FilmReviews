using AutoMapper;
using FilmReviews.BL.FilmDirectors.Entities;
using FilmReviews.WebAPI.Controllers.Entities.FilmDirectors;

namespace FilmReviews.WebAPI.Mapper
{
    public class FilmDirectorsServiceProfile : Profile
    {
        public FilmDirectorsServiceProfile()
        {
            CreateMap<FilmDirectorsFilter, FilmDirectorModelFilter>();
            CreateMap<CreateFilmDirectorRequest, CreateFilmDirectorModel>();
            CreateMap<UpdateFilmDirectorRequest, UpdateFilmDirectorModel>();
        }
    }
}
