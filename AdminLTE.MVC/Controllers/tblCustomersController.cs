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
    public class tblCustomersController : Controller
    {
        private readonly ApplicationDbContext db;

        public tblCustomersController(ApplicationDbContext context)
        {
            db = context;
        }

        // GET: tblCustomers
        public async Task<IActionResult> Index()
        {
            return View(await db.tblCustomer.ToListAsync());
        }

        // GET: tblCustomers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblCustomer = await db.tblCustomer
                .FirstOrDefaultAsync(m => m.cusid == id);
            if (tblCustomer == null)
            {
                return NotFound();
            }

            return View(tblCustomer);
        }

        // GET: tblCustomers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: tblCustomers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("cusid,First_Name,Last_Name,Email,CNIC,mobileno,state,country")] tblCustomer tblCustomer)
        {
            if (ModelState.IsValid)
            {
                db.Add(tblCustomer);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblCustomer);
        }

        // GET: tblCustomers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblCustomer = await db.tblCustomer.FindAsync(id);
            if (tblCustomer == null)
            {
                return NotFound();
            }
            return View(tblCustomer);
        }

        // POST: tblCustomers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("cusid,First_Name,Last_Name,Email,CNIC,mobileno,state,country")] tblCustomer tblCustomer)
        {
            if (id != tblCustomer.cusid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(tblCustomer);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!tblCustomerExists(tblCustomer.cusid))
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
            return View(tblCustomer);
        }

        // GET: tblCustomers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblCustomer = await db.tblCustomer
                .FirstOrDefaultAsync(m => m.cusid == id);
            if (tblCustomer == null)
            {
                return NotFound();
            }

            return View(tblCustomer);
        }

        // POST: tblCustomers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblCustomer = await db.tblCustomer.FindAsync(id);
            db.tblCustomer.Remove(tblCustomer);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tblCustomerExists(int id)
        {
            return db.tblCustomer.Any(e => e.cusid == id);
        }
    }
}
