using AutoMapper;
using FilmReviews.BL.FilmDirectors.Entities;
using FilmReviews.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmReviews.BL.Mapper
{
    public class FilmDirectorsBLProfile : Profile
    {
        public FilmDirectorsBLProfile()
        {
            CreateMap<FilmDirectorEntity, FilmDirectorModel>()
                .ForMember(director => director.Id, x => x.MapFrom(src => src.ExternalId))
                .ForMember(director => director.Name, x => x.MapFrom(src => src.Name))
                .ForMember(director => director.Films, x => x.MapFrom(src => src.Films));

            CreateMap<CreateFilmDirectorModel, FilmDirectorEntity>()
                .ForMember(director => director.Id, x => x.Ignore())
                .ForMember(director => director.ExternalId, x => x.Ignore())
                .ForMember(director => director.CreationTime, x => x.Ignore())
                .ForMember(director => director.ModificationTime, x => x.Ignore());
        }
    }
}
