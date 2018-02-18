using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using MovieApp.Interfaces;

namespace MovieApp.Controllers
{
    /// <summary>
    /// Movie API
    /// </summary>
    /// <remarks>Handles movie data.</remarks>
    [Route("api/movies")]
    public class MoviesController : BaseController
    {
        private IMovieFactory _movieFactory;
        private IRatingFactory _ratingFactory;

        public MoviesController(IMovieFactory movieFactory, IRatingFactory ratingFactory)
        {
            _movieFactory = movieFactory;
            _ratingFactory = ratingFactory;
        }

        /// <summary>
        /// Gets the movie list by criteria.
        /// </summary>
        /// <remarks>Gets the movie list by criteria.</remarks>
        /// <returns>Returns a movie list.</returns>
        /// <response code="200">OK</response>
        /// <response code="400">Bad Request</response>
        /// <response code="404">Not Found</response>
        [HttpGet]
        [Route("search")]
        [ResponseType(typeof(IEnumerable<IMovie>))]
        public IHttpActionResult GetMoviesByCriteria(string title = null, string genre = null, int? yearOfRelease = null)
        {
            if(string.IsNullOrEmpty(title) && string.IsNullOrEmpty(genre) && string.IsNullOrEmpty(yearOfRelease.ToString()))
            {
                return BadRequest();
            }

            var movies = _movieFactory.GetMoviesByCriteria(title, genre, yearOfRelease);

            if (movies == null)
            {
                return NotFound();
            }

            return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, movies));
        }

        /// <summary>
        /// Gets the movie list by highest average rating.
        /// </summary>
        /// <remarks>Gets the movie list by highest average rating..</remarks>
        /// <returns>Returns a movie list.</returns>
        /// <response code="200">OK</response>
        /// <response code="400">Bad Request</response>
        /// <response code="404">Not Found</response>
        [HttpGet]
        [Route("top-five")]
        [ResponseType(typeof(IEnumerable<IMovie>))]
        public IHttpActionResult GetHighestTopFive()
        {
            var movies = _movieFactory.GetHighestTopFive();

            if (movies == null)
            {
                return NotFound();
            }

            return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, movies));
        }


        /// <summary>
        /// Gets the movie list by highest average rating.
        /// </summary>
        /// <remarks>Gets the movie list by highest average rating..</remarks>
        /// <returns>Returns a movie list.</returns>
        /// <response code="200">OK</response>
        /// <response code="400">Bad Request</response>
        /// <response code="404">Not Found</response>
        [HttpGet]
        [Route("user-top-five")]
        [ResponseType(typeof(IEnumerable<IMovie>))]
        public IHttpActionResult GetHighestTopFiveByUser(int userId)
        {
            var movies = _movieFactory.GetHighestTopFiveByUser(userId);

            if (movies == null)
            {
                return NotFound();
            }

            return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, movies));
        }

        /*
        [HttpGet]
        [Route("list")]
        [ResponseType(typeof(IEnumerable<IMovie>))]
        public IHttpActionResult GetMovies()
        {
            var movies = _movieFactory.GetMovies();
            return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, movies));
        }

        [HttpGet]
        [ResponseType(typeof(IMovie))]
        public IHttpActionResult GetMovie(int id)
        {
            var movie = _movieFactory.GetMovie(id);
            if (movie == null)
            {
                return NotFound();
            }

            return Ok(movie);
        }

        // PUT: api/movies/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMovie(int id, Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != movie.Id)
            {
                return BadRequest();
            }

            var result = _movieFactory.PutMovie(id, movie);
            if(result)
            {
                return Ok();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/movies
        [ResponseType(typeof(IMovie))]
        public IHttpActionResult PostMovie(IMovie movie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = _movieFactory.PostMovie(movie);

            return CreatedAtRoute("DefaultApi", new { id = movie.Id }, movie);
        }

        // DELETE: api/movies/5
        [ResponseType(typeof(IMovie))]
        public IHttpActionResult DeleteMovie(int id)
        {
            var result = _movieFactory.DeleteMovie(id);

            if (result)
            {
                return Ok();
            } else
            {
                return NotFound();
            }
        }
        */
    }
}