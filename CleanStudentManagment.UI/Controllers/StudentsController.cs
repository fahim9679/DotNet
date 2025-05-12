using CleanStudentManagment.BLL.Services;
using CleanStudentManagment.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CleanStudentManagment.UI.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IStudentService _studentService;

        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateStudentViewModel vm)
        {
           var success= await _studentService.AddStudentAsync(vm);
            if(success>0)
            {
                return RedirectToAction("Index");
            }
            return View(vm);
        }
    }
}
