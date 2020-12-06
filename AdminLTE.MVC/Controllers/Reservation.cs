using AdminLTE.MVC.Data;
using AdminLTE.MVC.Models;
using AdminLTE.MVC.Models.Class;
using AdminLTE.MVC.Models.ViewModel;
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


        public IActionResult getCountry() 
        {
            var country = db.tblCountry.ToList();
            List<country> countrylist = new List<country>();
            foreach (var s in country) 
            {
                countrylist.Add(new country
                {
                
                    country_Id = s.country_Id,
                    country_Name = s.country_Name
                });
            }


            return Json(countrylist);
        
        }
        public IActionResult getState(string country_id)
        {
            var state = db.tblState.Where(x=>x.country_Id.Equals(country_id)).ToList();
            List<state> statelist = new List<state>();
            foreach (var s in state)
            {
                statelist.Add(new state
                {

                    country_Id = s.country_Id,
                    state_Id = s.state_Id,
                    State = s.State
                });
            }


            return Json(statelist);

        }

        public IActionResult getCity()
        {
            var cities = db.tblCity.ToList();
            List<city> citylist = new List<city>();
            foreach (var s in cities)
            {
                citylist.Add(new city
                {

                    city_Id = s.city_Id,
                    City = s.City,
                    state_Id= s.state_Id
                   
                });
            }


            return Json(citylist);

        }
        public IActionResult Reservation_Create()
        
        {         
        
            var cat = db.tblCategories.ToList();
            var car = db.tblCars.ToList();
            DateTime date = DateTime.Now;
            ViewBag.fDate = date.ToString("yyyy-MM-dd");
            cat.Insert(0, new Car_Rental_System.Models.tblCategories { catId = 0, Title = "--Select Category--" });
            car.Insert(0, new Car_Rental_System.Models.tblCars { carId = 0, Car = "--Select Car--" });
            
            ViewBag.category = new SelectList(cat, "catId","Description");
            ViewBag.car = new SelectList(car, "Car", "Car");

            return View();
        }
        [HttpPost]
        public IActionResult Reservation_Create(ReservationNew Vm)
        {
            
                
                var cars = new tblCars
                {
                    catId = Vm.category.catId,
                    Car = Vm.car.Car,
                    color = Vm.car.Color,
                    Model_No = Vm.car.Model,
                    Brand_Name = Vm.car.Brand

                };
                var cus = new tblCustomer
                {
                    First_Name = Vm.customer.FirstName,
                    Last_Name = Vm.customer.LastName,
                    Email = Vm.customer.EmailAddress,
                    CNIC = Vm.customer.CNIC,
                    mobileno = Vm.customer.MobileNo,
                    state = Vm.customer.State,
                   

                };

                var loc = new tbllocation
                {
                    fLocation = Vm.location.fromLocation,
                    tLocation = Vm.location.toLocation,
                    fDate = Vm.location.fromDate,
                    tDate = Vm.location.toDate,
                    state = Vm.location.Stateloc,
                    country = Vm.location.Countryloc,
                    streetNo = Vm.location.StreetNo,
                    streetAddress = Vm.location.Address,
                    city = Vm.location.City

                };
          
                
                db.tblCars.Add(cars);
                db.tblCustomer.Add(cus);
                db.tbllocation.Add(loc);
               
                db.SaveChanges();
            
            return View();
        }
    }
}
