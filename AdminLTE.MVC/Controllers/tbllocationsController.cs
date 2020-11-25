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
    public class tbllocationsController : Controller
    {
        private readonly ApplicationDbContext db;

        public tbllocationsController(ApplicationDbContext context)
        {
            db = context;
        }

        // GET: tbllocations
        public async Task<IActionResult> Index()
        {
            return View(await db.tbllocation.ToListAsync());
        }

        // GET: tbllocations/Details/5
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

        // GET: tbllocations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: tbllocations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("locationId,streetNo,streetAddress,city,stateabre,state,country")] tbllocation tbllocation)
        {
            if (ModelState.IsValid)
            {
                db.Add(tbllocation);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tbllocation);
        }

        // GET: tbllocations/Edit/5
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

        // POST: tbllocations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("locationId,streetNo,streetAddress,city,stateabre,state,country")] tbllocation tbllocation)
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

        // GET: tbllocations/Delete/5
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

        // POST: tbllocations/Delete/5
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
