using CleanStudentManagment.BLL.Services;
using CleanStudentManagment.Models;
using CleanStudentManagment.UI.Filters;
using Microsoft.AspNetCore.Mvc;

namespace CleanStudentManagment.UI.Controllers
{
    [RoleAuthorize(1)]
    public class UsersController : Controller
    {
        private readonly IAccountService _accountService;

        public UsersController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public IActionResult Index(int pageNumber=1, int pageSize=10)
        {
            return View(_accountService.GetAllTeacher(pageNumber,pageSize));
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(UserViewModel vm)
        {
            bool success = _accountService.AddTeacher(vm);
            if (success)
            {
                return RedirectToAction("Index");
            }
            return View(vm);
        }
    }
}
