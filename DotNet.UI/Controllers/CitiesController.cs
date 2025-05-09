﻿using DotNet.Entities;
using DotNet.Repositories.Interfaces;
using DotNet.UI.ViewModels.CityViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NuGet.Configuration;
using NuGet.Repositories;
using System.Threading.Tasks;

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

        public async Task<IActionResult> Index()
        {
            var cities = await _cityRepo.GetAll();
            var vm = new List<CityViewModel>();
            foreach (var city in cities)
            {
                vm.Add(new CityViewModel
                {
                    Id = city.Id,
                    CityName = city.Name,
                    StateName = city.State.Name,
                    CountryName=city.State.Country.Name,
                });
            }
            return View(vm);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var states = await _stateRepo.GetAll();
            ViewBag.stateList = new SelectList(states, "Id", "Name");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateCityViewModel vm)
        {
            var city = new City
            {
                Name=vm.CityName,
                StateId=vm.StateId
            };
            await _cityRepo.Save(city);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var city=await _cityRepo.GetById(id);
            var states = await _stateRepo.GetAll();
            ViewBag.stateList = new SelectList(states, "Id", "Name");
            var vm = new EditCityViewModel
            {
                Id = city.Id,
                CityName = city.Name,
                StateId = city.StateId,
            };
            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(EditCityViewModel vm)
        {
            var city = new City
            {
                Id=vm.Id,
                Name = vm.CityName,
                StateId=vm.StateId,
            };
            await _cityRepo.Edit(city);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var city = await _cityRepo.GetById(id);
            await _cityRepo.RemoveData(city);
            return RedirectToAction("Index");
        }
    }
}
