using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Car_Rental_System.Models
{
    public class tblCars
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int carId { get; set; }

        [Display(Name = "Category Name")]
        public int catId { get; set; }


        [Display(Name = "Car Name")]
        public string Car { get; set; }

        [Display(Name = "Color")]
        public string color { get; set; }

        [Display(Name = "Model Name")]
        public string Model_No { get; set; }

        [Display(Name = "Brand Name")]
        public string Brand_Name { get; set; }

        [Display(Name = "Purchase Date")]
        [DataType(DataType.DateTime)]
        public DateTime purchase_date { get; set; }



        [ForeignKey("catId")]
        public virtual tblCategories tblCategories { get; set; }


    }
}
