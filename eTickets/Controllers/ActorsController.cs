﻿using eTickets.Data;
using eTickets.Data.Services;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Controllers
{
    public class ActorsController : Controller
    {
        private readonly IActorsService _service;
        public ActorsController(IActorsService service)
        {
            _service = service;

        }
        public async Task<IActionResult> Index()
        {
            var AllActors = await _service.GetAllActors();

            return View(AllActors);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName","ProfilePictureURL","Bio")] Actor actor) {
            if(!ModelState.IsValid)
            {
                return View(actor);
            }
            _service.AddActor(actor);
            return RedirectToAction(nameof( Index));
        }
    }
}
