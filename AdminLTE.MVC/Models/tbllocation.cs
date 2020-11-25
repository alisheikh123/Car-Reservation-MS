using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Car_Rental_System.Models
{
    public class tbllocation
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int locationId { get; set; }
        [Required]
        [Display(Name = "Street No")]
        public string streetNo { get; set; }

        [Required]
        [Display(Name = "Street Address")]
        public string streetAddress { get; set; }

        [Required]
        [Display(Name = "City")]
        public string city { get; set; }


        [Required]
        [Display(Name = "State Abbrevation ")]
        public string stateabre { get; set; }


        [Required]
        [Display(Name = "State")]
        public string state { get; set; }
        [Required]
        [Display(Name = "Country")]
        public string country { get; set; }

    }
}
