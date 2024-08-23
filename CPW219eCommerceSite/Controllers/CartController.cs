using CPW219eCommerceSite.Data;
using CPW219eCommerceSite.Models;
using Microsoft.AspNetCore.Mvc;

namespace CPW219eCommerceSite.Controllers
{
    public class CartController : Controller
    {
        private readonly VideoGameContext _context;

        public CartController(VideoGameContext context)
        {
            _context = context;
        }

        public IActionResult Add(int id)
        {
            Game? gameToAdd = _context.Games.Where(g => g.GameId == id).SingleOrDefault();

            if (gameToAdd == null)
            {
                // Game with specified id was not found
                TempData["Message"] = $"Sorry, that game no longer exists";
                return RedirectToAction("Index", "Games");
            }

            // TOdo: Add game to a shopping cart cookie

            TempData["Message"] = $"{gameToAdd.Title} added to cart";
            return RedirectToAction("Index", "Games");
        }
    }
}
