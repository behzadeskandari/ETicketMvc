using ETicketMvc.Data.Enums;
using ETicketMvc.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ETicketMvc.Data.Static;

namespace ETicketMvc.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();

                if (!context.Cinema.Any())
                {
                    context.Cinema.AddRange(new List<Cinema>()
                    {
                        new Cinema()
                        {
                            Name = "Cinema1",
                            Logo = "http://dotnethow.net/images/cinemas/cinema-1.jpeg",
                            Description = "this is the description of the first cinema"
                            
                        },
                        new Cinema()
                        {
                            Name = "Cinema2",
                            Logo = "http://dotnethow.net/images/cinemas/cinema-2.jpeg",
                            Description = "this is the description of the 2nd cinema"

                        },
                        new Cinema()
                        {
                            Name = "Cinema3",
                            Logo = "http://dotnethow.net/images/cinemas/cinema-3.jpeg",
                            Description = "this is the description of the 3rd cinema"

                        }

                    });
                    context.SaveChanges();
                }
                if (!context.Actors.Any())
                {
                    context.Actors.AddRange(new List<Actor>()
                    {
                        new Actor()
                        {
                            FullName = "Actor1",
                            Bio = "this is the bio of first actor",
                            ProfilePictureURL = "http://dotnethow.net/images/actors/actor-1.jpeg",

                        },
                        new Actor()
                        {
                            FullName = "Actor2",
                            Bio = "this is the bio of 2nd actor",
                            ProfilePictureURL = "http://dotnethow.net/images/actors/actor-2.jpeg",

                        },
                        new Actor()
                        {
                            FullName = "Actor2",
                            Bio = "this is the bio of 3rd actor",
                            ProfilePictureURL = "http://dotnethow.net/images/actors/actor-3.jpeg"

                        }

                    });
                    context.SaveChanges();

                }
                if (!context.Producer.Any())
                {
                    context.Producer.AddRange(new List<Producer>()
                    {
                        new Producer()
                        {
                            FullName = "Producer 1",
                            Bio = "this is the bio of first producer",
                            ProfilePictureURL = "http://dotnethow.net/images/producer/producer-1.jpeg",

                        },
                        new Producer()
                        {
                            FullName = "Producer 2",
                            Bio = "this is the bio of 2nd producer",
                            ProfilePictureURL = "http://dotnethow.net/images/producer/producer-2.jpeg",

                        },
                        new Producer()
                        {
                            FullName = "Producer 3",
                            Bio = "this is the bio of 2nd producer",
                            ProfilePictureURL = "http://dotnethow.net/images/producer/producer-3.jpeg"

                        }

                    });
                    context.SaveChanges();

                }

                if (!context.Movie.Any())
                {
                    context.Movie.AddRange(new List<Movie>()
                    {
                        new Movie()
                        {
                            Name= "Scoob",
                            Description = "this is the scoob Movie description",
                            Price = 29.50,
                            ImageURL= "http://dotnethow.net/images/movies/movie-2.jpeg",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(-2),
                            CinemaId = 1,
                            ProducerId = 3,
                            MovieCategory = MovieCategory.Cartoon
                            

                        },
                        new Movie()
                        {
                            Name= "cold Soles",
                            Description = "this is the cold Soles Movie description",
                            Price = 29.50,
                            ImageURL= "http://dotnethow.net/images/movies/movie-8.jpeg",
                                  StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(-2),
                            CinemaId = 2,
                            ProducerId = 2,
                            MovieCategory = MovieCategory.Cartoon

                        },
                        
                    });
                    context.SaveChanges();

                }

                if (!context.Actor_Movies.Any())
                {
                    context.Actor_Movies.AddRange(new List<Actor_Movie>()
                    {
                        new Actor_Movie()
                        {
                            ActorId = 1,
                            MovieId =2,

                        },
                        new Actor_Movie()
                        {
                             ActorId = 2,
                             MovieId = 2 
                        },
                        new Actor_Movie()
                        {
                            ActorId = 3,
                            MovieId = 2
                        }

                    });
                    context.SaveChanges();

                }
            }
        }


        public static async Task SeedUserAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                //Roles Section
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));

                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                //User
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                string adminUserEmail = "behzad.b.i.g@gmail.com";
                var adminuser = await userManager.FindByNameAsync(adminUserEmail);
                if (adminuser == null)
                {
                    var newAdminUser = new ApplicationUser()
                    {
                        FullName = "behad eskandari",
                        UserName = "admin-user",
                        Email = adminUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAdminUser, "coding@1234?");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }

                //simple User 
                string appUserEmail = "user@etickets.com";

                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if(appUser == null)
                {
                    var newappUser = new ApplicationUser()
                    {
                        FullName = "Application User",
                        UserName = "app-user",
                        Email = appUserEmail,
                        EmailConfirmed = true
                    };

                    await userManager.CreateAsync(newappUser, "coding@1234?");
                    await userManager.AddToRoleAsync(newappUser, UserRoles.User);
                }

            }

        }
    }
}
