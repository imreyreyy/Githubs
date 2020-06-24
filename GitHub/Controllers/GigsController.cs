using GitHub.Models;
using GitHub.ViewModel;
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
    }
}