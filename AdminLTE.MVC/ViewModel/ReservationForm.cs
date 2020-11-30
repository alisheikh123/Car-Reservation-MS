using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdminLTE.MVC.Models.Class
{
    public class ReservationForm
    {
        [Key]
        public int catId { get; set; }
        public string Category { get; set; }
        public int carId { get; set; }
        public string Car { get; set; }
        public string CountryCode { get; set; }
        
        public string Brand { get; set; }    
        public string Color { get; set; }
        public string Model { get; set; }
        [Display(Name ="First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }

        [RegularExpression("^[0-9]{5}-[0-9]{7}-[0-9]",ErrorMessage ="Format Must Be XXXXX-XXXXXXXX-X")]
        public string CNIC { get; set; }
        [Display(Name = "Mobile No")]
        public string MobileNo { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        [Display(Name = "Street No")]
        public string StreetNo { get; set; }

        [Display(Name = "Street Address")]
        public string Address { get; set; }

        [Display(Name = "City")]
        public string City { get; set; }

        [Display(Name = "State")]
        public string Stateloc { get; set; }

        [Display(Name = "Country")]
        public string Countryloc { get; set; }

        [Display(Name = "From Location")]
        public string fromLocation { get; set; }

        [Display(Name = "From Date")]
        [DataType(DataType.Date)]
        public DateTime fromDate { get; set; }

        [Display(Name = "To Location")]
        public string toLocation { get; set; }

        [Display(Name = "To Date")]
        public DateTime toDate { get; set; }


    }
}
