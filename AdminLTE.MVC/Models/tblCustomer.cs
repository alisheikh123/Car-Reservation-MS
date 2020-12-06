using AdminLTE.MVC.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Car_Rental_System.Models
{
    public class tblCustomer
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int cusid { get; set; }


        [Display(Name = "First Name")]
        [Required(ErrorMessage = "Please Enter your First Name!")]
        public string First_Name { get; set; }


        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Please Enter your Last Name!")]
        public string Last_Name { get; set; }
        
        [Display(Name = "Email Address")]
        public string Email { get; set; }


        
        [Display(Name = "CNIC")]
        [RegularExpression("^[0-9+]{5}-[0-9+]{7}-[0-9]{1}$", ErrorMessage = "Incorrect CNIC")]
        public string CNIC { get; set; }

        
        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Phone number is Empty!")]
        public string mobileno { get; set; }



        [Display(Name = "City")]
        public int city { get; set; }

        [Display(Name = "State")]
        public int state { get; set; }

      
        [Display(Name = "Country")]
        public int country { get; set; }


        //---------Forign Keys----------
       

        [ForeignKey("city")]
        public virtual tblCity tblCity { get; set; }
    }
}
