using CleanStudentManagment.BLL.Services;
using CleanStudentManagment.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CleanStudentManagment.UI.Controllers
{
    public class AccountsController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountsController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            LoginViewModel vm = _accountService.Login(model);
            if (vm != null)
            {
                string sessionObject = JsonSerializer.Serialize(vm);
                HttpContext.Session.SetString("LoginDetails", sessionObject);
                return RedirectToLogin(vm);
            }
            return View(model);
        }

        private IActionResult RedirectToLogin(LoginViewModel vm)
        {
            switch (vm.Role)
            {
                case (int)EnumRoles.Admin:
                    return RedirectToAction("Index", "Users");
                    break;
                case (int)EnumRoles.Teacher:
                    return RedirectToAction("Index", "Exams");
                    break;                
                default:
                    return RedirectToAction("Index", "Students");
            }
        }
    }
}
