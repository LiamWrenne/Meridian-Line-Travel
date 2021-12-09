using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Meridian_Line_Travel.Data;
using Meridian_Line_Travel.Models;
using Microsoft.AspNetCore.Authorization;

namespace Meridian_Line_Travel.Controllers
{
    public class PlanesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PlanesController(ApplicationDbContext context)
        {
            _context = context;
        }
        [Area("Admin")]
        [Authorize(Roles = "Admin")]
        // GET: Planes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Planes.ToListAsync());
        }

        // GET: Planes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var planes = await _context.Planes
                .FirstOrDefaultAsync(m => m.PlaneID == id);
            if (planes == null)
            {
                return NotFound();
            }

            return View(planes);
        }
        
        // GET: Planes/Create
        public IActionResult Create()
        {
            return View();
        }
        
        // POST: Planes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PlaneID,PlaneIDNum,SeatingCapacity,Assignment,AoO,AoD,FlightID,FlightIDNum,Type,PlaneName")] Planes planes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(planes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(planes);
        }
        
        // GET: Planes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var planes = await _context.Planes.FindAsync(id);
            if (planes == null)
            {
                return NotFound();
            }
            return View(planes);
        }
        
        // POST: Planes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("PlaneID,PlaneIDNum,SeatingCapacity,Assignment,AoO,AoD,FlightID,FlightIDNum,Type,PlaneName")] Planes planes)
        {
            if (id != planes.PlaneID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(planes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlanesExists(planes.PlaneID))
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
            return View(planes);
        }
        
        // GET: Planes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var planes = await _context.Planes
                .FirstOrDefaultAsync(m => m.PlaneID == id);
            if (planes == null)
            {
                return NotFound();
            }

            return View(planes);
        }
        
        // POST: Planes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var planes = await _context.Planes.FindAsync(id);
            _context.Planes.Remove(planes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlanesExists(string id)
        {
            return _context.Planes.Any(e => e.PlaneID == id);
        }
    }
}
