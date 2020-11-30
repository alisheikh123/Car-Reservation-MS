using AdminLTE.MVC.Data;
using AdminLTE.MVC.Models.Class;
using Car_Rental_System.Models;
using CountryData.Standard;
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
            var objCountry = new ReservationForm();
            var countryHelper = new CountryHelper();
            var countries = countryHelper.GetCountryData();

            var country = countries.ToList();
            var cat = db.tblCategories.ToList();
            var car = db.tblCars.ToList();
            ViewBag.fDate = DateTime.Now;
            cat.Insert(0, new Car_Rental_System.Models.tblCategories { catId = 0, Title = "--Select Category--" });
            car.Insert(0, new Car_Rental_System.Models.tblCars { carId = 0, Car = "--Select Car--" });
            

            ViewBag.category = new SelectList(cat, "catId","Description");
            ViewBag.car = new SelectList(car, "Car", "Car");

            //objCountry.Country = new SelectList(country, "Id", "Value");

            
            
            


            return View();
        }
        [HttpPost]
        public IActionResult Reservation_Create(ReservationForm Vm)
        {
            var category = new tblCategories
            {
                Title = Vm.Car
            };
            var cars = new tblCars
            {
                catId = Vm.catId,
                Car = Vm.Car,
                color = Vm.Color,
                Model_No = Vm.Model,
                Brand_Name = Vm.Brand

            };
            var cus = new tblCustomer 
            {
              First_Name = Vm.FirstName,
              Last_Name = Vm.LastName,
              Email = Vm.EmailAddress,
              CNIC = Vm.CNIC,
              mobileno = Vm.MobileNo,
              state = Vm.State,
              country = Vm.Country
            
            };

            var loc = new tbllocation
            {
                fLocation = Vm.fromLocation,
                tLocation = Vm.toLocation,
                fDate = Vm.fromDate,
                tDate = Vm.toDate,
                state = Vm.Stateloc,
                country = Vm.Countryloc,
                streetNo = Vm.StreetNo,
                streetAddress = Vm.Address,
                city = Vm.City

            };
            db.tblCategories.Add(category);
            db.tblCars.Add(cars);
            db.tblCustomer.Add(cus);
            db.tbllocation.Add(loc);
            db.SaveChanges();

            return View();
        }
    }
}
