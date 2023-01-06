using ETicketMvc.Data;
using ETicketMvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace ETicketMvc.Controllers
{
    public class MoviesController : Controller
    {

        private readonly AppDbContext _context;

        public MoviesController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            List<Movie> data = await _context.Movie.Include(n => n.Cinema).OrderBy(n => n.Name).ToListAsync();

            return View(data);
        }
    }
}
