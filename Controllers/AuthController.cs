using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PharmacySystem.Services.Abstractions;
using PharmacySystem.Data.Entities;

namespace PharmacySystem.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            var session = await _authService.LoginAsync(email, password);
            if (session == null)
            {
                ModelState.AddModelError(string.Empty, "Invalid credentials");
                return View();
            }

            HttpContext.Session.SetInt32("SessionId", session.Id);
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Logout()
        {
            var sid = HttpContext.Session.GetInt32("SessionId");
            if (sid.HasValue)
            {
                await _authService.LogoutAsync(sid.Value);
                HttpContext.Session.Remove("SessionId");
            }
            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(int userId, string currentPassword, string newPassword)
        {
            var ok = await _authService.ChangePasswordAsync(userId, currentPassword, newPassword);
            if (!ok) ModelState.AddModelError(string.Empty, "Could not change the password");
            return View();
        }

        [HttpGet]
        public IActionResult RecoverPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RecoverPassword(string email)
        {
            var ok = await _authService.RecoverPasswordAsync(email);
            if (!ok) ModelState.AddModelError(string.Empty, "Email not found");
            return View();
        }
    }
}
