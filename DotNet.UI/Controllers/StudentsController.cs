using DotNet.Entities;
using DotNet.Repositories.Implementations;
using DotNet.Repositories.Interfaces;
using DotNet.UI.ViewModels.StudentViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Threading.Tasks;

namespace DotNet.UI.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IStudentRepo _studentRepo;
        private readonly ISkillRepo _skillRepo;

        public StudentsController(IStudentRepo studentRepo, ISkillRepo skillRepo)
        {
            _studentRepo = studentRepo;
            _skillRepo = skillRepo;
        }

        public async Task<IActionResult> Index()
        {
            var students=await _studentRepo.GetAll();
            List<StudentViewModel> vm = new List<StudentViewModel>();
            foreach (var student in students)
            {
                vm.Add(new StudentViewModel { Id = student.Id, Name = student.Name });
            }
            return View(vm);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            CreateStudentViewModel vm = new CreateStudentViewModel();
            var skills = await _skillRepo.GetAll();
            foreach (var skill in skills)
            {
                vm.SkillList.Add(new CheckBoxTable { SkillId = skill.Id, SkillName = skill.Title, IsChecked = false });
            }
            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateStudentViewModel vm)
        {
            var student = new Student
            {
                Name=vm.StudentName,
            };
            var selectedSkillIds=vm.SkillList.Where(x=>x.IsChecked==true)
                .Select(y=>y.SkillId).ToList();
            foreach (var SkillId in selectedSkillIds)
            {
                student.StudentSkills.Add(new StudentSkill
                {
                    SkillId= SkillId
                });
            }
            await _studentRepo.Save(student);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var student = await _studentRepo.GetById(id);
            EditStudentViewModel vm = new EditStudentViewModel
            {
                Id = student.Id,
                StudentName = student.Name,               
            };
            
            var existingSkillId=student.StudentSkills.Select(x=>x.SkillId).ToList();
            var skills = await _skillRepo.GetAll();
            foreach (var skill in skills)
            {
                vm.SkillList.Add(new CheckBoxTable 
                { 
                    SkillId = skill.Id, 
                    SkillName = skill.Title, 
                    IsChecked = existingSkillId.Contains(skill.Id) });
            }
            return View(vm);
        }
    }
}
