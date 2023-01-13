using ETicketMvc.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ETicketMvc.Data.ViewModels
{
    public class NewMovieVM
    {
        public int Id { get; set; }

        [Display(Name="Movie Name")]
        [Required(ErrorMessage ="Name is required")]
        public string Name { get; set; }

        [Display(Name = "Movie Description")]
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }


        [Display(Name = "Price in $")]
        [Required(ErrorMessage = "Price is required")]
        public double Price { get; set; }

        [Display(Name = "Movie Url Poster")]
        [Required(ErrorMessage = "Movie Poster Url is required")]
        public string ImageURL { get; set; }
        [Display(Name = "Movie StartDate")]
        [Required(ErrorMessage = "Movie StartDate is required")]

        public DateTime StartDate { get; set; }
        [Display(Name = "Movie EndDate")]
        [Required(ErrorMessage = "Movie EndDate is required")]

        public DateTime EndDate { get; set; }
        [Display(Name = "Select a Category")]
        [Required(ErrorMessage = "Movie Category is required")]

        public MovieCategory MovieCategory { get; set; }

        [Display(Name = "Select actor(s)")]
        [Required(ErrorMessage = "Movie actor(s) is required")]

        public List<int> ActorIds { get; set; }
        [Display(Name = "Select a Cinema")]
        [Required(ErrorMessage = "Movie Cinema is required")]

        public int CinemaId { get; set; }
        [Display(Name = "Select a Producer")]
        [Required(ErrorMessage = "Movie Producer is required")]

        public int ProducerId { get; set; }

    }
}
