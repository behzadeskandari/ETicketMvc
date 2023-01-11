using ETicketMvc.Data;
using ETicketMvc.Data.Services;
using ETicketMvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ETicketMvc.Controllers
{
    public class CinemaController : Controller
    {

        private readonly ICinemaService _service;

        public CinemaController(ICinemaService service)
        {
            _service = service;
        }


        public async  Task<IActionResult> Index()
        {
            IEnumerable<Cinema> data = await _service.GetAllAsync();

            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Logo,Name,Description")]Cinema cinema)
        {
            if (!ModelState.IsValid)
            {
                return View(cinema);
            }
            await _service.AddAsync(cinema);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var CinemaDetails = await _service.GetByIdAsync(id);
            if (CinemaDetails == null) return View("NotFound");
            return View(CinemaDetails);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var CinemaDetails = await _service.GetByIdAsync(id);
            if (CinemaDetails == null) return View("NotFound");

            return View(CinemaDetails);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Logo,Name,Description")]Cinema cinema)
        {
            if (!ModelState.IsValid) return View(cinema);

            if (id == cinema.Id)
            {
                await _service.UpdateAsync(id, cinema);
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var produceDetails = await _service.GetByIdAsync(id);
            if (produceDetails == null) return View("NotFound");

            return View(produceDetails);
        }


        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var produceDetails = await _service.GetByIdAsync(id);
            if (produceDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }

    }
}
