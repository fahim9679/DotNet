using Microsoft.AspNetCore.Mvc;

namespace DotNet.UI.Controllers
{
    public class CountriesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
