using Microsoft.AspNetCore.Mvc;

namespace ConcertBooking.WebHost.Controllers
{
    public class ConcertsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
