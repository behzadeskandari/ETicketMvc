using ETicketMvc.Data.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ETicketMvc.Models
{
    public class Actor : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name ="Profile Picture")]
        [Required(ErrorMessage ="Profile Picture is Required")]
        public string ProfilePictureURL { get; set; }

        [Display(Name = "Full Name")]

        [Required(ErrorMessage = "FullName is Required")]
        [StringLength(50 , MinimumLength = 3 ,ErrorMessage ="Full Name Must Be between 3 and 50 character")]
        public string FullName { get; set; }


        [Display(Name = "Biography")]

        [Required(ErrorMessage = "Bio is Required")]
        public string Bio { get; set; }

        public List<Actor_Movie> Actor_Movies { get; set; }
    
    
    }
}
