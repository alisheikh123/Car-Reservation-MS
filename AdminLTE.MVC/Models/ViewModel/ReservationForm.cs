using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdminLTE.MVC.Models.Class
{
  
    public class category 
    {
        public int catId { get; set; }
        public string Category { get; set; }
    }
    public class car
    {
        public int carId { get; set; }

        [Display(Name = "Category Name")]
        public int catId { get; set; }


        [Display(Name = "Car Name")]
        public string Car { get; set; }

        [Display(Name = "Color")]
        public string Color { get; set; }

        [Display(Name = "Model Name")]
        public string Model { get; set; }

        [Display(Name = "Brand Name")]
        public string Brand { get; set; }

        
    }
    public class customer 
    {
        public int cusid { get; set; }  
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Display(Name = "Email")]
        public string EmailAddress { get; set; }  
        public string CNIC { get; set; }
        [Display(Name = "Mobile No")]
        public string MobileNo { get; set; }

        public int City { get; set; }

        public int State { get; set; }

        public int country_Name { get; set; }
    }
    public class location {
        public int locationId { get; set; }

        [Display(Name = "From Location")]
        public string fromLocation { get; set; }

        [Display(Name = "To Location")]
        public string toLocation { get; set; }


        [Display(Name = "From Date")]
        [DataType(DataType.Date)]
        public DateTime fromDate { get; set; }

        [Display(Name = "To Date")]
        [DataType(DataType.Date)]
        public DateTime toDate { get; set; }




        [Display(Name = "Street No")]
        public string StreetNo { get; set; }


        [Display(Name = "Street Address")]
        public string Address { get; set; }


        [Display(Name = "City")]
        public string City { get; set; }



        [Display(Name = "State Abbrevation ")]
        public string stateabre { get; set; }



        [Display(Name = "State")]
        public string Stateloc { get; set; }
        [Display(Name = "Country")]
        public string Countryloc { get; set; }
    }
    public class country 
    {
        public int country_Id { get; set; }

        [Display(Name = "Country Name")]
        public string country_Name { get; set; }
    }
    public class state 
    {
        public int state_Id { get; set; }

        [Display(Name = "Country Name")]
        public int country_Id { get; set; }

        [Display(Name = "State Name")]
        public string State { get; set; }
    }
    public class city 
    {
        public int city_Id { get; set; }

        [Display(Name = "State Name")]
        public int state_Id { get; set; }

        [Display(Name = "City Name")]
        public string City { get; set; }
    }


}
