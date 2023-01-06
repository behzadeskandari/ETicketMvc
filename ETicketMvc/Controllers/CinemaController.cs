using ETicketMvc.Data;
using ETicketMvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ETicketMvc.Controllers
{
    public class CinemaController : Controller
    {

        private readonly AppDbContext _context;

        public CinemaController(AppDbContext context)
        {
            _context = context;
        }


        public async  Task<IActionResult> Index()
        {
            List<Cinema> data = await _context.Cinema.ToListAsync();

            return View(data);
        }
    }
}
