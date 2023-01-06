using ETicketMvc.Data.Base;
using ETicketMvc.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETicketMvc.Data.Services
{
    public class ActorService : EntityBaseRepository<Actor>,IActorService
    {
        //private readonly AppDbContext _context;

        public ActorService(AppDbContext context) : base(context)
        {
            //_context = context;
        }

        //public async Task AddAsync(Actor actor)
        //{

        //    await _appDbContext.Actors.AddAsync(actor);
        
        //    await _appDbContext.SaveChangesAsync();
        //}

        //public async Task DeleteAsync(int id)
        //{
        //    var result = await _appDbContext.Actors.FirstOrDefaultAsync(n => n.Id == id);
        //     _appDbContext.Actors.Remove(result);
        //    await _appDbContext.SaveChangesAsync();
        //}

        ////public async Task<IEnumerable<Actor>> GetAllAsync()
        ////{
        ////    var result = await _appDbContext.Actors.ToListAsync();
            
        ////    return result;
        ////}

        ////public async Task<Actor> GetByIdAsync(int id)
        ////{
        ////    var result = await _appDbContext.Actors.FirstOrDefaultAsync(n => n.Id == id);

        ////    return result;

        ////}

        //public async Task<Actor> UpdateAsync(int id, Actor newActor)
        //{
        //    _appDbContext.Update(newActor);
        //    await _appDbContext.SaveChangesAsync();

        //    return newActor;
        //}
    }
}
