using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Web.Models;
using App.BLL.Services.Contracts;
using App.DAL.Entity;
using Microsoft.AspNetCore.Authorization;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICardTemplateService _cardService;
        public HomeController(ICardTemplateService cardService)
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}