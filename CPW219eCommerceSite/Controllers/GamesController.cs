using CPW219eCommerceSite.Data;
using CPW219eCommerceSite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client.Extensions.Msal;

namespace CPW219eCommerceSite.Controllers
{
    public class GamesController : Controller
    {
        private readonly VideoGameContext _context;

        public GamesController(VideoGameContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            List<Game> games = await _context.Games.ToListAsync();

            return View(games);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Game g)
        {
            if (ModelState.IsValid)
            {
                _context.Games.Add(g);              // Prepares insert
                await _context.SaveChangesAsync();  // Executes pending insert

                ViewData["Message"] = $"{g.Title} was added successfully";
                return View();
            }
            return View(g);
        }
    }
}