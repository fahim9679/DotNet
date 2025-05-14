using Microsoft.AspNetCore.Mvc;

namespace CleanStudentManagment.UI.Controllers
{
    public class ExamsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
