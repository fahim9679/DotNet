using CleanStudentManagment.BLL.Services;
using CleanStudentManagment.Models;
using Microsoft.AspNetCore.Mvc;

namespace CleanStudentManagment.UI.Controllers
{
    public class GroupsController : Controller
    {
        private readonly IGroupService _groupService;
        private readonly IStudentService _studentService;

        public GroupsController(IGroupService groupService, IStudentService studentService)
        {
            _groupService = groupService;
            _studentService = studentService;
        }

        public IActionResult Index(int pageNumber = 1, int pageSize = 10)
        {
            return View(_groupService.GetAll(pageNumber, pageSize));
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(GroupViewModel groupViewModel)
        {

            if (ModelState.IsValid)
            {
                var vm = _groupService.AddGroup(groupViewModel);
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            GroupStudentViewModel vm = new GroupStudentViewModel();
            var group = _groupService.GetGroup(id);
            var students = _studentService.GetAllStudents();
            vm.GroupId = group.Id;
            foreach (var student in students)
            {
                vm.StudentList.Add(new CheckBoxTable { 
                    Id= student.Id,
                    Name= student.Name,
                    IsChecked=false
                });
            }
            return View(vm);  
        }
    }
}
