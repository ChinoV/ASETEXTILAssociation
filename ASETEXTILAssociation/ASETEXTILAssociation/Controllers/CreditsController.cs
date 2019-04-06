using ASETEXTILAssociation.Data;
using ASETEXTILAssociation.Models;
using ASETEXTILAssociation.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ASETEXTILAssociation.Controllers
{
    public class CreditsController : Controller
    {
        private readonly AContext _context;

        public CreditsController(AContext context)
        {
            _context = context;
        }

        // GET: Credits
        public async Task<IActionResult> Index()
        {
            return View(await _context.Credits.ToListAsync());
        }

        // GET: Credits/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var credit = await _context.Credits
                .FirstOrDefaultAsync(m => m.CreditId == id);
            if (credit == null)
            {
                return NotFound();
            }

            return View(credit);
        }

        // GET: Credits/Create
        public IActionResult Create()
        {
            try
            {
                return View(new CTVModel()
                {
                    CreditTypesObject = _context.CreditType.ToList(),
                    CreditTypes = _context.CreditType.Select(u => new SelectListItem()
                    {
                        Value = u.CreditTypeId.ToString(),
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

        // POST: Credits/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CTVModel model)
        {
            Random random = new Random();
            if (ModelState.IsValid)
            {
                var credit = new Credit
                {
                    Affiliate = _context.Affiliates.FirstOrDefault(a => a.AffiliateId == random.Next(2, 12)),
                    Amount = model.Amount,
                    Purpose = model.Purpose,
                    State = 1,
                    Aproved = false,
                    Type = _context.CreditType.SingleOrDefault(u => u.CreditTypeId == model.CreditTypeId)
                };
                _context.Add(credit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Credits/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var credit = await _context.Credits.FindAsync(id);
            if (credit == null)
            {
                return NotFound();
            }
            return View(credit);
        }

        // POST: Credits/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CreditId,State,Aproved,Purpose,Amount")] Credit credit)
        {
            if (id != credit.CreditId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(credit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CreditExists(credit.CreditId))
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
            return View(credit);
        }

        // GET: Credits/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var credit = await _context.Credits
                .FirstOrDefaultAsync(m => m.CreditId == id);
            if (credit == null)
            {
                return NotFound();
            }

            return View(credit);
        }

        // POST: Credits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var credit = await _context.Credits.FindAsync(id);
            _context.Credits.Remove(credit);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CreditExists(int id)
        {
            return _context.Credits.Any(e => e.CreditId == id);
        }
    }
}
