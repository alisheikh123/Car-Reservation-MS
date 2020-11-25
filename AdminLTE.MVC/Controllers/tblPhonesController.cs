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
    public class tblPhonesController : Controller
    {
        private readonly ApplicationDbContext db;

        public tblPhonesController(ApplicationDbContext context)
        {
            db = context;
        }

        // GET: tblPhones
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = db.tblPhone.Include(t => t.tbllocation);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: tblPhones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblPhone = await db.tblPhone
                .Include(t => t.tbllocation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblPhone == null)
            {
                return NotFound();
            }

            return View(tblPhone);
        }

        // GET: tblPhones/Create
        public IActionResult Create()
        {
            ViewData["locid"] = new SelectList(db.tbllocation, "locationId", "city");
            return View();
        }

        // POST: tblPhones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PhoneNo,locid")] tblPhone tblPhone)
        {
            if (ModelState.IsValid)
            {
                db.Add(tblPhone);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["locid"] = new SelectList(db.tbllocation, "locationId", "city", tblPhone.locid);
            return View(tblPhone);
        }

        // GET: tblPhones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblPhone = await db.tblPhone.FindAsync(id);
            if (tblPhone == null)
            {
                return NotFound();
            }
            ViewData["locid"] = new SelectList(db.tbllocation, "locationId", "city", tblPhone.locid);
            return View(tblPhone);
        }

        // POST: tblPhones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PhoneNo,locid")] tblPhone tblPhone)
        {
            if (id != tblPhone.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(tblPhone);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!tblPhoneExists(tblPhone.Id))
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
            ViewData["locid"] = new SelectList(db.tbllocation, "locationId", "city", tblPhone.locid);
            return View(tblPhone);
        }

        // GET: tblPhones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblPhone = await db.tblPhone
                .Include(t => t.tbllocation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblPhone == null)
            {
                return NotFound();
            }

            return View(tblPhone);
        }

        // POST: tblPhones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblPhone = await db.tblPhone.FindAsync(id);
            db.tblPhone.Remove(tblPhone);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tblPhoneExists(int id)
        {
            return db.tblPhone.Any(e => e.Id == id);
        }
    }
}
