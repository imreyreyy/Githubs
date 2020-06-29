using GitHub.Dtos;
using GitHub.Models;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Http;

namespace GitHub.Controllers
{
    [Authorize]
    public class FollowingsController : ApiController
    {
        private ApplicationDbContext _context;

        public FollowingsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Follow(FollowingDto dto)
        {
            var userId = User.Identity.GetUserId();

            if (_context.Relationships.Any(a => a.FolloweeId == userId && a.FolloweeId == dto.FolloweeId))
            return BadRequest("Following Already Exists");
            


            var following = new Relationship
            {

               FollowerId=userId,
               FolloweeId=dto.FolloweeId


            };
            _context.Relationships.Add(following);
            _context.SaveChanges();

            return Ok();
        }
    }
}
