using ETicketMvc.Data.Base;
using ETicketMvc.Models;
using System.Threading.Tasks;

namespace ETicketMvc.Data.Services
{
    public interface IMovieService : IEntityBaseRepository<Movie>
    {
        Task<Movie> GetMoiveByIdAsync(int id);

    }
}
