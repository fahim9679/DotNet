using DotNet.Entities;
using DotNet.Repositories.Interfaces;
using DotNet.UI.ViewModels.SkillViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DotNet.UI.Controllers
{
    public class SkillsController : Controller
    {
        private readonly ISkillRepo _skillRepo;

        public SkillsController(ISkillRepo skillRepo)
        {
            _skillRepo = skillRepo;
        }

        public async Task<IActionResult> Index(int pageNumber=1,int pageSize=3)
        {
            List<SkillViewModel> vm = new List<SkillViewModel>();
            var skills = await _skillRepo.GetAll();
            int totalItems=skills.Count();
            skills = skills.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            foreach (var skill in skills)
            {
                vm.Add(new SkillViewModel { Id = skill.Id, Title = skill.Title });
            }
            
            var pvm = new PagedSkillViewModel
            {
                Skills = vm,
                PageInfo =new Utility.PageInfo
                {
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    TotalItems = totalItems
                }
            };
            return View(pvm);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateSkillViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var skill = new Skill
                {
                    Title = vm.Title
                };
                await _skillRepo.Save(skill);
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var skill = await _skillRepo.GetById(id);
            SkillViewModel vm = new SkillViewModel
            {
                Id = skill.Id,
                Title = skill.Title
            };
            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(SkillViewModel vm)
        {
            var skill = new Skill { Id = vm.Id, Title = vm.Title };
            await _skillRepo.Edit(skill);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var skill = await _skillRepo.GetById(id);
            await _skillRepo.RemoveData(skill);
            return RedirectToAction("Index");
        }
    }
}
