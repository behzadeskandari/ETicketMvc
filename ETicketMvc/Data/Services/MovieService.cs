using ETicketMvc.Data.Base;
using ETicketMvc.Data.ViewModels;
using ETicketMvc.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
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

        public async Task AddNewMovieAsync(NewMovieVM data)
        {
            var newMovie = new Movie()
            {
                Name = data.Name,
                Description = data.Description,
                Price = data.Price,
                ImageURL = data.ImageURL,
                CinemaId = data.CinemaId,
                StartDate = data.StartDate,
                EndDate = data.EndDate,
                MovieCategory = data.MovieCategory,
                ProducerId = data.ProducerId,
            };
            await _context.Movie.AddAsync(newMovie);
            await _context.SaveChangesAsync();

            foreach (var actorId in data.ActorIds)
            {
                var newActorMovie = new Actor_Movie()
                {
                    MovieId = newMovie.Id,
                    ActorId = actorId,
                };
                await _context.Actor_Movies.AddAsync(newActorMovie);
            }
            await _context.SaveChangesAsync();

        }

        public async Task<Movie> GetMoiveByIdAsync(int id)
        {
            var movieDetails = await _context.Movie.Include(c => c.Cinema).Include(p => p.Producer).Include(am => am.Actor_Movies).ThenInclude(a => a.Actor).FirstOrDefaultAsync(n => n.Id == id);

            return movieDetails;

        }

        public async Task<NewMovieDropdownVM> GetNewMovieDropdownsValues()
        {
            var response = new NewMovieDropdownVM()
            {
                Actors = await _context.Actors.OrderBy(n => n.FullName).ToListAsync(),
                Cinemas = await _context.Cinema.OrderBy(n => n.Name).ToListAsync(),
                Producers = await _context.Producer.OrderBy(n => n.FullName).ToListAsync(),

            };

            return response;


        }

        public async Task UpdateMovieAsync(NewMovieVM data)
        {
            var dbMovie = await _context.Movie.FirstOrDefaultAsync(x => x.Id == data.Id);
            if(dbMovie != null)
            {

                dbMovie.Name = data.Name;
                dbMovie.Description = data.Description;
                dbMovie.Price = data.Price;
                dbMovie.ImageURL = data.ImageURL;
                dbMovie.CinemaId = data.CinemaId;
                dbMovie.StartDate = data.StartDate;
                dbMovie.EndDate = data.EndDate;
                dbMovie.MovieCategory = data.MovieCategory;
                dbMovie.ProducerId = data.ProducerId;
                await _context.SaveChangesAsync();

                var existingActorsDb = _context.Actor_Movies.Where(n => n.MovieId == data.Id).ToList();
                 _context.Actor_Movies.RemoveRange(existingActorsDb);
                await _context.SaveChangesAsync();

                foreach (var actorId in data.ActorIds)
                {
                    var newActorMovie = new Actor_Movie()
                    {
                        MovieId = data.Id,
                        ActorId = actorId,
                    };
                    await _context.Actor_Movies.AddAsync(newActorMovie);
                }
                await _context.SaveChangesAsync();
            }
            
        }
    }
}
