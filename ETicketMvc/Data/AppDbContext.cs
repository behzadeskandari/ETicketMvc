using ETicketMvc.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ETicketMvc.Data
{
    public class AppDbContext: IdentityDbContext<ApplicationUser>
    {

        public AppDbContext(DbContextOptions<AppDbContext> options): base(options) 
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor_Movie>().HasKey(am => new
            {
                am.ActorId,
                am.MovieId,
            });

            modelBuilder.Entity<Actor_Movie>().HasOne(m => m.Movie).WithMany(am => am.Actor_Movies).HasForeignKey(m => m.MovieId);
            
            modelBuilder.Entity<Actor_Movie>().HasOne(m => m.Actor).WithMany(am => am.Actor_Movies).HasForeignKey(m => m.ActorId);


            


            base.OnModelCreating(modelBuilder);
        }


        public DbSet<Actor> Actors { get; set; }
        public DbSet<Movie> Movie { get; set; }
        public DbSet<Actor_Movie> Actor_Movies { get; set; }
        public DbSet<Cinema> Cinema { get; set; }
        public DbSet<Producer> Producer { get; set; }
        
        /// <summary>
        /// order related orders
        /// </summary>
        public DbSet<Order> Order { get; set; }

        /// <summary>
        /// order related orders
        /// </summary>
        public DbSet<OrderItem> OrderItem { get; set; }


        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }

    }
}
