using AdminLTE.MVC.Data;
using Car_Rental_System.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminLTE.MVC.Controllers
{
    [AllowAnonymous]
    public class Reservation : Controller
    {
        private ApplicationDbContext db;
        public Reservation(ApplicationDbContext context)
        {
            db = context;
        }

        
        public IActionResult Reservation_Create()
        
        {
            var cat = db.tblCategories.OrderBy(x => x.Title).ToList();
            var car = db.tblCars.OrderBy(x => x.Car).ToList();
            cat.Insert(0, new Car_Rental_System.Models.tblCategories { catId = 0, Title = "--Select Category--" });
            car.Insert(0, new Car_Rental_System.Models.tblCars { carId = 0, Car = "--Select Car--" });
            var cats = new SelectList(cat, "catId","Title");
            var cars = new SelectList(car, "carId", "Car");

            ViewBag.category = cats;
            ViewBag.car = cars;


            return View();
        }
    }
}
