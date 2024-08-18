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

        public async Task<IActionResult> Index(int? id)
        {
            const int NumGamesToDisplayPerPage = 3;
            const int PageOffset = 1; // Need a page offset to start at 1

            int currentPage = id ?? 1; // set currentPage to id, if id is null, use 1

            // Get the total number of products out of the database
            int totalNumOfProducts = await _context.Games.CountAsync();
            double maxNumPages = Math.Ceiling((double)totalNumOfProducts / NumGamesToDisplayPerPage);
            int lastPage = Convert.ToInt32(maxNumPages); // Rounding pages up to the nearest whole number

            List<Game> games = await (from game in _context.Games
                                      select game)
                                      .Skip(NumGamesToDisplayPerPage * (currentPage - PageOffset))
                                      .Take(NumGamesToDisplayPerPage)
                                      .ToListAsync();

            GameCatalogViewModel catalogModel = new GameCatalogViewModel(games, lastPage, currentPage);
            return View(catalogModel);
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

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Game? gameToEdit = await _context.Games.FindAsync(id);

            if (gameToEdit == null)
            {
                return NotFound();
            }

            return View(gameToEdit);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Game gameModel)
        {
            if (ModelState.IsValid)
            {
                _context.Games.Update(gameModel);   // Prepares update
                await _context.SaveChangesAsync();  // Executes pending update

                TempData["Message"] = $"{gameModel.Title} was updated successfully";
                return RedirectToAction("Index");
            }
            return View(gameModel);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            Game? gameToDelete = await _context.Games.FindAsync(id);

            if (gameToDelete == null)
            {
                return NotFound();
            }

            return View(gameToDelete);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Game gameToDelete = await _context.Games.FindAsync(id);

            if (gameToDelete != null)
            {
                _context.Games.Remove(gameToDelete);    // Prepares delete
                await _context.SaveChangesAsync();      // Executes pending delete

                TempData["Message"] = $"{gameToDelete.Title} was deleted successfully";
                return RedirectToAction("Index");
            }

            TempData["Message"] = "This game was already deleted";
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(int id)
        {
            Game? gameDetails = await _context.Games.FindAsync(id);
            
            if (gameDetails == null)
            {
                return NotFound();
            }
            return View(gameDetails);
        }
    }
}