using DotNet.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet.UI.ViewComponents
{
    public class CountCountryViewComponent:ViewComponent
    {
        private readonly ICountryRepo _countryRepo;

        public CountCountryViewComponent(ICountryRepo countryRepo)
        {
            _countryRepo = countryRepo;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var countries = await _countryRepo.GetAll();
            int Totalcountries = countries.Count();
            return View(Totalcountries);
        }
    }
}
