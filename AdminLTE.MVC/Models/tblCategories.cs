using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Car_Rental_System.Models
{
    [AllowAnonymous]
    public class tblCategories
    {
        
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int catId { get; set; }
        [Required]
        [Display(Name = "Title")]
        public string Title { get; set; }
        
        [Display(Name = "Description")]
        public string Description { get; set; }
    }
}
