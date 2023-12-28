using AutoMapper;
using FilmReviews.BL.Films.Entities;
using FilmReviews.BL;
using FilmReviews.WebAPI.Controllers.Entities.Films;
using Microsoft.AspNetCore.Mvc;

namespace FilmReviews.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmsController(IProvider<FilmModel, FilmModelFilter> provider, IManager<FilmModel, CreateFilmModel> manager, IMapper mapper, ILogger logger) : ControllerBase
    {
        private readonly IProvider<FilmModel, FilmModelFilter> _provider = provider;
        private readonly IManager<FilmModel, CreateFilmModel> _manager = manager;
        private readonly IMapper _mapper = mapper;
        private readonly ILogger _logger = logger;

        [HttpGet]
        public IActionResult GetAllFilms()
        {
            var users = _provider.Get();

            return Ok(new FilmsListResponse()
            {
                Films = users.ToList()
            });
        }

        [HttpGet]
        [Route("filter")]
        public IActionResult GetFilteredFilms([FromQuery] FilmsFilter filter)
        {
            var users = _provider.Get(_mapper.Map<FilmModelFilter>(filter));

            return Ok(new FilmsListResponse()
            {
                Films = users.ToList()
            });
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetFilmInfo([FromRoute] Guid id)
        {
            try
            {
                var user = _provider.GetInfo(id);

                return Ok(user);
            }
            catch (ArgumentException ex)
            {
                _logger.LogError(ex.ToString());

                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult CreateFilm([FromBody] CreateFilmRequest request)
        {
            try
            {
                var user = _manager.Create(_mapper.Map<CreateFilmModel>(request));

                return Ok(user);
            }
            catch (ArgumentException ex)
            {
                _logger.LogError(ex.ToString());

                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateFilmInfo([FromRoute] Guid id, UpdateFilmRequest request)
        {
            try
            {
                var user = _provider.GetInfo(id);

                if (user is null)
                {
                    return NotFound($"Film with ID {id} not found.");
                }

                _mapper.Map(request, user);

                var updatedFilm = _manager.Update(id, user);

                return Ok(updatedFilm);
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogError(ex.ToString());

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteFilm([FromRoute] Guid id)
        {
            try
            {
                var user = _provider.GetInfo(id);

                if (user is null)
                {
                    return NotFound($"Film with ID {id} not found.");
                }

                _manager.Delete(id);

                return Ok($"Film with ID {id} deleted successfully.");
            }
            catch (ArgumentException ex)
            {
                _logger.LogError(ex.ToString());

                return BadRequest(ex.Message);
            }
        }
    }
}
