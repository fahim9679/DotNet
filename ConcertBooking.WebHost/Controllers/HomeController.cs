using ConcertBooking.Entities;
using ConcertBooking.Repositories.Interfaces;
using ConcertBooking.WebHost.Models;
using ConcertBooking.WebHost.ViewModels.HomeConcertViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ConcertBooking.WebHost.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConcertRepo _concertRepo;
        private readonly ITicketRepo _ticketRepo;
        private readonly IBookingRepo _bookingRepo;
        public HomeController(ILogger<HomeController> logger, IConcertRepo concertRepo, ITicketRepo ticketRepo, IBookingRepo bookingRepo)
        {
            _logger = logger;
            _concertRepo = concertRepo;
            _ticketRepo = ticketRepo;
            _bookingRepo = bookingRepo;
        }

        public async Task<IActionResult> Index()
        {
            DateTime today = DateTime.Today;
            var concert = await _concertRepo.GetAll();
            var vm = concert.Where(x => x.DateTime.Date >= today).Select(x => new HomeConcertViewModel
            {
                ConcertId = x.Id,
                ConcertName = x.Name,
                ConcertImage = x.ImageUrl,
                ArtistName = x.Artist.Name,
                Description = x.Description.Length > 100 ? x.Description.Substring(0, 100) : x.Description,
            }).ToList();
            return View(vm);
        }

        public async Task<IActionResult> Details(int id)
        {
            var concert = await _concertRepo.GetById(id);
            if (concert == null)
            {
                return NotFound();
            }
            var vm = new HomeConcertDetailsViewModel
            {
                ConcertId = concert.Id,
                ConcertName = concert.Name,
                Description = concert.Description,
                ConcertDateTime = concert.DateTime,
                ArtistName = concert.Artist.Name,
                ArtistImage = concert.Artist.ImageUrl,
                VenueName = concert.Venue.Name,
                VenueAddress = concert.Venue.Address,
                ConcertImage = concert.ImageUrl
            };
            return View(vm);
        }

        public async Task<IActionResult> AvailableTikets(int id)
        {
            var concert = await _concertRepo.GetById(id);
            if (concert == null)
            {
                return NotFound();
            }
            var allSeats = Enumerable.Range(1, concert.Venue.SeatCapacity).ToList();
            var BookedTicket = await _ticketRepo.GetBookedTickets(concert.Id);
            var availableSeats = allSeats.Except(BookedTicket).ToList();
            var vm = new AvailableTicketViewModel
            {
                ConcertId = concert.Id,
                ConcertName = concert.Name,
                AvailableSeats = availableSeats,
            };
            return View(vm);

        }
        [Authorize]
        public async Task<IActionResult> BookTickets(int ConcertId, List<int> selectedSeats)
        {
            if (selectedSeats == null && selectedSeats.Count == 0)
            {
                ModelState.AddModelError("", "No Seat Selected");
                return RedirectToAction("AvailableTikets", new { id = ConcertId });
            }
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            var userId = claim.Value;
            var newBooking = new Booking
            {
                ConcertId = ConcertId,
                DateTime = DateTime.Now,
                UserId = userId,
            };
            foreach (var seatNumber in selectedSeats)
            {
                newBooking.Tickets.Add(new Ticket
                {
                    SeatNumber = seatNumber,
                    IsBooked = true,

                });
            }
            await _bookingRepo.AddBooking(newBooking);

            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
