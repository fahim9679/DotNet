using Microsoft.AspNetCore.Mvc;

namespace DotNet.UI.Controllers
{
    public class StatesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
