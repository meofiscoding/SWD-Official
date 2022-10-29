using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using App.DAL.Models;
using App.DAL.DataContext;

namespace Web.Controllers
{
    public class TemplateCardsController : Controller
    {
        private readonly CMCContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public TemplateCardsController(CMCContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
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
        public async Task<IActionResult> Create([Bind("TypeId,Title,Price")] TemplateCard templateCard, IFormFile FileUpload)
        {
            if (ModelState.IsValid)
            {
                var filename = "";
                if (FileUpload != null)
                {
                    //Store file in directory
                    string webRootPath = _webHostEnvironment.WebRootPath;
                    //string contentRootPath = _webHostEnvironment.ContentRootPath;
                    filename = FileUpload.FileName;
                    var path = Path.Combine(webRootPath + "\\Uploads\\" + _context.CardTypes.Find(templateCard.TypeId).TypeName, filename);
                    if (Directory.Exists(Path.GetDirectoryName(path)) == false) { Directory.CreateDirectory(Path.GetDirectoryName(path)); }
                    if (FileUpload.Length > 0)
                    {
                        using (Stream fileStream = new FileStream(path, FileMode.Create))
                        {
                            await FileUpload.CopyToAsync(fileStream);
                        }
                    }
                }
                templateCard.Status = 1;
                templateCard.FileName = filename;
                _context.Add(templateCard);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index","CardTypes");
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
        public async Task<IActionResult> Edit(int id, [Bind("TemplateId,TypeId,Title,Price,Status,FileName")] TemplateCard templateCard, IFormFile FileUpload)
        {
            if (id != templateCard.TemplateId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var filename = "";
                    if (string.IsNullOrEmpty(templateCard.FileName))
                    {
                        //Store file in directory
                        string webRootPath = _webHostEnvironment.WebRootPath;
                        //string contentRootPath = _webHostEnvironment.ContentRootPath;
                        filename = FileUpload.FileName;
                        var path = Path.Combine(webRootPath + "\\Uploads\\" + _context.CardTypes.Find(templateCard.TypeId).TypeName, filename);
                        if (Directory.Exists(Path.GetDirectoryName(path)) == false) { Directory.CreateDirectory(Path.GetDirectoryName(path)); }
                        if (FileUpload.Length > 0)
                        {
                            using (Stream fileStream = new FileStream(path, FileMode.Create))
                            {
                                await FileUpload.CopyToAsync(fileStream);
                            }
                        }
                    }
                    templateCard.FileName = filename;
                    templateCard.Status = 1;
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
                return RedirectToAction("Index", "CardTypes");
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
                return Problem("Entity set 'CMCContext.TemplateCards'  is null.");
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
