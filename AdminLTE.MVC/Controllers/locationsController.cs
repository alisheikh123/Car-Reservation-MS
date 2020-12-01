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
    public class locationsController : Controller
    {
        private readonly ApplicationDbContext db;

        public locationsController(ApplicationDbContext context)
        {
            db = context;
        }

        // GET: locations
        public async Task<IActionResult> Index()
        {
            return View(await db.tbllocation.ToListAsync());
        }

        // GET: locations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbllocation = await db.tbllocation
                .FirstOrDefaultAsync(m => m.locationId == id);
            if (tbllocation == null)
            {
                return NotFound();
            }

            return View(tbllocation);
        }

        // GET: locations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: locations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("locationId,fLocation,tLocation,fDate,tDate,streetNo,streetAddress,city,stateabre,state,country")] tbllocation tbllocation)
        {
            if (ModelState.IsValid)
            {
                db.Add(tbllocation);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tbllocation);
        }

        // GET: locations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbllocation = await db.tbllocation.FindAsync(id);
            if (tbllocation == null)
            {
                return NotFound();
            }
            return View(tbllocation);
        }

        // POST: locations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("locationId,fLocation,tLocation,fDate,tDate,streetNo,streetAddress,city,stateabre,state,country")] tbllocation tbllocation)
        {
            if (id != tbllocation.locationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(tbllocation);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!tbllocationExists(tbllocation.locationId))
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
            return View(tbllocation);
        }

        // GET: locations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbllocation = await db.tbllocation
                .FirstOrDefaultAsync(m => m.locationId == id);
            if (tbllocation == null)
            {
                return NotFound();
            }

            return View(tbllocation);
        }

        // POST: locations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbllocation = await db.tbllocation.FindAsync(id);
            db.tbllocation.Remove(tbllocation);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tbllocationExists(int id)
        {
            return db.tbllocation.Any(e => e.locationId == id);
        }
    }
}
