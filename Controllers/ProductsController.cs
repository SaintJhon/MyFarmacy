using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PharmacySystem.Services.Abstractions;
using PharmacySystem.DTOs.Producto;

namespace PharmacySystem.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductosService _productosService;

        public ProductsController(IProductosService productosService)
        {
            _productosService = productosService;
        }

        public async Task<IActionResult> Index(string? search)
        {
            string role = HttpContext.Session.GetString("Role");

            if (string.IsNullOrEmpty(role))
            {
                return RedirectToAction("Index", "Home");
            }

            var productos = await _productosService.SearchAsync(search);

            ViewBag.Role = role;
            ViewBag.Search = search;

            return View(productos);
        }

        public IActionResult Create()
        {
            string role = HttpContext.Session.GetString("Role");

            if (role != "Administrator" && role != "Employee")
            {
                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductoDTO dto)
        {
            string role = HttpContext.Session.GetString("Role");

            if (role != "Administrator" && role != "Employee")
            {
                return RedirectToAction(nameof(Index));
            }

            await _productosService.CreateAsync(dto);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            string role = HttpContext.Session.GetString("Role");

            if (role != "Administrator" && role != "Employee")
            {
                return RedirectToAction(nameof(Index));
            }

            var producto = await _productosService.GetOneAsync(id);

            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProductoDTO dto)
        {
            string role = HttpContext.Session.GetString("Role");

            if (role != "Administrator" && role != "Employee")
            {
                return RedirectToAction(nameof(Index));
            }

            await _productosService.UpdateAsync(dto);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            string role = HttpContext.Session.GetString("Role");

            if (role != "Administrator")
            {
                return RedirectToAction(nameof(Index));
            }

            await _productosService.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
