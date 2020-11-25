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
    public class tblCategoriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public tblCategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }


        [AllowAnonymous]
        // GET: tblCategories
        public async Task<IActionResult> Index()
        {
            return View(await _context.tblCategories.ToListAsync());
        }

        [AllowAnonymous]
        // GET: tblCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblCategories = await _context.tblCategories
                .FirstOrDefaultAsync(m => m.catId == id);
            if (tblCategories == null)
            {
                return NotFound();
            }

            return View(tblCategories);
        }

        [AllowAnonymous]
        // GET: tblCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: tblCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("catId,Title,Description")] tblCategories tblCategories)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblCategories);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblCategories);
        }

        // GET: tblCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblCategories = await _context.tblCategories.FindAsync(id);
            if (tblCategories == null)
            {
                return NotFound();
            }
            return View(tblCategories);
        }

        // POST: tblCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("catId,Title,Description")] tblCategories tblCategories)
        {
            if (id != tblCategories.catId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblCategories);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!tblCategoriesExists(tblCategories.catId))
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
            return View(tblCategories);
        }

        // GET: tblCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblCategories = await _context.tblCategories
                .FirstOrDefaultAsync(m => m.catId == id);
            if (tblCategories == null)
            {
                return NotFound();
            }

            return View(tblCategories);
        }

        // POST: tblCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblCategories = await _context.tblCategories.FindAsync(id);
            _context.tblCategories.Remove(tblCategories);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tblCategoriesExists(int id)
        {
            return _context.tblCategories.Any(e => e.catId == id);
        }
    }
}
