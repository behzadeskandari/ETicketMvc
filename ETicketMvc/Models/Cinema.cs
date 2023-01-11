using ETicketMvc.Data.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ETicketMvc.Models
{
    public class Cinema: IEntityBase
    {

        [Key]
        public int Id { get; set; }

        [Display(Name ="Cinema Logo")]
        [Required(ErrorMessage = "Logo is Required")]

        public string Logo { get; set; }


        [Display(Name = "Cinema Name")]
        [Required(ErrorMessage = "Name is Required")]
        public string Name { get; set; }

        [Display(Name = "Cinema Description")]
        [Required(ErrorMessage = "Description is Required")]

        public string Description { get; set; }

        public List<Movie> Movies { get; set; }


    }

}
