using ETicketMvc.Data;
using ETicketMvc.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ETicketMvc.Controllers
{
    public class ActorsController : Controller
    {
        private readonly AppDbContext _context;

        public ActorsController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Actor> data = _context.Actors.ToList();

            if (data !=null)
            {
                return View(data);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

        }
    }
}
