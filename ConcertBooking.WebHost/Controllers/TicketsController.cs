using ConcertBooking.Repositories.Interfaces;
using ConcertBooking.WebHost.ViewModels.TicketViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ConcertBooking.WebHost.Controllers
{
    public class TicketsController : Controller
    {
        private readonly ITicketRepo _ticketRepo;

        public TicketsController(ITicketRepo ticketRepo)
        {
            _ticketRepo = ticketRepo;
        }
        [Authorize]
        public async Task<IActionResult> MyTickets()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            var userId = claim.Value;
            var Bookings = await _ticketRepo.GetBookings(userId);
            List<BookingViewModel> vm = new List<BookingViewModel>();
            foreach (var booking in Bookings)
            {
                vm.Add(new BookingViewModel
                {
                    BookingId = booking.BookingId,
                    BookingDate = booking.DateTime,
                    ConcertName = booking.Concert.Name,
                    Tickets = booking.Tickets.Select(ticketVm => new TicketViewModel
                    {
                        SeatNumber = ticketVm.SeatNumber
                    }).ToList()
                });
            }
            return View(vm);
        }
    }
}
