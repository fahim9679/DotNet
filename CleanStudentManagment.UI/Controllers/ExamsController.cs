﻿using CleanStudentManagment.BLL.Services;
using CleanStudentManagment.Models;
using CleanStudentManagment.UI.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CleanStudentManagment.UI.Controllers
{
    [RoleAuthorize(2)]
    public class ExamsController : Controller
    {
        private readonly IGroupService _groupService;
        private readonly IExamService _examService;

        public ExamsController(IGroupService groupService, IExamService examService)
        {
            _groupService = groupService;
            _examService = examService;
        }

        public IActionResult Index(int pageNumber=1,int pageSize=10)
        {
           return View(_examService.GetAll(pageNumber,pageSize));
           
        }
        [HttpGet]
        public IActionResult Create()
        {
            var groups = _groupService.GetAllGroups();
            ViewBag.AllGroups = new SelectList(groups,"Id","Name");

            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateExamVeiwModel veiwModel)
        {
            _examService.AddExam(veiwModel);
            return RedirectToAction("Index");
        }
    }
}
