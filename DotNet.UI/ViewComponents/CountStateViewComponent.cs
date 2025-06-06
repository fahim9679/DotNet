﻿using DotNet.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet.UI.ViewComponents
{
    public class CountStateViewComponent : ViewComponent
    {
        private readonly IStateRepo _stateRepo;

        public CountStateViewComponent(IStateRepo stateRepo)
        {
            _stateRepo = stateRepo;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var states = await _stateRepo.GetAll();
            int TotalStates=states.Count();
            return View(TotalStates);
        }
    }
}
