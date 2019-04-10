using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASETEXTILAssociation.Data;
using ASETEXTILAssociation.Models;
using ASETEXTILAssociation.ViewModels;


namespace ASETEXTILAssociation.Controllers
{
    public class SavingsController : Controller
    {
        private readonly AContext _context;

        public SavingsController(AContext context)
        {
            _context = context;
        }

        // GET: Savings
        public async Task<IActionResult> Index()
        {
            return View(await _context.Savings.ToListAsync());
        }

        // GET: Savings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var saving = await _context.Savings
                .FirstOrDefaultAsync(m => m.SavingId == id);
            if (saving == null)
            {
                return NotFound();
            }

            return View(saving);
        }

        // GET: Savings/Create
        public IActionResult Create()
        {
            try
            {
                return View(new SavingsViewModel()
                {
                    SavingTypesObject = _context.SavingType.ToList(),
                    SavingTypes = _context.SavingType.Select(u => new SelectListItem()
                    {
                        Value = u.SavingTypeId.ToString(),
                        Text = u.Name
                    }).ToList()
                });
            }
            catch
            {
                return View();
            }
            //return View(await _context.CreditType.ToListAsync());
        }

        // POST: Savings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SavingsViewModel model)
        {
            if (ModelState.IsValid)
            {
                var saving = new Saving
                {
                    Amount = model.Amount,
                    Type = _context.SavingType.SingleOrDefault(u => u.SavingTypeId == model.SavingTypeId)
                };
                _context.Add(saving);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Savings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var saving = await _context.Savings.FindAsync(id);
            if (saving == null)
            {
                return NotFound();
            }
            return View(saving);
        }

        // POST: Savings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SavingId,Amount")] Saving saving)
        {
            if (id != saving.SavingId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(saving);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SavingExists(saving.SavingId))
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
            return View(saving);
        }

        // GET: Savings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var saving = await _context.Savings
                .FirstOrDefaultAsync(m => m.SavingId == id);
            if (saving == null)
            {
                return NotFound();
            }

            return View(saving);
        }

        // POST: Savings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var saving = await _context.Savings.FindAsync(id);
            _context.Savings.Remove(saving);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SavingExists(int id)
        {
            return _context.Savings.Any(e => e.SavingId == id);
        }
    }
}
