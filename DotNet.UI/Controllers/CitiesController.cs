using Microsoft.AspNetCore.Mvc;

namespace DotNet.UI.Controllers
{
    public class CitiesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
