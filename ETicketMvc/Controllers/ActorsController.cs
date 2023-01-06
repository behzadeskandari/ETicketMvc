using ETicketMvc.Data;
using ETicketMvc.Data.Services;
using ETicketMvc.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETicketMvc.Controllers
{
    public class ActorsController : Controller
    {
        private readonly IActorService _Actorservice;

        public ActorsController(IActorService actorservice)
        {
            _Actorservice = actorservice;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _Actorservice.GetAllAsync();

            if (data !=null)
            {
                return View(data);
            }
            else
            {
                return RedirectToAction("NotFound");
            }

        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName,ProfilePritureURL,Bio")]Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }

            await _Actorservice.AddAsync(actor);

            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Details(int id)
        {
            var actorDetails = await _Actorservice.GetByIdAsync(id);

            if (actorDetails == null) return View("NotFound");
            return View(actorDetails);
        }


        public async  Task<IActionResult> Edit(int id)
        {
            var actorDetails = await _Actorservice.GetByIdAsync(id);

            if (actorDetails == null) return View("NotFound");

            return View(actorDetails);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id,[Bind("Id,FullName,ProfilePritureURL,Bio")] Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }

            await _Actorservice.UpdateAsync(id,actor);

            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Delete(int id)
        {
            var actorDetails = await _Actorservice.GetByIdAsync(id);

            if (actorDetails == null) return View("NotFound");

            return View(actorDetails);
        }
        [HttpPost,ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var actorDetails = await _Actorservice.GetByIdAsync(id);

            if (actorDetails == null) return View("NotFound");

            
            await _Actorservice.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
