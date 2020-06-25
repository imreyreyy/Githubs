using GitHub.Models;
using GitHub.ViewModel;
using Microsoft.AspNet.Identity;
using System;
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
           
            var genre = _context.Genre.Single(g => g.Id == viewModel.Genre);
            var gigs = new Gigs
            {
                ArtistId = User.Identity.GetUserId(),
                DateTime =DateTime.Parse(string.Format("{0} {1}", viewModel.Date,viewModel.Time)),
                GenreId=viewModel.Genre,
                Venue=viewModel.Venue

            };
            _context.Gigs.Add(gigs);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}