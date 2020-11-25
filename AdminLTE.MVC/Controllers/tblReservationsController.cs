using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AdminLTE.MVC.Data;
using Car_Rental_System.Models;

namespace AdminLTE.MVC.Controllers
{
    public class tblReservationsController : Controller
    {
        private readonly ApplicationDbContext db;

        public tblReservationsController(ApplicationDbContext context)
        {
            db = context;
        }

        // GET: tblReservations
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = db.tblReservation.Include(t => t.tblCars).Include(t => t.tblCustomer);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: tblReservations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblReservation = await db.tblReservation
                .Include(t => t.tblCars)
                .Include(t => t.tblCustomer)
                .FirstOrDefaultAsync(m => m.resId == id);
            if (tblReservation == null)
            {
                return NotFound();
            }

            return View(tblReservation);
        }

        // GET: tblReservations/Create
        public IActionResult Create()
        {
            ViewData["carId"] = new SelectList(db.tblCars, "carId", "carId");
            ViewData["cusid"] = new SelectList(db.tblCustomer, "cusid", "CNIC");
            return View();
        }

        // POST: tblReservations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("resId,carId,cusid,Pick_location,Pick_Date,Return_location,Return_Date,amount")] tblReservation tblReservation)
        {
            if (ModelState.IsValid)
            {
                db.Add(tblReservation);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["carId"] = new SelectList(db.tblCars, "carId", "carId", tblReservation.carId);
            ViewData["cusid"] = new SelectList(db.tblCustomer, "cusid", "CNIC", tblReservation.cusid);
            return View(tblReservation);
        }

        // GET: tblReservations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblReservation = await db.tblReservation.FindAsync(id);
            if (tblReservation == null)
            {
                return NotFound();
            }
            ViewData["carId"] = new SelectList(db.tblCars, "carId", "carId", tblReservation.carId);
            ViewData["cusid"] = new SelectList(db.tblCustomer, "cusid", "CNIC", tblReservation.cusid);
            return View(tblReservation);
        }

        // POST: tblReservations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("resId,carId,cusid,Pick_location,Pick_Date,Return_location,Return_Date,amount")] tblReservation tblReservation)
        {
            if (id != tblReservation.resId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(tblReservation);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!tblReservationExists(tblReservation.resId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["carId"] = new SelectList(db.tblCars, "carId", "carId", tblReservation.carId);
            ViewData["cusid"] = new SelectList(db.tblCustomer, "cusid", "CNIC", tblReservation.cusid);
            return View(tblReservation);
        }

        // GET: tblReservations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblReservation = await db.tblReservation
                .Include(t => t.tblCars)
                .Include(t => t.tblCustomer)
                .FirstOrDefaultAsync(m => m.resId == id);
            if (tblReservation == null)
            {
                return NotFound();
            }

            return View(tblReservation);
        }

        // POST: tblReservations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblReservation = await db.tblReservation.FindAsync(id);
            db.tblReservation.Remove(tblReservation);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tblReservationExists(int id)
        {
            return db.tblReservation.Any(e => e.resId == id);
        }
    }
}
