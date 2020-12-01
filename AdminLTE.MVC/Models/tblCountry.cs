using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AdminLTE.MVC.Models
{
    public class tblCountry
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int country_Id { get; set; }

        [Display(Name ="Country Name")]
        public string country_Name { get; set; }

    }
}
