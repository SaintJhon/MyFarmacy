using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaFarmacia.Services.Abstractions;
using SistemaFarmacia.DTOs.Producto;

namespace SistemaFarmacia.Controllers
{
	public class ProductosController : Controller
	{
		private readonly IProductosService _productosService;

		public ProductosController(IProductosService productosService)
		{
			_productosService = productosService;
		}

		public async Task<IActionResult> Index(string? search)
		{
			string rol = HttpContext.Session.GetString("Rol");

			if (string.IsNullOrEmpty(rol))
			{
				return RedirectToAction("Index", "Home");
			}

			var productos = await _productosService.SearchAsync(search);

			ViewBag.Rol = rol;
			ViewBag.Search = search;

			return View(productos);
		}

		public IActionResult Create()
		{
			string rol = HttpContext.Session.GetString("Rol");

			if (rol != "Administrador" && rol != "Empleado")
			{
				return RedirectToAction(nameof(Index));
			}

			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create(CreateProductoDTO dto)
		{
			string rol = HttpContext.Session.GetString("Rol");

			if (rol != "Administrador" && rol != "Empleado")
			{
				return RedirectToAction(nameof(Index));
			}

			await _productosService.CreateAsync(dto);

			return RedirectToAction(nameof(Index));
		}

		public async Task<IActionResult> Edit(int id)
		{
			string rol = HttpContext.Session.GetString("Rol");

			if (rol != "Administrador" && rol != "Empleado")
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
			string rol = HttpContext.Session.GetString("Rol");

			if (rol != "Administrador" && rol != "Empleado")
			{
				return RedirectToAction(nameof(Index));
			}

			await _productosService.UpdateAsync(dto);

			return RedirectToAction(nameof(Index));
		}

		[HttpPost]
		public async Task<IActionResult> Delete(int id)
		{
			string rol = HttpContext.Session.GetString("Rol");

			if (rol != "Administrador")
			{
				return RedirectToAction(nameof(Index));
			}

			await _productosService.DeleteAsync(id);

			return RedirectToAction(nameof(Index));
		}
	}
}