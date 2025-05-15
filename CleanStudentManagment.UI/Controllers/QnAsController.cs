using CleanStudentManagment.BLL.Services;
using CleanStudentManagment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CleanStudentManagment.UI.Controllers
{
    public class QnAsController : Controller
    {
        private readonly IExamService _examService;
        private readonly IQnAsService _qnAsService;

        public QnAsController(IExamService examService, IQnAsService qnAsService)
        {
            _examService = examService;
            _qnAsService = qnAsService;
        }

        public IActionResult Index(int pageNumber = 1, int pageSize = 10)
        {
            var QnAs= _qnAsService.GetAllQnAs(pageNumber,pageSize);
            return View(QnAs);
        }
        [HttpGet]
        public IActionResult Create()
        {
            var exams = _examService.GetAllExams();
            ViewBag.examList=new SelectList(exams, "Id", "Title");
            return View();
        }
        [HttpGet]
        public IActionResult Create(CreateQnAsViewModel vm)
        {
            _qnAsService.AddQnAs(vm);
            return RedirectToAction("Index");
            
        }
    }
}
