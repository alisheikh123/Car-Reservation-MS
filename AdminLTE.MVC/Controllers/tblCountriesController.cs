using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AdminLTE.MVC.Data;
 
using Microsoft.AspNetCore.Authorization;

namespace AdminLTE.MVC.Controllers
{
    [AllowAnonymous]
    public class tblCountriesController : Controller
    {
        private readonly ApplicationDbContext db;

        public tblCountriesController(ApplicationDbContext context)
        {
            db = context;
        }

        // GET: tblCountries
        public async Task<IActionResult> Index()
        {
            return View(await db.tblCountry.ToListAsync());
        }

        // GET: tblCountries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblCountry = await db.tblCountry
                .FirstOrDefaultAsync(m => m.country_Id == id);
            if (tblCountry == null)
            {
                return NotFound();
            }

            return View(tblCountry);
        }

        // GET: tblCountries/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: tblCountries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("country_Id,country_Name")] tblCountry tblCountry)
        {
            if (ModelState.IsValid)
            {
                db.Add(tblCountry);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblCountry);
        }

        // GET: tblCountries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblCountry = await db.tblCountry.FindAsync(id);
            if (tblCountry == null)
            {
                return NotFound();
            }
            return View(tblCountry);
        }

        // POST: tblCountries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("country_Id,country_Name")] tblCountry tblCountry)
        {
            if (id != tblCountry.country_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(tblCountry);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!tblCountryExists(tblCountry.country_Id))
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
            return View(tblCountry);
        }

        // GET: tblCountries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblCountry = await db.tblCountry
                .FirstOrDefaultAsync(m => m.country_Id == id);
            if (tblCountry == null)
            {
                return NotFound();
            }

            return View(tblCountry);
        }

        // POST: tblCountries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblCountry = await db.tblCountry.FindAsync(id);
            db.tblCountry.Remove(tblCountry);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tblCountryExists(int id)
        {
            return db.tblCountry.Any(e => e.country_Id == id);
        }
    }
}
