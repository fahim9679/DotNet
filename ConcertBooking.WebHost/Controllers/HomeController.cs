using ConcertBooking.Repositories.Interfaces;
using ConcertBooking.WebHost.Models;
using ConcertBooking.WebHost.ViewModels.HomeConcertViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ConcertBooking.WebHost.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConcertRepo _concertRepo;
        public HomeController(ILogger<HomeController> logger, IConcertRepo concertRepo)
        {
            _logger = logger;
            _concertRepo = concertRepo;
        }

        public async Task<IActionResult> Index()
        {
            DateTime today= DateTime.Today;
            var concert = await _concertRepo.GetAll();
            var vm = concert.Where(x=>x.DateTime.Date>=today).Select(x => new HomeConcertViewModel
            {
                ConcertId=x.Id,
                ConcertName=x.Name,
                ConcertImage=x.ImageUrl,
                ArtistName=x.Artist.Name,
                Description=x.Description.Length>100?x.Description.Substring(0,100):x.Description,
            }).ToList();
            return View(vm);
        }

        public async Task<IActionResult> Details(int id)
        {
            var concert=await _concertRepo.GetById(id);
            if (concert == null)
            {
                return NotFound();
            }
            var vm = new HomeConcertDetailsViewModel
            {
                ConcertId = concert.Id,
                ConcertName=concert.Name,
                Description=concert.Description,
                ConcertDateTime=concert.DateTime,
                ArtistName =concert.Artist.Name,
                ArtistImage=concert.Artist.ImageUrl,
                VenueName=concert.Venue.Name,
                VenueAddress=concert.Venue.Address,
                ConcertImage=concert.ImageUrl
            };
            return View(vm);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
