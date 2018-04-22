using System.Linq;
using System.Web.Mvc;
using GigHub.IdentityModels.DomainModels;
using GigHub.IdentityModels.IdentityProviders;
using GigHub.ViewModels;
using Microsoft.AspNet.Identity;

namespace GigHub.Controllers
{
    public class GigsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GigsController()
        {
            _context = new ApplicationDbContext();
        }
        // GET
        [Authorize]
        [HttpGet]
        public ActionResult Create()
        {
            var genres = _context.Genres.ToList();

            var viewModel = new GigFormViewModel
            {
                Genres = genres
            };

            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(GigFormViewModel viewModel)
        {
            var gig = new Gig
            {
                ArtistId = User.Identity.GetUserId(),
                DateTime = viewModel.DateTime,
                GenreId = viewModel.Genre,
                Venue = viewModel.Venue
            };

            _context.Gigs.Add(gig);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}