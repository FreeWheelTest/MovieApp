using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using MovieApp.Models;
using MovieApp.Interfaces;

namespace MovieApp.Controllers
{
    /// <summary>
    /// Ratings API
    /// </summary>
    /// <remarks>Handles movie rating data.</remarks>
    [Route("api/ratings")]
    public class RatingsController : ApiController
    {
        private IRatingFactory _ratingFactory;
        private IMovieFactory _movieFactory;
        private IUserFactory _userFactory;

        public RatingsController(IRatingFactory ratingFactory, IMovieFactory movieFactory, IUserFactory userFactory)
        {
            _ratingFactory = ratingFactory;
            _movieFactory = movieFactory;
            _userFactory = userFactory;
        }
        
        [HttpGet]
        [ResponseType(typeof(IRating))]
        public IHttpActionResult GetRatings()
        {
            var ratings = _ratingFactory.GetRatings();
            return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, ratings));
        }

        /*
        // GET: api/Ratings/5
        [HttpGet]
        [ResponseType(typeof(IRating))]
        public IHttpActionResult GetRating(int id)
        {
            var rating = _ratingFactory.GetRating(id);
            if (rating == null)
            {
                return NotFound();
            }

            return Ok(rating);
        }
        */

        /// <summary>
        /// Update movie rating.
        /// </summary>
        /// <remarks>Update movie rating.</remarks>
        /// <response code="200">OK</response>
        /// <response code="400">Bad Request</response>
        /// <response code="404">Not Found</response>
        [Route("api/ratings/update")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRating(int id, Rating rating)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            rating.Id = id;

            if (id != rating.Id)
            {
                return BadRequest();
            }

            var movie = _movieFactory.GetMovie(rating.MovieId);
            var user = _userFactory.GetUser(rating.UserId);
            if (movie != null && user != null)
            {
                var result = _ratingFactory.PutRating(id, rating);
                if (result)
                {
                    return Ok();
                }
            } else
            {
                return BadRequest();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        /// <summary>
        /// Create movie rating.
        /// </summary>
        /// <remarks>Create movie rating.</remarks>
        /// <response code="200">OK</response>
        /// <response code="400">Bad Request</response>
        /// <response code="404">Not Found</response>
        [Route("api/ratings/create")]
        [HttpPost]
        [ResponseType(typeof(void))]
        public IHttpActionResult PostRating([FromBody] Rating rating)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var movie = _movieFactory.GetMovie(rating.MovieId);
            var user = _userFactory.GetUser(rating.UserId);
            if (movie != null && user != null)
            {
                var result = _ratingFactory.PostRating(rating);
                if (!result)
                {
                    return NotFound();
                }

                if (result)
                {
                    return Ok();
                }
            } else
            {
                return BadRequest();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        /*
        // DELETE: api/Ratings/5
        [ResponseType(typeof(Rating))]
        public IHttpActionResult DeleteRating(int id)
        {
            var result = _ratingFactory.DeleteRating(id);

            if (result)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
        */
    }
}