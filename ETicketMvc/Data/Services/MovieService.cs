using ETicketMvc.Data.Base;
using ETicketMvc.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ETicketMvc.Data.Services
{
    public class MovieService : EntityBaseRepository<Movie>, IMovieService
    {
        private readonly AppDbContext _context;
        public MovieService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Movie> GetMoiveByIdAsync(int id)
        {
            var movieDetails = await _context.Movie.Include(c => c.Cinema).Include(p => p.Producer).Include(am => am.Actor_Movies).ThenInclude(a => a.Actor).FirstOrDefaultAsync(n => n.Id == id);

            return movieDetails;

        }
    }
}
