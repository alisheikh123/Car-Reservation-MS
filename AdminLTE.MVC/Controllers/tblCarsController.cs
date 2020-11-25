using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AdminLTE.MVC.Data;
using Car_Rental_System.Models;
using Microsoft.AspNetCore.Authorization;

namespace AdminLTE.MVC.Controllers
{
    [AllowAnonymous]
    public class tblCarsController : Controller
    {
        private readonly ApplicationDbContext db;

        public tblCarsController(ApplicationDbContext context)
        {
            db = context;
        }

        // GET: tblCars
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = db.tblCars.Include(t => t.tblCategories);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: tblCars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblCars = await db.tblCars
                .Include(t => t.tblCategories)
                .FirstOrDefaultAsync(m => m.carId == id);
            if (tblCars == null)
            {
                return NotFound();
            }

            return View(tblCars);
        }

        // GET: tblCars/Create
        public IActionResult Create()
        {
            ViewData["catId"] = new SelectList(db.tblCategories, "catId", "Description");
            return View();
        }

        // POST: tblCars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("carId,catId,Car,color,Model_No,Brand_Name,purchase_date")] tblCars tblCars)
        {
            if (ModelState.IsValid)
            {
                db.Add(tblCars);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["catId"] = new SelectList(db.tblCategories, "catId", "Description", tblCars.catId);
            return View(tblCars);
        }

        // GET: tblCars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblCars = await db.tblCars.FindAsync(id);
            if (tblCars == null)
            {
                return NotFound();
            }
            ViewData["catId"] = new SelectList(db.tblCategories, "catId", "Description", tblCars.catId);
            return View(tblCars);
        }

        // POST: tblCars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("carId,catId,Car,color,Model_No,Brand_Name,purchase_date")] tblCars tblCars)
        {
            if (id != tblCars.carId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(tblCars);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!tblCarsExists(tblCars.carId))
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
            ViewData["catId"] = new SelectList(db.tblCategories, "catId", "Description", tblCars.catId);
            return View(tblCars);
        }

        // GET: tblCars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblCars = await db.tblCars
                .Include(t => t.tblCategories)
                .FirstOrDefaultAsync(m => m.carId == id);
            if (tblCars == null)
            {
                return NotFound();
            }

            return View(tblCars);
        }

        // POST: tblCars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblCars = await db.tblCars.FindAsync(id);
            db.tblCars.Remove(tblCars);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tblCarsExists(int id)
        {
            return db.tblCars.Any(e => e.carId == id);
        }
    }
}
