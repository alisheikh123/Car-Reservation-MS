using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Car_Rental_System.Models
{
    public class tblReservation
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int resId { get; set; }

        [Display(Name = "Car Name")]
        public int carId { get; set; }


        [Display(Name = "Customer Name")]
        public int cusid { get; set; }

        [Display(Name = "Pick Location")]
        public string Pick_location { get; set; }

        [Required]
        [Display(Name = "Pick Date")]
        [DataType(DataType.DateTime)]
        public DateTime Pick_Date { get; set; }

        [Display(Name = "Return Location")]
        public string Return_location { get; set; }


        [Required]
        [Display(Name = "Return Date")]
        [DataType(DataType.DateTime)]
        public DateTime Return_Date { get; set; }



        [Required]
        [Display(Name = "Amount")]
        [Column(TypeName = "decimal(18,4)")]
        public decimal amount { get; set; }









        [ForeignKey("carId")]
        public virtual tblCars tblCars { get; set; }

        [ForeignKey("cusid")]
        public virtual tblCustomer tblCustomer { get; set; }

        //[ForeignKey("Pick_location")]
        //[InverseProperty("tbllocation")]
        //public virtual tbllocation pick_location { get; set; }


        //[ForeignKey("Return_location")]
       
        //public virtual tbllocation return_location { get; set; }
    }
}
