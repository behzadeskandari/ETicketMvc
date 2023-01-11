using ETicketMvc.Data;
using ETicketMvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using ETicketMvc.Data.Services;

namespace ETicketMvc.Controllers
{
    public class MoviesController : Controller
    {

        private readonly IMovieService _service;

        public MoviesController(IMovieService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync(n => n.Cinema);

            return View(data);
        }


        public async Task<IActionResult> Details(int id)
        {
            var movieDetail = await _service.GetMoiveByIdAsync(id);

            return View(movieDetail);
        }
    }

}
