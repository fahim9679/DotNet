﻿using DotNet.Entities;
using DotNet.Repositories.Interfaces;
using DotNet.UI.ViewModels.CountryViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DotNet.UI.Controllers
{
    public class CountriesController : Controller
    {
        private readonly ICountryRepo _countryRepo;

        public CountriesController(ICountryRepo countryRepo)
        {
            _countryRepo = countryRepo;
        }

        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetInt32("userId") != null)
            {
                List<CountryViewModel> vm = new List<CountryViewModel>();
                var countries = await _countryRepo.GetAll();
                foreach (var country in countries)
                {
                    vm.Add(new CountryViewModel { Id = country.Id, Name = country.Name });
                }
                return View(vm);
            }
            return RedirectToAction("LogIn","Auth");
        }
        [HttpGet]
        public IActionResult Create() 
        { 
            CreateCountryViewModel cvm = new  CreateCountryViewModel();
            return View(cvm);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateCountryViewModel vm)
        {
            var country=new Country { 
                Name = vm.Name
            };
           await  _countryRepo.Save(country);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var country=await _countryRepo.GetById(id);
            CountryViewModel vm = new CountryViewModel { 
                Id = country.Id,
                Name = country.Name
            };
            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(CountryViewModel vm)
        {
            var country=new Country{Id=vm.Id, Name = vm.Name};
            await _countryRepo.Edit(country);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var country = await _countryRepo.GetById(id);
            await _countryRepo.RemoveData(country);
            return RedirectToAction("Index");
        }
    }
}
