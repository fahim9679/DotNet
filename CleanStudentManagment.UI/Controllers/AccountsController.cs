using CleanStudentManagment.BLL.Services;
using CleanStudentManagment.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

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
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            LoginViewModel vm = _accountService.Login(model);
            if (vm != null)
            {
                string sessionObject = JsonSerializer.Serialize(vm);
                HttpContext.Session.SetString("LoginDetails", sessionObject);
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, vm.UserName),
                    new Claim(ClaimTypes.Role, vm.Role.ToString())
                };
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
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

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
        public IActionResult AccessDenied()
        {
            return View();
        }


    }
}
