using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilmReviews.BL.Films.Entities;
using FilmReviews.DataAccess.Entities;
using FilmReviews.BL;
using FilmReviews.DataAccess;
using AutoMapper;
using FilmReviews.DataAccess.Repositories;

namespace FilmFilms.BL.Films
{
    public class FilmsProvider(IRepository<FilmEntity> filmsRepository, IMapper mapper) : IProvider<FilmModel, FilmModelFilter>
    {
        private readonly IRepository<FilmEntity> _repository = filmsRepository;
        private readonly IMapper _mapper = mapper;

        public IEnumerable<FilmModel> Get(FilmModelFilter? modelFilter = null)
        {
            string? name = modelFilter?.Name;
            string? directorName = modelFilter?.DirectorName;

            var films = _repository.GetAll(film => (
            (name == null || film.Name.Contains(name, StringComparison.OrdinalIgnoreCase)) &&
            (directorName == null || film.Director.Name.Contains(directorName, StringComparison.OrdinalIgnoreCase))
            ));

            return _mapper.Map<IEnumerable<FilmModel>>(films);
        }

        public FilmModel GetInfo(Guid id)
        {
            return _mapper.Map<FilmModel>(Find(id));
        }

        private FilmEntity Find(Guid id)
        {
            return _repository.GetById(id) ?? throw new InvalidOperationException($"Film with ID {id} not found.");
        }
    }
}

