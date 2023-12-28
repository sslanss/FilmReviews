using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using AutoMapper;
using FilmReviews.DataAccess;
using FilmReviews.BL;
using FilmReviews.DataAccess.Entities;
using FilmReviews.BL.FilmDirectors.Entities;
using FilmReviews.DataAccess.Repositories;

namespace FilmDirectorFilmDirectors.BL.FilmDirectors
{
    public class FilmDirectorsManager(IRepository<FilmDirectorEntity> filmDirectorsRepository, IMapper mapper) : IManager<FilmDirectorModel, CreateFilmDirectorModel>
    {
        private readonly IRepository<FilmDirectorEntity> _filmDirectorsRepository = filmDirectorsRepository;
        private readonly IMapper _mapper = mapper;

        public FilmDirectorModel Create(CreateFilmDirectorModel model)
        {
            var entity = _mapper.Map<FilmDirectorEntity>(model);

            _filmDirectorsRepository.Save(entity);

            return _mapper.Map<FilmDirectorModel>(entity);
        }

        public FilmDirectorModel Update(Guid id, FilmDirectorModel model)
        {
            var filmDirector = Find(id);

            filmDirector.Name = model.Name;
            filmDirector.Films = (ICollection<FilmEntity>?)model.Films;

            _filmDirectorsRepository.Save(filmDirector);

            return _mapper.Map<FilmDirectorModel>(filmDirector);
        }

        public void Delete(Guid id)
        {
            _filmDirectorsRepository.Delete(Find(id));
        }

        private FilmDirectorEntity Find(Guid id)
        {
            return _filmDirectorsRepository.GetById(id) ?? throw new InvalidOperationException($"FilmDirector with ID {id} not found.");
        }
    }
}
