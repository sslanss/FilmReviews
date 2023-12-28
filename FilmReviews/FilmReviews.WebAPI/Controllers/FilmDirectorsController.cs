using AutoMapper;
using FilmReviews.BL.FilmDirectors.Entities;
using FilmReviews.BL;
using FilmReviews.WebAPI.Controllers.Entities.FilmDirectors;
using Microsoft.AspNetCore.Mvc;

namespace FilmReviews.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmDirectorsController(IProvider<FilmDirectorModel, FilmDirectorModelFilter> provider, IManager<FilmDirectorModel, CreateFilmDirectorModel> manager, IMapper mapper, ILogger logger) : ControllerBase
    {
        private readonly IProvider<FilmDirectorModel, FilmDirectorModelFilter> _provider = provider;
        private readonly IManager<FilmDirectorModel, CreateFilmDirectorModel> _manager = manager;
        private readonly IMapper _mapper = mapper;
        private readonly ILogger _logger = logger;

        [HttpGet]
        public IActionResult GetAllFilmDirectors()
        {
            var users = _provider.Get();

            return Ok(new FilmDirectorsListResponse()
            {
                FilmDirectors = users.ToList()
            });
        }

        [HttpGet]
        [Route("filter")]
        public IActionResult GetFilteredFilmDirectors([FromQuery] FilmDirectorsFilter filter)
        {
            var users = _provider.Get(_mapper.Map<FilmDirectorModelFilter>(filter));

            return Ok(new FilmDirectorsListResponse()
            {
                FilmDirectors = users.ToList()
            });
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetFilmDirectorInfo([FromRoute] Guid id)
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
        public IActionResult CreateFilmDirector([FromBody] CreateFilmDirectorRequest request)
        {
            try
            {
                var user = _manager.Create(_mapper.Map<CreateFilmDirectorModel>(request));

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
        public IActionResult UpdateFilmDirectorInfo([FromRoute] Guid id, UpdateFilmDirectorRequest request)
        {
            try
            {
                var user = _provider.GetInfo(id);

                if (user is null)
                {
                    return NotFound($"FilmDirector with ID {id} not found.");
                }

                _mapper.Map(request, user);

                var updatedFilmDirector = _manager.Update(id, user);

                return Ok(updatedFilmDirector);
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogError(ex.ToString());

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteFilmDirector([FromRoute] Guid id)
        {
            try
            {
                var user = _provider.GetInfo(id);

                if (user is null)
                {
                    return NotFound($"FilmDirector with ID {id} not found.");
                }

                _manager.Delete(id);

                return Ok($"FilmDirector with ID {id} deleted successfully.");
            }
            catch (ArgumentException ex)
            {
                _logger.LogError(ex.ToString());

                return BadRequest(ex.Message);
            }
        }
    }
}
