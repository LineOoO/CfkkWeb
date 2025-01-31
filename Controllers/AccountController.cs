using CfkkWeb.Builders;
using CfkkWeb.Command;
using CfkkWeb.Helpers;
using CfkkWeb.Mappings;
using CfkkWeb.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MySqlX.XDevAPI;
using NHibernate.Criterion;
using System.Security.Claims;
using ISession = NHibernate.ISession;

namespace CfkkWeb.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;

        private readonly ISession session = NhibernateHelper.OpenSession();

        public AccountController(ILogger<AccountController> logger)
        {
            _logger = logger;
            
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            var user = session.Query<User>().FirstOrDefault(u => u.Username == username);

            if (user == null || !VerifyPassword(user.PasswordHash, password))
            {
                ModelState.AddModelError("", "Nesprávné jméno nebo heslo");
                return View();
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username),

            };

            if (user.IsAdmin)
            {
                claims.Add(new Claim(ClaimTypes.Role, "Admin"));
            }

            var identity = new ClaimsIdentity(claims, "CookieAuth");
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync("CookieAuth", principal);
            return RedirectToAction("Index", "Home");
        }

        private bool VerifyPassword(string passwordHash, string password)
        {
            var hasher = new PasswordHasher<string>();
            return hasher.VerifyHashedPassword(null, passwordHash, password) != PasswordVerificationResult.Failed;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            Console.WriteLine("Logout action triggered.");
            await HttpContext.SignOutAsync("CookieAuth");
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
