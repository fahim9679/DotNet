using CleanStudentManagment.BLL.Services;
using CleanStudentManagment.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace CleanStudentManagment.UI.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly IExamService _examService;
        private readonly IQnAsService _qnAsService;

        public StudentsController(IStudentService studentService, IExamService examService, IQnAsService qnAsService)
        {
            _studentService = studentService;
            _examService = examService;
            _qnAsService = qnAsService;
        }

        public IActionResult Index(int pageNumber = 1, int pageSize = 10)
        {
            return View(_studentService.GetAllStudents(pageNumber,pageSize));
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateStudentViewModel vm)
        {
            var success = await _studentService.AddStudentAsync(vm);
            if (success > 0)
            {
                return RedirectToAction("Index");
            }
            return View(vm);
        }
        [HttpGet]
        public IActionResult AttendExam()
        {
            var model = new AttendExamViewModel();
            string loginObj = HttpContext.Session.GetString("LoginDetails");
            LoginViewModel sessionObj = JsonConvert.DeserializeObject<LoginViewModel>(loginObj);
            if (sessionObj != null)
            {
                model.StudentId = sessionObj.Id;
                var todayExam = _examService.GetAllExams().Where(x => x.StartDate.Date == DateTime.Today.Date).FirstOrDefault();
                if (todayExam == null)
                {
                    model.Message = "No exam schedule today";
                    return View(model);
                }
                else
                {
                    if (!_qnAsService.IsAttended(todayExam.Id, model.StudentId))
                    {
                        model.QnAsList = _qnAsService.GetAllQnAsByExamId(todayExam.Id).ToList();
                        model.ExamName = todayExam.Title;
                        return View(model);
                    }
                    else
                    {
                        model.Message = "You have already attended the exam";
                        return View(model);
                    }
                }
            }
            return RedirectToAction("Login", "Accounts");
        }
        [HttpPost]
        public IActionResult AttendExam( AttendExamViewModel viewModel)
        { 
            bool result=_studentService.SetExamResult(viewModel);
            return View(); 
        }
        [HttpGet]
        public IActionResult Result(int Id)
        {
            var result = _studentService.GetStudentResult(Id);
            if (result != null)
            {
                return View(result);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}
