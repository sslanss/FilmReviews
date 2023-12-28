using AutoMapper;
using FilmReviews.BL.UserRatesOnReviews.Entities;
using FilmReviews.BL;
using FilmReviews.WebAPI.Controllers.Entities.UserRatesOnReviews;
using Microsoft.AspNetCore.Mvc;
using FilmReviews.BL.UserRates.Entities;

namespace FilmReviews.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserRatesOnReviewsController(IProvider<UserRateOnReviewModel, UserRateOnReviewModelFilter> provider, IManager<UserRateOnReviewModel, CreateUserRateOnReviewModel> manager, IMapper mapper, ILogger logger) : ControllerBase
    {
        private readonly IProvider<UserRateOnReviewModel, UserRateOnReviewModelFilter> _provider = provider;
        private readonly IManager<UserRateOnReviewModel, CreateUserRateOnReviewModel> _manager = manager;
        private readonly IMapper _mapper = mapper;
        private readonly ILogger _logger = logger;

        [HttpGet]
        public IActionResult GetAllUserRatesOnReviews()
        {
            var users = _provider.Get();

            return Ok(new UserRatesOnReviewsListResponse()
            {
                UserRates = users.ToList()
            });
        }

        [HttpGet]
        [Route("filter")]
        public IActionResult GetFilteredUserRatesOnReviews([FromQuery] UserRatesOnReviewsFilter filter)
        {
            var users = _provider.Get(_mapper.Map<UserRateOnReviewModelFilter>(filter));

            return Ok(new UserRatesOnReviewsListResponse()
            {
                UserRates = users.ToList()
            });
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetUserRatesOnReviewInfo([FromRoute] Guid id)
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
        public IActionResult CreateUserRatesOnReview([FromBody] CreateUserRateOnReviewRequest request)
        {
            try
            {
                var user = _manager.Create(_mapper.Map<CreateUserRateOnReviewModel>(request));

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
        public IActionResult UpdateUserRatesOnReviewInfo([FromRoute] Guid id, UpdateUserRateOnReviewRequest request)
        {
            try
            {
                var user = _provider.GetInfo(id);

                if (user is null)
                {
                    return NotFound($"UserRatesOnReview with ID {id} not found.");
                }

                _mapper.Map(request, user);

                var updatedUserRatesOnReview = _manager.Update(id, user);

                return Ok(updatedUserRatesOnReview);
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogError(ex.ToString());

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteUserRatesOnReview([FromRoute] Guid id)
        {
            try
            {
                var user = _provider.GetInfo(id);

                if (user is null)
                {
                    return NotFound($"UserRatesOnReview with ID {id} not found.");
                }

                _manager.Delete(id);

                return Ok($"UserRatesOnReview with ID {id} deleted successfully.");
            }
            catch (ArgumentException ex)
            {
                _logger.LogError(ex.ToString());

                return BadRequest(ex.Message);
            }
        }
    }
}
