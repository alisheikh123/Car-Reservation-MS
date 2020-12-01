using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Car_Rental_System.Models
{
    public class tbllocation
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int locationId { get; set; }

        [Display(Name = "From Location")]
       
        public string fLocation { get; set; }

        [Display(Name = "To Location")]
        
        public string tLocation { get; set; }

        
        [Display(Name = "From Date")]
       [DataType(DataType.Date)]
        public DateTime fDate { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "To Date")]
        public DateTime tDate { get; set; }




        [Display(Name = "Street No")]
        public string streetNo { get; set; }

      
        [Display(Name = "Street Address")]
        public string streetAddress { get; set; }

        
        [Display(Name = "City")]
        public string city { get; set; }


      
        [Display(Name = "State Abbrevation ")]
        public string stateabre { get; set; }


      
        [Display(Name = "State")]
        public string state { get; set; }
       
        [Display(Name = "Country")]
        public string country { get; set; }

    }
}
