using GitHub.Models;
using GitHub.ViewModel;
using Microsoft.AspNet.Identity;
using System;
using System.Data.Entity;
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


        public ActionResult Mine()
        {

            var userId = User.Identity.GetUserId();

            var mine = _context.Gigs
                .Where(m => m.ArtistId == userId && m.DateTime > DateTime.Now)
                .Include(g => g.Genre)
                .ToList();

            return View(mine);


        }

        [Authorize]
        public ActionResult Attending()
        {

            var userId = User.Identity.GetUserId();
            var gigs = _context.Attendance
                .Where(a => a.AttendeeId == userId)
                .Select(a => a.Gig)
                .Include(a => a.Artist)
                .Include(a => a.Genre)
                .ToList();
            var viewModel = new GigsViewModel()
            {
                UpComingGig = gigs,
                ShowActions = User.Identity.IsAuthenticated,
                Heading="Gigs I'm Attending"


            };

            return View("Gigs", viewModel);

        }

        #region Create
        // GET: Gigs
        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new GigsFormViewModel
            {
                Genres = _context.Genre.ToList(),
                Heading = "Add a Gig"
            };
            return View("GigForm", viewModel);
        }


        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GigsFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                //Genres need to populate first
                viewModel.Genres = _context.Genre.ToList();
                return View("GigForm", "Gigs");
            }


            var gigs = new Gigs
            {
                ArtistId = User.Identity.GetUserId(),
                DateTime = viewModel.GetDateTime(),
                GenreId = viewModel.Genre,
                Venue = viewModel.Venue

            };
            _context.Gigs.Add(gigs);
            _context.SaveChanges();
            return RedirectToAction("Mine", "Home");
        }


        #endregion


        #region Edit



        [Authorize]
        public ActionResult Edit(int id)
        {

            var userId = User.Identity.GetUserId();
            var gig = _context.Gigs.Single(g => g.Id == id && g.ArtistId == userId);

            var viewModel = new GigsFormViewModel
            {
                Heading = "Edit a Gig",
                Id = gig.Id,
                Genres = _context.Genre.ToList(),
                Date = gig.DateTime.ToString("dd MMM yyyy "),
                Time = gig.DateTime.ToString("HH:mm"),
                Venue = gig.Venue,
                Genre = gig.GenreId,
            };
            return View("GigForm", viewModel);
        }




        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Update(GigsFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                //Genres need to populate first
                viewModel.Genres = _context.Genre.ToList();
                return View("GigForm", viewModel);
            }

            var userId = User.Identity.GetUserId();
            var gigs = _context.Gigs.Single(g => g.Id == viewModel.Id && g.ArtistId == userId);
            gigs.Venue = viewModel.Venue;
            gigs.DateTime = viewModel.GetDateTime();
            gigs.GenreId = viewModel.Genre;

            _context.SaveChanges();


            return RedirectToAction("Mine", "Gigs");
        }


        #endregion




    }
}