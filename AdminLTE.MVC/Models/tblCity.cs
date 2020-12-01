using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AdminLTE.MVC.Models
{
    public class tblCity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int city_Id { get; set; }

        [Display(Name = "State Name")]
        public int state_Id { get; set; }

        [Display(Name = "City Name")]
        public string City { get; set; }


        [ForeignKey("state_Id")]
        public virtual tblState tblState { get; set; }
    }
}
