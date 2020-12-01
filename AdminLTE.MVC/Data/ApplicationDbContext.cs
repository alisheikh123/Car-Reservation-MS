using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Car_Rental_System.Models;
using AdminLTE.MVC.Models;

namespace AdminLTE.MVC.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Car_Rental_System.Models.tblCategories> tblCategories { get; set; }
        public DbSet<Car_Rental_System.Models.tblCars> tblCars { get; set; }
        public DbSet<Car_Rental_System.Models.tblCustomer> tblCustomer { get; set; }
        public DbSet<Car_Rental_System.Models.tbllocation> tbllocation { get; set; }
        public DbSet<Car_Rental_System.Models.tblPhone> tblPhone { get; set; }
        public DbSet<Car_Rental_System.Models.tblReservation> tblReservation { get; set; }
        public DbSet<AdminLTE.MVC.Models.tblCountry> tblCountry { get; set; }
        public DbSet<AdminLTE.MVC.Models.tblState> tblState { get; set; }
        public DbSet<AdminLTE.MVC.Models.tblCity> tblCity { get; set; }
    }
}
