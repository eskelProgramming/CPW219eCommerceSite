using CPW219eCommerceSite.Data;
using CPW219eCommerceSite.Models;
using Microsoft.AspNetCore.Mvc;

namespace CPW219eCommerceSite.Controllers
{
    public class MembersController : Controller
    {
        private readonly VideoGameContext _context;

        public MembersController(VideoGameContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel regModel)
        {
            if (ModelState.IsValid)
            {
                // Map RegisterViewModel data to Member object
                Member member = new Member
                {
                    Email = regModel.Email,
                    Password = regModel.Password
                };

                _context.Members.Add(member);
                await _context.SaveChangesAsync();

                // Redirect to the home page
                return RedirectToAction("Index", "Home");
            }
            return View(regModel);
        }
    }
}
