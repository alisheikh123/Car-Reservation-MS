﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AdminLTE.MVC.Data;
using AdminLTE.MVC.Models;
using Microsoft.AspNetCore.Authorization;

namespace AdminLTE.MVC.Controllers
{
    [AllowAnonymous]
    public class tblCitiesController : Controller
    {
        private readonly ApplicationDbContext db;

        public tblCitiesController(ApplicationDbContext context)
        {
            db = context;
        }

        // GET: tblCities
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = db.tblCity.Include(t => t.tblState);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: tblCities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblCity = await db.tblCity
                .Include(t => t.tblState)
                .FirstOrDefaultAsync(m => m.city_Id == id);
            if (tblCity == null)
            {
                return NotFound();
            }

            return View(tblCity);
        }

        // GET: tblCities/Create
        public IActionResult Create()
        {
            ViewData["state_Id"] = new SelectList(db.tblState, "state_Id", "State");
            return View();
        }

        // POST: tblCities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("city_Id,state_Id,City")] tblCity tblCity)
        {
            if (ModelState.IsValid)
            {
                db.Add(tblCity);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["state_Id"] = new SelectList(db.tblState, "state_Id", "state_Id", tblCity.state_Id);
            return View(tblCity);
        }

        // GET: tblCities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblCity = await db.tblCity.FindAsync(id);
            if (tblCity == null)
            {
                return NotFound();
            }
            ViewData["state_Id"] = new SelectList(db.tblState, "state_Id", "state_Id", tblCity.state_Id);
            return View(tblCity);
        }

        // POST: tblCities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("city_Id,state_Id,City")] tblCity tblCity)
        {
            if (id != tblCity.city_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(tblCity);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!tblCityExists(tblCity.city_Id))
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
            ViewData["state_Id"] = new SelectList(db.tblState, "state_Id", "state_Id", tblCity.state_Id);
            return View(tblCity);
        }

        // GET: tblCities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblCity = await db.tblCity
                .Include(t => t.tblState)
                .FirstOrDefaultAsync(m => m.city_Id == id);
            if (tblCity == null)
            {
                return NotFound();
            }

            return View(tblCity);
        }

        // POST: tblCities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblCity = await db.tblCity.FindAsync(id);
            db.tblCity.Remove(tblCity);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tblCityExists(int id)
        {
            return db.tblCity.Any(e => e.city_Id == id);
        }
    }
}
