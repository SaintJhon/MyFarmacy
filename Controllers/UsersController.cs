using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PharmacySystem.Services.Abstractions;
using PharmacySystem.Data.Entities;

namespace PharmacySystem.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _usersService.GetAllAsync();
            return View(list);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(User user, string password)
        {
            if (!ModelState.IsValid) return View(user);
            await _usersService.CreateAsync(user, password);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var u = await _usersService.GetByIdAsync(id);
            if (u == null) return NotFound();
            return View(u);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, User user)
        {
            if (!ModelState.IsValid) return View(user);
            var updated = await _usersService.UpdateAsync(id, user);
            if (updated == null) return NotFound();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _usersService.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
