using DotNet.Entities;
using DotNet.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DotNet.UI.Controllers
{
    public class CitiesController : Controller
    {
        private readonly ICityRepo _cityRepo;
        private readonly IStateRepo _stateRepo;

        public CitiesController(ICityRepo cityRepo, IStateRepo stateRepo)
        {
            _cityRepo = cityRepo;
            _stateRepo = stateRepo;
        }

        public IActionResult Index()
        {
            var cities = _cityRepo.GetAll();
            return View(cities);
        }
        [HttpGet]
        public IActionResult Create()
        {
            var states = _stateRepo.GetAll();
            ViewBag.stateList = new SelectList(states, "Id", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult Create(City city)
        {
            
            _cityRepo.Save(city);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var city=_cityRepo.GetById(id);
            var states = _stateRepo.GetAll();
            ViewBag.stateList = new SelectList(states, "Id", "Name");
            return View(city);
        }
        [HttpPost]
        public IActionResult Edit(City city)
        {
            _cityRepo.Edit(city);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var city = _cityRepo.GetById(id);
            _cityRepo.RemoveData(city);
            return RedirectToAction("Index");
        }
    }
}
