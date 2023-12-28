using AutoMapper;
using FilmReviews.BL.Reviews.Entities;
using FilmReviews.BL;
using FilmReviews.WebAPI.Controllers.Entities.Reviews;
using Microsoft.AspNetCore.Mvc;

namespace FilmReviews.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReviewsController(IProvider<ReviewModel, ReviewModelFilter> provider, IManager<ReviewModel, CreateReviewModel> manager, IMapper mapper, ILogger logger) : ControllerBase
    {
        private readonly IProvider<ReviewModel, ReviewModelFilter> _provider = provider;
        private readonly IManager<ReviewModel, CreateReviewModel> _manager = manager;
        private readonly IMapper _mapper = mapper;
        private readonly ILogger _logger = logger;

        [HttpGet]
        public IActionResult GetAllReviews()
        {
            var users = _provider.Get();

            return Ok(new ReviewsListResponse()
            {
                Reviews = users.ToList()
            });
        }

        [HttpGet]
        [Route("filter")]
        public IActionResult GetFilteredReviews([FromQuery] ReviewsFilter filter)
        {
            var users = _provider.Get(_mapper.Map<ReviewModelFilter>(filter));

            return Ok(new ReviewsListResponse()
            {
                Reviews = users.ToList()
            });
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetReviewInfo([FromRoute] Guid id)
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
        public IActionResult CreateReview([FromBody] CreateReviewRequest request)
        {
            try
            {
                var user = _manager.Create(_mapper.Map<CreateReviewModel>(request));

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
        public IActionResult UpdateReviewInfo([FromRoute] Guid id, UpdateReviewRequest request)
        {
            try
            {
                var user = _provider.GetInfo(id);

                if (user is null)
                {
                    return NotFound($"Review with ID {id} not found.");
                }

                _mapper.Map(request, user);

                var updatedReview = _manager.Update(id, user);

                return Ok(updatedReview);
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogError(ex.ToString());

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteReview([FromRoute] Guid id)
        {
            try
            {
                var user = _provider.GetInfo(id);

                if (user is null)
                {
                    return NotFound($"Review with ID {id} not found.");
                }

                _manager.Delete(id);

                return Ok($"Review with ID {id} deleted successfully.");
            }
            catch (ArgumentException ex)
            {
                _logger.LogError(ex.ToString());

                return BadRequest(ex.Message);
            }
        }
    }
}
