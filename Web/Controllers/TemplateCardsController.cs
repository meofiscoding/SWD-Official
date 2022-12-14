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
using Web.Models;
using App.BLL.DTO;

namespace Web.Controllers
{
    public class TemplateCardsController : Controller
    {
        private readonly CMCContext _context;
        private readonly ICardTemplateService _cardTemplateService;
        private readonly ICardTypeService _cardTypeService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public TemplateCardsController(CMCContext context, ICardTemplateService cardTemplateService, ICardTypeService cardTypeService, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _cardTemplateService = cardTemplateService;
            _cardTypeService = cardTypeService;
            _webHostEnvironment = webHostEnvironment;
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
            //convert to TemplateCardviewModel
            var templateCardViewModel = new TemplateCardViewModel
            {
                TemplateId = templateCard.TemplateId,
                Title = templateCard.Title,
                TypeId = templateCard.TypeId,
                Price = templateCard.Price,
                Status = templateCard.Status,
                CreatedAt = templateCard.CreatedAt,
                UpdatedAt = templateCard.UpdatedAt,
                FileName = templateCard.FileName,
                TypeName = templateCard.TypeName
            }; 
            return View(templateCardViewModel);
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
        public async Task<IActionResult> Create([Bind("TypeId,Title,Price")] TemplateCardViewModel templateCard, IFormFile FileUpload)
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
                    var path = Path.Combine(webRootPath + "\\Uploads\\" + _cardTypeService.FindCardTypes(templateCard.TypeId).TypeName, filename);
                    if (Directory.Exists(path) == false) { Directory.CreateDirectory(Path.GetDirectoryName(path)); }
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
                //convert this templateCard to DTO 
                var templateCardDTO = new CardTemplateDTO
                {
                    TypeId = templateCard.TypeId,
                    Title = templateCard.Title,
                    Price = templateCard.Price,
                    Status = templateCard.Status,
                    FileName = templateCard.FileName
                };
                await _cardTemplateService.AddCardTemplate(templateCardDTO);
                return RedirectToAction("Index", "CardTypes");
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

            var templateCard = _cardTemplateService.FindTemplateCard(id);
            if (templateCard == null)
            {
                return NotFound();
            }
            ViewData["TypeId"] = new SelectList(_context.CardTypes, "TypeId", "TypeName", templateCard.TypeId);
            //convert to TemplateCardviewModel
            var templateCardViewModel = new TemplateCardViewModel
            {
                TemplateId = templateCard.TemplateId,
                Title = templateCard.Title,
                TypeId = templateCard.TypeId,
                Price = templateCard.Price,
                Status = templateCard.Status,
                CreatedAt = templateCard.CreatedAt,
                UpdatedAt = templateCard.UpdatedAt,
                FileName = templateCard.FileName,
                TypeName = templateCard.TypeName
            };
            return View(templateCardViewModel);
        }

        // POST: TemplateCards/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TemplateId,TypeId,Title,Price,Status,FileName")] TemplateCardViewModel templateCard, IFormFile FileUpload, string deletedFile)
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
                    //convert templateCard to DTO
                    var templateCardDTO = new CardTemplateDTO
                    {
                        TemplateId = templateCard.TemplateId,
                        TypeId = templateCard.TypeId,
                        Title = templateCard.Title,
                        Price = templateCard.Price,
                        Status = templateCard.Status,
                        FileName = templateCard.FileName
                    };
                    await _cardTemplateService.UpdateCardTemplate(templateCardDTO);

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
                return RedirectToAction("Details", "CardTypes", new { id = templateCard.TypeId });
            }
            ViewData["TypeId"] = new SelectList(_context.CardTypes, "TypeId", "TypeName", templateCard.TypeId);
            return View(templateCard);
        }

        // POST: TemplateCards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        { 
            var templateCard = _cardTemplateService.FindTemplateCard(id);
            if (templateCard != null)
            {
                await _cardTemplateService.RemoveCardTemplate(id);
            }
            return RedirectToAction("Details", "CardTypes", new { id = templateCard.TypeId });
        }

        private bool TemplateCardExists(int id)
        {
            return _cardTemplateService.IsExist(id);
        }
    }
}
