using GitHub.Models;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Mvc;

namespace GitHub.Controllers
{
    public class FolloweesController : Controller
    {

        private ApplicationDbContext _context;

        public FolloweesController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Followees
        public ActionResult Index()
        {


            var userid = User.Identity.GetUserId();

            var Artist = _context.Relationships.Where(f => f.FollowerId == userid)
                .Select(f => f.Followee)
                .ToList();


            return View(Artist);
        }
    }
}