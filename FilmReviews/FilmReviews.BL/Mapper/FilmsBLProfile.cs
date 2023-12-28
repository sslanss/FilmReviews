using AutoMapper;
using FilmReviews.BL.FilmDirectors.Entities;
using FilmReviews.BL.Films.Entities;
using FilmReviews.BL.Reviews.Entities;
using FilmReviews.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmReviews.BL.Mapper
{
    public class FilmsBLProfile : Profile
    {
        public FilmsBLProfile()
        {
            CreateMap<FilmEntity, FilmModel>()
                .ForMember(film => film.Id, x => x.MapFrom(src => src.ExternalId))
                .ForMember(film => film.Name, x => x.MapFrom(src => src.Name))
                .ForMember(film => film.Reviews, x => x.MapFrom(src => src.Reviews));

            CreateMap<CreateFilmModel, FilmEntity>()
                .ForMember(film => film.Id, x => x.Ignore())
                .ForMember(film => film.ExternalId, x => x.Ignore())
                .ForMember(film => film.CreationTime, x => x.Ignore())
                .ForMember(film => film.ModificationTime, x => x.Ignore());
        }
    }
}
