using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AdminLTE.MVC.Models
{
    public class tblState
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int state_Id { get; set; }

        [Display(Name = "Country Name")]
        public int country_Id { get; set; }

        [Display(Name = "State Name")]
        public string State { get; set; }


        [ForeignKey("country_Id")]
        public virtual tblCountry tblCountry { get; set; }
    }
}
