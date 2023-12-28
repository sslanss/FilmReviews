using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using AutoMapper;
using FilmReviews.BL;
using FilmReviews.DataAccess.Entities;
using FilmReviews.DataAccess;
using FilmReviews.BL.Films.Entities;
using FilmReviews.DataAccess.Repositories;

namespace FilmFilms.BL.Films
{
    public class FilmsManager(IRepository<FilmEntity> filmsRepository, IMapper mapper) : IManager<FilmModel, CreateFilmModel>
    {
        private readonly IRepository<FilmEntity> _filmsRepository = filmsRepository;
        private readonly IMapper _mapper = mapper;

        public FilmModel Create(CreateFilmModel model)
        {
            var entity = _mapper.Map<FilmEntity>(model);

            _filmsRepository.Save(entity);

            return _mapper.Map<FilmModel>(entity);
        }

        public FilmModel Update(Guid id, FilmModel model)
        {
            var film = Find(id);

            film.Name = model.Name;
            film.Reviews = (ICollection<ReviewEntity>?)model.Reviews;

            _filmsRepository.Save(film);

            return _mapper.Map<FilmModel>(film);
        }

        public void Delete(Guid id)
        {
            _filmsRepository.Delete(Find(id));
        }

        private FilmEntity Find(Guid id)
        {
            return _filmsRepository.GetById(id) ?? throw new InvalidOperationException($"Film with ID {id} not found.");
        }
    }
}
