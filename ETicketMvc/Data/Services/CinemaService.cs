using ETicketMvc.Data.Base;
using ETicketMvc.Models;

namespace ETicketMvc.Data.Services
{
    public class CinemaService : EntityBaseRepository<Cinema>, ICinemaService
    {
        public CinemaService(AppDbContext context) : base(context)
        {

        }

    }
}
