using DotNet.Entities;
using DotNet.Repositories.Interfaces;
using DotNet.UI.ViewModels.UserInfoViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DotNet.UI.Controllers
{
    public class AuthController : Controller
    {
        private readonly IUserRepo _userRepo;

        public AuthController(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(UserInfoViewModel vm)
        {
            var model = new UserInfo
            {
                UserName = vm.UserName,
                Password  = vm.Password,
            };
            await _userRepo.RegisterUser(model);
            return RedirectToAction("LogIn");
        }
        [HttpGet]
        public IActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> LogIn(UserInfoViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var userInfo = await _userRepo.GetUserInfo(vm.UserName, vm.Password);
                if (userInfo != null)
                {
                    HttpContext.Session.SetInt32("userId", userInfo.UserId);
                    HttpContext.Session.SetString("userName", userInfo.UserName);
                    return RedirectToAction("Index", "Countries");
                }
            }
            return View();
        }
        [HttpGet]
        public IActionResult logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("LogIn");
        }
    }
}
