using AdminLTE.MVC.Models.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminLTE.MVC.Models.ViewModel
{
    public class ReservationNew
    {
        public category category { get; set; }
        public car car { get; set; }
        public customer customer { get; set; }
        public location location { get; set; }
        public country country { get; set; }
        public state state { get; set; }
        public city city { get; set; }
    }
}
