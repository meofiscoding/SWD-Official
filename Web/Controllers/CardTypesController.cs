using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using App.DAL.DataContext;
using App.DAL.Entity;
using Humanizer;
using Microsoft.AspNetCore.Authorization;
using App.BLL.Services.Contracts;

namespace Web.Controllers
{
    public class CardTypesController : Controller
    {
        private readonly CMCContext _context;

        private readonly ICardTypeService _cardTypeService;
        private readonly ICardTemplateService _cardTemplateService;

        private readonly IWebHostEnvironment _webHostEnvironment;

        public CardTypesController(CMCContext context, ICardTypeService cardTypeService, ICardTemplateService cardTemplateService, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _cardTypeService = cardTypeService;
            _cardTemplateService = cardTemplateService;
            _webHostEnvironment = webHostEnvironment;
        } 
         
        // GET: CardTypes
        public async Task<IActionResult> Index()
        {
            return View(await _cardTypeService.GetCardTypesAsync());
        }

        // GET: CardTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ViewBag.TypeName = _cardTypeService.GetCardTypeName(id);
            var templateCards = _cardTemplateService.GetCardTemplatesByCardType(id);
            if (templateCards == null)
            {
                return NotFound();
            }

            return View(templateCards);
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
                await  _cardTypeService.CreateCard(cardType); 
                return RedirectToAction(nameof(Index));
            }
            return View(cardType);
        }

        // GET: CardTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cardType = _cardTypeService.FindCardTypes(id);
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
        public async Task<IActionResult> Edit(int id, [Bind("TypeId,TypeName,Detail")] CardType cardType)
        {
            if (id != cardType.TypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    cardType.Status = 1;
                    await _cardTypeService.UpdateCard(cardType);
                }
                catch (Exception)
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

        // POST: CardTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CardTypes == null)
            {
                return Problem("Entity set 'CMCContext.CardTypes'  is null.");
            }
            var cardType = _cardTypeService.FindCardTypes(id);
            if (cardType != null)
            {
                string webRootPath = _webHostEnvironment.WebRootPath;
                var path = Path.Combine(webRootPath + "\\Uploads\\" + _cardTypeService.FindCardTypes(id).TypeName);
                if (Directory.Exists(Path.GetDirectoryName(path))) {
                    try
                    {
                        Directory.Delete(path,true);
                    }
                    catch (Exception)
                    {
                        Thread.Sleep(2000);     //wait 2 seconds
                        Directory.Delete(path, recursive: true);
                    }
                }
                cardType.Status = 0;
            }
            else
            {
                return NotFound();
            }
            await _cardTypeService.UpdateCard(cardType); 
            return RedirectToAction(nameof(Index));
        }

        private bool CardTypeExists(int id)
        {
            return _cardTypeService.IsExistCardTypes(id); 
        }
    }
}
