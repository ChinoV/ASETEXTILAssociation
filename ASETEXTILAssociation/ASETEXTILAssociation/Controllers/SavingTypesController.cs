using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASETEXTILAssociation.Data;
using ASETEXTILAssociation.Models;

namespace ASETEXTILAssociation.Controllers
{
    public class SavingTypesController : Controller
    {
        private readonly AContext _context;

        public SavingTypesController(AContext context)
        {
            _context = context;
        }

        // GET: SavingTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.SavingType.ToListAsync());
        }

        // GET: SavingTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var savingType = await _context.SavingType
                .FirstOrDefaultAsync(m => m.SavingTypeId == id);
            if (savingType == null)
            {
                return NotFound();
            }

            return View(savingType);
        }

        // GET: SavingTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SavingTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SavingTypeId,Name,MonthTerm,Interest")] SavingType savingType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(savingType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(savingType);
        }

        // GET: SavingTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var savingType = await _context.SavingType.FindAsync(id);
            if (savingType == null)
            {
                return NotFound();
            }
            return View(savingType);
        }

        // POST: SavingTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SavingTypeId,Name,MonthTerm,Interest")] SavingType savingType)
        {
            if (id != savingType.SavingTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(savingType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SavingTypeExists(savingType.SavingTypeId))
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
            return View(savingType);
        }

        // GET: SavingTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var savingType = await _context.SavingType
                .FirstOrDefaultAsync(m => m.SavingTypeId == id);
            if (savingType == null)
            {
                return NotFound();
            }

            return View(savingType);
        }

        // POST: SavingTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var savingType = await _context.SavingType.FindAsync(id);
            _context.SavingType.Remove(savingType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SavingTypeExists(int id)
        {
            return _context.SavingType.Any(e => e.SavingTypeId == id);
        }
    }
}
