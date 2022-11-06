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
using Web.Models;
using App.BLL.DTO;

namespace Web.Controllers
{
    public class CardTypesController : Controller
    {

        private readonly ICardTypeService _cardTypeService;
        private readonly ICardTemplateService _cardTemplateService;

        private readonly IWebHostEnvironment _webHostEnvironment;

        public CardTypesController(ICardTypeService cardTypeService, ICardTemplateService cardTemplateService, IWebHostEnvironment webHostEnvironment)
        {
            _cardTypeService = cardTypeService;
            _cardTemplateService = cardTemplateService;
            _webHostEnvironment = webHostEnvironment;
        } 

         // GET: CardTypes
        public async Task<IActionResult> Index()
        {
            var cardTypes = await _cardTypeService.GetCardTypesAsync();
            //convert cardTypes to list of CardTypeViewModel
            var cardTypeViewModels = cardTypes.Select(c => new CardTypeViewModel
            {
                TypeId = c.TypeId,
                TypeName = c.TypeName,
                Detail = c.Detail,
                TemplateId = c.TemplateID,
                CardTypeUpdatedAt = c.UpdatedAt
            }).ToList();  
            return View(cardTypeViewModels);
        }

        // GET: CardTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        { 
            ViewBag.TypeName = _cardTypeService.GetCardTypeName(id);
            var templateCards = _cardTemplateService.GetCardTemplatesByTypes(id);
            //convert list templateCards to list CardTypeViewModel
            var cardTypeViewModels = templateCards.Select(c => new CardTypeViewModel
            {
                Title = c.Title,
                Price = c.Price,
                TemplateCardStatus = c.Status,
                TemplateId = c.TemplateId
            }).ToList(); 

            return View(cardTypeViewModels);
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
        public async Task<IActionResult> Create([Bind("TypeId,TypeName,CardTypeStatus,Detail")] CardTypeViewModel cardType)
        {
            if (ModelState.IsValid)
            {
                cardType.CardTypeStatus = 1;
                //convert cardType to cardTypeDTO
                var cardTypeDTO = new CardTypeDTO
                {
                    TypeName = cardType.TypeName,
                    Detail = cardType.Detail,
                    Status = cardType.CardTypeStatus
                };
                await  _cardTypeService.CreateCard(cardTypeDTO); 
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
            //convert cardType to cardTypeViewModel
            var cardTypeViewModel = new CardTypeViewModel
            {
                TypeId = cardType.TypeId,
                TypeName = cardType.TypeName,
                Detail = cardType.Detail,
                CardTypeStatus = cardType.Status
            };
            if (cardTypeViewModel == null)
            {
                return NotFound();
            }
            return View(cardTypeViewModel);
        }

        // POST: CardTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TypeId,TypeName,Detail")] CardTypeViewModel cardType)
        {
            if (id != cardType.TypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    cardType.CardTypeStatus = 1;
                    //convert cardType to cardTypeDTO
                    var cardTypeDTO = new CardTypeDTO
                    {
                        TypeId = cardType.TypeId,
                        TypeName = cardType.TypeName,
                        Detail = cardType.Detail,
                        Status = cardType.CardTypeStatus
                    };
                    await _cardTypeService.UpdateCard(cardTypeDTO);
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
            var cardType = _cardTypeService.FindCardTypes(id);
            if (cardType != null)
            {
                string webRootPath = _webHostEnvironment.WebRootPath;
                var path = Path.Combine(webRootPath + "\\Uploads\\" + _cardTypeService.FindCardTypes(id).TypeName);
                if (Directory.Exists(path)) {
                    try
                    {
                        Directory.Delete(path,true);
                    }
                    catch (Exception)
                    {
                        Thread.Sleep(1000);     //wait 2 seconds
                        Directory.Delete(path, recursive: true);
                    }
                }
            }
            else
            {
                return NotFound();
            }
            await _cardTypeService.Delete(id); 
            return RedirectToAction(nameof(Index));
        }

        private bool CardTypeExists(int id)
        {
            return _cardTypeService.IsExistCardTypes(id); 
        }
    }
}
