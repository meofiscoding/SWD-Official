using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Web.Models;
using App.BLL.Services.Contracts;
using App.DAL.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICardService _cardService;

        public HomeController(ICardService cardService)
        {
            this._cardService = cardService;
        }

        public IActionResult Index()
        {
            return View();
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