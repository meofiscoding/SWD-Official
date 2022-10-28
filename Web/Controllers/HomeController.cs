using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Web.Models;
using App.BLL.Services.Contracts;
using App.DAL.Models;
using Microsoft.AspNetCore.Authorization;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICardService _cardService;

        public HomeController(ICardService cardService)
        {
            this._cardService = cardService;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            //if session is null, redirect to login page
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                ViewBag.username = HttpContext.Session.GetString("username");
                return View("Index", "Home");
            }

        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> ShowCard()
        {
            List<Card> cards = await _cardService.GetCards();
            return View(cards);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}