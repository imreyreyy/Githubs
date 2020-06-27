using GitHub.Models;
using GitHub.ViewModel;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Mvc;

namespace GitHub.Controllers
{
    public class GigsController : Controller
    {

        private ApplicationDbContext _context;

        public GigsController()
        {
            _context = new ApplicationDbContext();
        }

        
        // GET: Gigs
        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new GigsFormViewModel
            {
                Genres = _context.Genre.ToList()
            };
            return View(viewModel);
        }
        [HttpPost]
        [Authorize]
        public ActionResult Create(GigsFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                //Genres need to populate first
                viewModel.Genres = _context.Genre.ToList();
                return View("Create", viewModel);
            }


            var gigs = new Gigs
            {
                ArtistId = User.Identity.GetUserId(),
                DateTime =viewModel.GetDateTime(),
                GenreId=viewModel.Genre,
                Venue=viewModel.Venue

            };
            _context.Gigs.Add(gigs);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }


    }
}