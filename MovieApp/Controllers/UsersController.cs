using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using MovieApp.Models;
using MovieApp.Interfaces;

namespace MovieApp.Controllers
{
    /// <summary>
    /// User API
    /// </summary>
    /// <remarks>Handles user data.</remarks>
    [Route("api/users")]
    public class UsersController : BaseController
    {
        private IUserFactory _userFactory;

        public UsersController(IUserFactory userFactory)
        {
            _userFactory = userFactory;
        }

        // GET: api/Movies
        [ResponseType(typeof(IEnumerable<IUser>))]
        public IHttpActionResult GetUsers()
        {
            var users = _userFactory.GetUsers();

            return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, users));
        }

        // GET: api/Movies/5
        [ResponseType(typeof(IUser))]
        public IHttpActionResult GetUser(int id)
        {
            var user = _userFactory.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // PUT: api/Movies/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUser(int id, User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != user.Id)
            {
                return BadRequest();
            }

            var result = _userFactory.PutUser(id, user);
            if(result)
            {
                return Ok();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Movies
        [ResponseType(typeof(IUser))]
        public IHttpActionResult PostUser(IUser user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = _userFactory.PostUser(user);

            return CreatedAtRoute("DefaultApi", new { id = user.Id }, user);
        }

        // DELETE: api/Movies/5
        [ResponseType(typeof(IUser))]
        public IHttpActionResult DeleteUser(int id)
        {
            var result = _userFactory.DeleteUser(id);

            if (result)
            {
                return Ok();
            } else
            {
                return NotFound();
            }
        }
    }
}