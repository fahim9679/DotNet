using DotNet.Entities;
using DotNet.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DotNet.UI.Controllers
{
    public class StatesController : Controller
    {
        private readonly IStateRepo _stateRepo;
        private readonly ICountryRepo _countryRepo;

        public StatesController(IStateRepo stateRepo, ICountryRepo countryRepo)
        {
            _stateRepo = stateRepo;
            _countryRepo = countryRepo;
        }

        public IActionResult Index()
        {
            var states=_stateRepo.GetAll();
            return View(states);
        }
        [HttpGet]
        public IActionResult Create()
        {
            var countries= _countryRepo.GetAll();
            ViewBag.CountryList = new SelectList(countries, "Id", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult Create(State state)
        {
            _stateRepo.Save(state);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var state=_stateRepo.GetById(id);
            var countries = _countryRepo.GetAll();
            ViewBag.CountryList = new SelectList(countries, "Id", "Name");
            return View(state);
        }
        [HttpPost]
        public IActionResult Edit(State state)
        {
            _stateRepo.Edit(state);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var state = _stateRepo.GetById(id);
            _stateRepo.RemoveData(state);
            return RedirectToAction("Index");
        }
    }
}
