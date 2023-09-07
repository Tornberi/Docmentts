using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ImportXmlToJson.Data;
using ImportXmlToJson.Models;

namespace ImportXmlToJson.Controllers
{
    public class ImportsController : Controller
    {
        private readonly ImportXmlToJsonContext _context;

        public ImportsController(ImportXmlToJsonContext context)
        {
            _context = context;
        }

        // GET: Imports
        public async Task<IActionResult> Index()
        {
              return _context.Imports != null ? 
                          View(await _context.Imports.ToListAsync()) :
                          Problem("Entity set 'ImportXmlToJsonContext.Import'  is null.");
        }

        // GET: Imports/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Imports == null)
            {
                return NotFound();
            }

            var import = await _context.Imports
                .FirstOrDefaultAsync(m => m.Id == id);
            if (import == null)
            {
                return NotFound();
            }

            return View(import);
        }

        // GET: Imports/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Imports/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NameStage,StardDate,EndDate")] Imports import)
        {
            if (ModelState.IsValid)
            {
                _context.Add(import);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(import);
        }

        // GET: Imports/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Imports == null)
            {
                return NotFound();
            }

            var import = await _context.Imports.FindAsync(id);
            if (import == null)
            {
                return NotFound();
            }
            return View(import);
        }

        // POST: Imports/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NameStage,StardDate,EndDate")] Imports import)
        {
            if (id != import.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(import);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ImportExists(import.Id))
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
            return View(import);
        }

        // GET: Imports/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Imports == null)
            {
                return NotFound();
            }

            var import = await _context.Imports
                .FirstOrDefaultAsync(m => m.Id == id);
            if (import == null)
            {
                return NotFound();
            }

            return View(import);
        }

        // POST: Imports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Imports == null)
            {
                return Problem("Entity set 'ImportXmlToJsonContext.Import'  is null.");
            }
            var import = await _context.Imports.FindAsync(id);
            if (import != null)
            {
                _context.Imports.Remove(import);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ImportExists(int id)
        {
          return (_context.Imports?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
