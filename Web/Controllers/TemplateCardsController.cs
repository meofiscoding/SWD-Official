using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using App.DAL.DataContext;
using App.DAL.Models;

namespace Web.Controllers
{
    public class TemplateCardsController : Controller
    {
        private readonly CmcContext _context;

        public TemplateCardsController(CmcContext context)
        {
            _context = context;
        }

        // GET: TemplateCards
        public async Task<IActionResult> Index()
        {
            var cmcContext = _context.TemplateCards.Include(t => t.Type);
            return View(await cmcContext.ToListAsync());
        }

        // GET: TemplateCards/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TemplateCards == null)
            {
                return NotFound();
            }

            var templateCard = await _context.TemplateCards
                .Include(t => t.Type)
                .FirstOrDefaultAsync(m => m.TemplateId == id);
            if (templateCard == null)
            {
                return NotFound();
            }

            return View(templateCard);
        }

        // GET: TemplateCards/Create
        public IActionResult Create()
        {
            ViewData["TypeId"] = new SelectList(_context.CardTypes, "TypeId", "TypeName");
            return View();
        }

        // POST: TemplateCards/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TemplateId,TypeId,Title,Price,Status")] TemplateCard templateCard)
        {
            if (ModelState.IsValid)
            {
                _context.Add(templateCard);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TypeId"] = new SelectList(_context.CardTypes, "TypeId", "TypeName", templateCard.TypeId);
            return View(templateCard);
        }

        // GET: TemplateCards/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TemplateCards == null)
            {
                return NotFound();
            }

            var templateCard = await _context.TemplateCards.FindAsync(id);
            if (templateCard == null)
            {
                return NotFound();
            }
            ViewData["TypeId"] = new SelectList(_context.CardTypes, "TypeId", "TypeName", templateCard.TypeId);
            return View(templateCard);
        }

        // POST: TemplateCards/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TemplateId,TypeId,Title,Price,Status")] TemplateCard templateCard)
        {
            if (id != templateCard.TemplateId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(templateCard);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TemplateCardExists(templateCard.TemplateId))
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
            ViewData["TypeId"] = new SelectList(_context.CardTypes, "TypeId", "TypeName", templateCard.TypeId);
            return View(templateCard);
        }

        // GET: TemplateCards/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TemplateCards == null)
            {
                return NotFound();
            }

            var templateCard = await _context.TemplateCards
                .Include(t => t.Type)
                .FirstOrDefaultAsync(m => m.TemplateId == id);
            if (templateCard == null)
            {
                return NotFound();
            }

            return View(templateCard);
        }

        // POST: TemplateCards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TemplateCards == null)
            {
                return Problem("Entity set 'CmcContext.TemplateCards'  is null.");
            }
            var templateCard = await _context.TemplateCards.FindAsync(id);
            if (templateCard != null)
            {
                _context.TemplateCards.Remove(templateCard);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TemplateCardExists(int id)
        {
          return _context.TemplateCards.Any(e => e.TemplateId == id);
        }
    }
}
