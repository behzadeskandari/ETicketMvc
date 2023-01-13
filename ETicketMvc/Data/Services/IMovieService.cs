using ETicketMvc.Data.Base;
using ETicketMvc.Data.ViewModels;
using ETicketMvc.Models;
using System.Threading.Tasks;

namespace ETicketMvc.Data.Services
{
    public interface IMovieService : IEntityBaseRepository<Movie>
    {
        Task<Movie> GetMoiveByIdAsync(int id);

        Task<NewMovieDropdownVM> GetNewMovieDropdownsValues();

        Task AddNewMovieAsync(NewMovieVM data);

        Task UpdateMovieAsync(NewMovieVM data);

    }
}
