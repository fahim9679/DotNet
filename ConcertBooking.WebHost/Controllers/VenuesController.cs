using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;
using ConcertBooking.Repositories;
using ConcertBooking.Repositories.Interfaces;
using ConcertBooking.WebHost.ViewModels.VenueViewModels;
using ConcertBooking.Entities;

namespace ConcertBooking.WebHost.Controllers
{
    public class VenuesController : Controller
    {
        private readonly IVenueRepo _venueRepo;

        public VenuesController(IVenueRepo venueRepo)
        {
            _venueRepo = venueRepo;
        }

        public async Task<IActionResult> Index()
        {
            
                List<VenueViewModel> vm = new List<VenueViewModel>();
                var venues = await _venueRepo.GetAll();
                foreach (var venue in venues)
                {
                    vm.Add(new VenueViewModel { Id = venue.Id, Name = venue.Name, Address=venue.Address,SeatCapacity=venue.SeatCapacity });
                }
                return View(vm);
           
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateVenueViewModel vm)
        {
            var vanue = new Venue
            {
                Name = vm.Name
                , Address = vm.Address
                , SeatCapacity = vm.SeatCapacity
            };
            await _venueRepo.Save(vanue);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var vanue = await _venueRepo.GetById(id);
            VenueViewModel vm = new VenueViewModel
            {
                Id = vanue.Id,
                Name = vanue.Name
                , Address = vanue.Address
                ,SeatCapacity = vanue.SeatCapacity
            };
            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(VenueViewModel vm)
        {
            var venue = new Venue { Id = vm.Id, Name = vm.Name, Address=vm.Address,SeatCapacity=vm.SeatCapacity };
            await _venueRepo.Edit(venue);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var venue = await _venueRepo.GetById(id);
            await _venueRepo.RemoveData(venue);
            return RedirectToAction("Index");
        }
    }
}
