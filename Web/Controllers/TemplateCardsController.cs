using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using App.DAL.Entity;
using App.DAL.DataContext;
using App.BLL.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using System.IO;

namespace Web.Controllers
{
    public class TemplateCardsController : Controller
    {
        private readonly CMCContext _context;
        private readonly ICardTemplateService _cardTemplateService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public TemplateCardsController(CMCContext context, ICardTemplateService cardTemplateService, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _cardTemplateService = cardTemplateService;
            _webHostEnvironment = webHostEnvironment;
        } 

        // GET: TemplateCards
        public async Task<IActionResult> Index()
        {
            return View(_cardTemplateService.GetCardTemplates());
        }

        // GET: TemplateCards/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            } 
            var templateCard = _cardTemplateService.GetDetailCardtemplateByType(id);
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
                await _cardTemplateService.AddCardTemplate(templateCard);
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

            var templateCard =  _cardTemplateService.FindTemplateCard(id);
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
        public async Task<IActionResult> Edit(int id, [Bind("TemplateId,TypeId,Title,Price,Status,FileName")] TemplateCard templateCard, IFormFile FileUpload, string deletedFile)
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
                    if (!string.IsNullOrEmpty(deletedFile))
                    {
                        //Store file in directory
                        string webRootPath = _webHostEnvironment.WebRootPath;
                        //string contentRootPath = _webHostEnvironment.ContentRootPath;
                        filename = FileUpload.FileName;
                        var path = Path.Combine(webRootPath + "\\Uploads\\" + _context.CardTypes.Find(templateCard.TypeId).TypeName, filename);
                        if (System.IO.File.Exists($"{path}\\{deletedFile}"))
                        {
                            System.IO.File.Delete($"{path}\\{deletedFile}");
                        }
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
                    await _cardTemplateService.UpdateCardTemplate(templateCard);
                    
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
                return RedirectToAction("Details", "CardTypes",new {id= templateCard.TypeId});
            }
            ViewData["TypeId"] = new SelectList(_context.CardTypes, "TypeId", "TypeName", templateCard.TypeId);
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
            var templateCard = _cardTemplateService.FindTemplateCard(id);
            if (templateCard != null)
            {
                await _cardTemplateService.RemoveCardTemplate(templateCard);
            }
            return RedirectToAction("Details", "CardTypes", new {id=templateCard.TypeId});
        }

        private bool TemplateCardExists(int id)
        {
          return _cardTemplateService.IsExist(id);
        }
    }
}
