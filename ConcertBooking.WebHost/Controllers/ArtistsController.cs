using Microsoft.AspNetCore.Mvc;

namespace ConcertBooking.WebHost.Controllers
{
    public class ArtistsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
