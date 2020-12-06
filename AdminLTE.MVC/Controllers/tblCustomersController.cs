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
        private readonly ApplicationDbContext _context;

        public tblCustomersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: tblCustomers
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.tblCustomer.Include(t => t.tblCity);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: tblCustomers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblCustomer = await _context.tblCustomer
                .Include(t => t.tblCity)
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
            ViewData["city"] = new SelectList(_context.tblCity, "city_Id", "city_Id");
            return View();
        }

        // POST: tblCustomers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("cusid,First_Name,Last_Name,Email,CNIC,mobileno,city,state,country")] tblCustomer tblCustomer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblCustomer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["city"] = new SelectList(_context.tblCity, "city_Id", "city_Id", tblCustomer.city);
            return View(tblCustomer);
        }

        // GET: tblCustomers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblCustomer = await _context.tblCustomer.FindAsync(id);
            if (tblCustomer == null)
            {
                return NotFound();
            }
            ViewData["city"] = new SelectList(_context.tblCity, "city_Id", "city_Id", tblCustomer.city);
            return View(tblCustomer);
        }

        // POST: tblCustomers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("cusid,First_Name,Last_Name,Email,CNIC,mobileno,city,state,country")] tblCustomer tblCustomer)
        {
            if (id != tblCustomer.cusid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblCustomer);
                    await _context.SaveChangesAsync();
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
            ViewData["city"] = new SelectList(_context.tblCity, "city_Id", "city_Id", tblCustomer.city);
            return View(tblCustomer);
        }

        // GET: tblCustomers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblCustomer = await _context.tblCustomer
                .Include(t => t.tblCity)
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
            var tblCustomer = await _context.tblCustomer.FindAsync(id);
            _context.tblCustomer.Remove(tblCustomer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tblCustomerExists(int id)
        {
            return _context.tblCustomer.Any(e => e.cusid == id);
        }
    }
}
