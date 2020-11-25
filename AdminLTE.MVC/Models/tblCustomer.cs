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
        [Required]
        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email Address is Empty!")]
        public string Email { get; set; }


        [Required]
        [Display(Name = "CNIC")]
        public string CNIC { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Phone number is Empty!")]
        public int mobileno { get; set; }

        [Display(Name = "State")]
        public string state { get; set; }

        [Required]
        [Display(Name = "Country")]
        public string country { get; set; }
    }
}
