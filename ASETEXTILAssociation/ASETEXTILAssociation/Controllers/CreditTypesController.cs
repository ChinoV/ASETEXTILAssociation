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
    public class CreditTypesController : Controller
    {
        private readonly AContext _context;

        public CreditTypesController(AContext context)
        {
            _context = context;
        }

        // GET: CreditTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.CreditType.ToListAsync());
        }

        // GET: CreditTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var creditType = await _context.CreditType
                .FirstOrDefaultAsync(m => m.CreditTypeId == id);
            if (creditType == null)
            {
                return NotFound();
            }

            return View(creditType);
        }

        // GET: CreditTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CreditTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CreditTypeId,Name,MonthTerm,Interest")] CreditType creditType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(creditType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(creditType);
        }

        // GET: CreditTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var creditType = await _context.CreditType.FindAsync(id);
            if (creditType == null)
            {
                return NotFound();
            }
            return View(creditType);
        }

        // POST: CreditTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CreditTypeId,Name,MonthTerm,Interest")] CreditType creditType)
        {
            if (id != creditType.CreditTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(creditType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CreditTypeExists(creditType.CreditTypeId))
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
            return View(creditType);
        }

        // GET: CreditTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var creditType = await _context.CreditType
                .FirstOrDefaultAsync(m => m.CreditTypeId == id);
            if (creditType == null)
            {
                return NotFound();
            }

            return View(creditType);
        }

        // POST: CreditTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var creditType = await _context.CreditType.FindAsync(id);
            _context.CreditType.Remove(creditType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CreditTypeExists(int id)
        {
            return _context.CreditType.Any(e => e.CreditTypeId == id);
        }
    }
}
