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

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel loginModel)
        {
            if (ModelState.IsValid)
            {
                // Check if the user is in the database
                Member? m = (from member in _context.Members
                                where member.Email == loginModel.Email
                                && member.Password == loginModel.Password
                                select member).SingleOrDefault();

                // If they are, redirect to the home page
                if (m!= null)
                {
                    HttpContext.Session.SetString("Email", loginModel.Email);
                    // Redirect to the home page
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError(string.Empty, "Credentials not found!");
            }
            // Return page if no record found or there are errors
            return View(loginModel);
        }
    }
}
