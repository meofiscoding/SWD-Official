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
    public class CardTypesController : Controller
    {
        private readonly CMCContext _context;

        public CardTypesController(CMCContext context)
        {
            _context = context;
        }

        // GET: CardTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.CardTypes.Where(m => m.Status == 1).ToListAsync());
        }

        // GET: CardTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CardTypes == null)
            {
                return NotFound();
            }

            var cardType = await _context.CardTypes
                .FirstOrDefaultAsync(m => m.TypeId == id);
            if (cardType == null)
            {
                return NotFound();
            }

            return View(cardType);
        }

        // GET: CardTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CardTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TypeId,TypeName,Status,Detail")] CardType cardType)
        {
            if (ModelState.IsValid)
            {
                cardType.Status = 1;
                _context.Add(cardType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cardType);
        }

        // GET: CardTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CardTypes == null)
            {
                return NotFound();
            }

            var cardType = await _context.CardTypes.FindAsync(id);
            if (cardType == null)
            {
                return NotFound();
            }
            return View(cardType);
        }

        // POST: CardTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TypeId,TypeName,Status")] CardType cardType)
        {
            if (id != cardType.TypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cardType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CardTypeExists(cardType.TypeId))
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
            return View(cardType);
        }

        //// GET: CardTypes/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null || _context.CardTypes == null)
        //    {
        //        return NotFound();
        //    }

        //    var cardType = await _context.CardTypes
        //        .FirstOrDefaultAsync(m => m.TypeId == id);
        //    if (cardType == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(cardType);
        //}

        // POST: CardTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CardTypes == null)
            {
                return Problem("Entity set 'CMCContext.CardTypes'  is null.");
            }
            var cardType = await _context.CardTypes.FirstOrDefaultAsync(m => m.TypeId == id);
            if (cardType != null)
            {
                //_context.CardTypes.Remove(cardType);
                cardType.Status = 0;
                _context.Update(cardType);
            }
            else
            {
                return NotFound();
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CardTypeExists(int id)
        {
            return _context.CardTypes.Any(e => e.TypeId == id);
        }
    }
}
