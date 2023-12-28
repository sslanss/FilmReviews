using AutoMapper;
using FilmReviews.BL;
using FilmReviews.BL.FilmDirectors.Entities;
using FilmReviews.DataAccess;
using FilmReviews.DataAccess.Entities;
using FilmReviews.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmDirectorReviews.BL.FilmDirectorDirectors
{
    public class FilmDirectorsProvider(IRepository<FilmDirectorEntity> directorsRepository, IMapper mapper) : IProvider<FilmDirectorModel, FilmDirectorModelFilter>
    {
        private readonly IRepository<FilmDirectorEntity> _repository = directorsRepository;
        private readonly IMapper _mapper = mapper;

        public IEnumerable<FilmDirectorModel> Get(FilmDirectorModelFilter? modelFilter = null)
        {
            string? name = modelFilter?.Name;

            var directors = _repository.GetAll(director => (
            (name == null || director.Name.Contains(name, StringComparison.OrdinalIgnoreCase))
            ));

            return _mapper.Map<IEnumerable<FilmDirectorModel>>(directors);
        }

        public FilmDirectorModel GetInfo(Guid id)
        {
            return _mapper.Map<FilmDirectorModel>(Find(id));
        }

        private FilmDirectorEntity Find(Guid id)
        {
            return _repository.GetById(id) ?? throw new InvalidOperationException($"FilmDirector with ID {id} not found.");
        }
    }
}
