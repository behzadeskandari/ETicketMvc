using ETicketMvc.Data.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ETicketMvc.Models
{
    public class Producer:IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Profile Picture is Required")]
        [Display(Name ="Profile Picture")]
        public string ProfilePictureURL { get; set; }

        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Full Name is Required")]
        [StringLength(50,MinimumLength =3,ErrorMessage ="Full Name must Between 3 and 50 chars")]
        public string FullName { get; set; }

        
        [Display(Name = "Biography")]
        [Required(ErrorMessage = "Biography is Required")]

        public string Bio { get; set; }

        public List<Movie> Movies { get; set; }
    
    
    }
}
