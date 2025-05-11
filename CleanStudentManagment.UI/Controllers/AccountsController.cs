using Microsoft.AspNetCore.Mvc;

namespace CleanStudentManagment.UI.Controllers
{
    public class AccountsController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}
