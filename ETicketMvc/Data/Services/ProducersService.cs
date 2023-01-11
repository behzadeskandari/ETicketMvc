using ETicketMvc.Data.Base;
using ETicketMvc.Models;

namespace ETicketMvc.Data.Services
{
    public class ProducersService : EntityBaseRepository<Producer>, IProducersService
    {

        public ProducersService(AppDbContext context) : base(context)
        {
        }
    }
}
