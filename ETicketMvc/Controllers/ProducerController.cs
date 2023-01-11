using ETicketMvc.Data;
using ETicketMvc.Data.Services;
using ETicketMvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETicketMvc.Controllers
{
    public class ProducerController : Controller
    {
        //private readonly AppDbContext _context;

        private readonly IProducersService _producersService;
        public ProducerController(IProducersService producersService)
        {
            _producersService = producersService;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Producer> data = await _producersService.GetAllAsync();

            return View(data);
        }

        public async Task<IActionResult> Details(int id)
        {
            var producerDetails = await _producersService.GetByIdAsync(id);
            if (producerDetails == null) return View("NotFound");
            return View(producerDetails);
        }


        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create([Bind("ProfilePictureURL,FullName,Bio")]Producer producer)
        {
            if (!ModelState.IsValid)
            {
                return View(producer);
            }
            await _producersService.AddAsync(producer);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var produceDetails = await _producersService.GetByIdAsync(id);
            if (produceDetails == null) return View("NotFound");
            
            return View(produceDetails);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(int id,[Bind("Id,ProfilePictureURL,FullName,Bio")] Producer producer)
        {
            if (!ModelState.IsValid) return View(producer);

            if (id == producer.Id)
            {
               await _producersService.UpdateAsync(id,producer);
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var produceDetails = await _producersService.GetByIdAsync(id);
            if (produceDetails == null) return View("NotFound");

            return View(produceDetails);
        }


        [HttpPost,ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var produceDetails = await _producersService.GetByIdAsync(id);
            if (produceDetails == null) return View("NotFound");

            await _producersService.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }

        

    }
}
