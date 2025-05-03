using DotNet.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet.UI.ViewComponents
{
    public class CountCityViewComponent : ViewComponent
    {
        private readonly ICityRepo _cityRepo;

        public CountCityViewComponent(ICityRepo cityRepo)
        {
            _cityRepo = cityRepo;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var cities=await _cityRepo.GetAll();
            int TotalCities=cities.Count();
            return View(TotalCities);
        }
    }
}
