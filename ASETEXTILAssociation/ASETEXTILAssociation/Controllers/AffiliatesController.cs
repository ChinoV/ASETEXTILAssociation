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
    public class AffiliatesController : Controller
    {
        private readonly AContext _context;

        public AffiliatesController(AContext context)
        {
            _context = context;
        }

        // GET: Affiliates
        public async Task<IActionResult> Index()
        {
            return View(await _context.Affiliates.ToListAsync());
        }

        // GET: Affiliates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var affiliate = await _context.Affiliates
                .FirstOrDefaultAsync(m => m.AffiliateId == id);
            if (affiliate == null)
            {
                return NotFound();
            }

            return View(affiliate);
        }

        // GET: Affiliates/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Affiliates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AffiliateId,Name,LastName,BirthDate,AdmissionDate,JobPosition,NetSalary")] Affiliate affiliate)
        {
            if (ModelState.IsValid)
            {
                _context.Add(affiliate);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(affiliate);
        }

        // GET: Affiliates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var affiliate = await _context.Affiliates.FindAsync(id);
            if (affiliate == null)
            {
                return NotFound();
            }
            return View(affiliate);
        }

        // POST: Affiliates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AffiliateId,Name,LastName,BirthDate,AdmissionDate,JobPosition,NetSalary")] Affiliate affiliate)
        {
            if (id != affiliate.AffiliateId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(affiliate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AffiliateExists(affiliate.AffiliateId))
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
            return View(affiliate);
        }

        // GET: Affiliates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var affiliate = await _context.Affiliates
                .FirstOrDefaultAsync(m => m.AffiliateId == id);
            if (affiliate == null)
            {
                return NotFound();
            }

            return View(affiliate);
        }

        // POST: Affiliates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var affiliate = await _context.Affiliates.FindAsync(id);
            _context.Affiliates.Remove(affiliate);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AffiliateExists(int id)
        {
            return _context.Affiliates.Any(e => e.AffiliateId == id);
        }
    }
}
