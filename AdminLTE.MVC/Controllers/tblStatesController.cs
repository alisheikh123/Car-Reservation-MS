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
    public class tblStatesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public tblStatesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: tblStates
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.tblState.Include(t => t.tblCountry);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: tblStates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblState = await _context.tblState
                .Include(t => t.tblCountry)
                .FirstOrDefaultAsync(m => m.state_Id == id);
            if (tblState == null)
            {
                return NotFound();
            }

            return View(tblState);
        }

        // GET: tblStates/Create
        public IActionResult Create()
        {
            ViewData["country_Id"] = new SelectList(_context.tblCountry, "country_Id", "country_Name");
            return View();
        }

        // POST: tblStates/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("state_Id,country_Id,State")] tblState tblState)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblState);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["country_Id"] = new SelectList(_context.tblCountry, "country_Id", "country_Name", tblState.country_Id);
            return View(tblState);
        }

        // GET: tblStates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblState = await _context.tblState.FindAsync(id);
            if (tblState == null)
            {
                return NotFound();
            }
            ViewData["country_Id"] = new SelectList(_context.tblCountry, "country_Id", "country_Name", tblState.country_Id);
            return View(tblState);
        }

        // POST: tblStates/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("state_Id,country_Id,State")] tblState tblState)
        {
            if (id != tblState.state_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblState);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!tblStateExists(tblState.state_Id))
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
            ViewData["country_Id"] = new SelectList(_context.tblCountry, "country_Id", "country_Name", tblState.country_Id);
            return View(tblState);
        }

        // GET: tblStates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblState = await _context.tblState
                .Include(t => t.tblCountry)
                .FirstOrDefaultAsync(m => m.state_Id == id);
            if (tblState == null)
            {
                return NotFound();
            }

            return View(tblState);
        }

        // POST: tblStates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblState = await _context.tblState.FindAsync(id);
            _context.tblState.Remove(tblState);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tblStateExists(int id)
        {
            return _context.tblState.Any(e => e.state_Id == id);
        }
    }
}
