using Microsoft.AspNetCore.Mvc;

namespace CleanStudentManagment.UI.Controllers
{
    public class StudentsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
