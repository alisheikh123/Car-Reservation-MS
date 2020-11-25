using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Car_Rental_System.Models
{
    public class tblPhone
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Phone Number ")]
        public string PhoneNo { get; set; }

        [Required]
        [Display(Name = "Location ")]
        public int locid { get; set; }

        [ForeignKey("locid")]
        public virtual tbllocation tbllocation { get; set; }
    }
}
