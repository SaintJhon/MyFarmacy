using Microsoft.AspNetCore.Mvc;
using PharmacySystem.Services.Abstractions;
using PharmacySystem.DTOs.Sucursal;

namespace PharmacySystem.Controllers
{
	public class SucursalesController : Controller
	{
		private readonly ISucursalesService _sucursalesService;

		public SucursalesController(ISucursalesService sucursalesService)
		{
			_sucursalesService = sucursalesService;
		}

		public async Task<IActionResult> Index()
		{
			var sucursales = await _sucursalesService.GetAllAsync();
			return View(sucursales);
		}

		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create(CreateSucursalDTO dto)
		{
			await _sucursalesService.CreateAsync(dto);
			return RedirectToAction(nameof(Index));
		}

		public async Task<IActionResult> Edit(int id)
		{
			var sucursal = await _sucursalesService.GetOneAsync(id);

			if (sucursal == null)
				return NotFound();

			return View(sucursal);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(SucursalDTO dto)
		{
			await _sucursalesService.UpdateAsync(dto);
			return RedirectToAction(nameof(Index));
		}

		public async Task<IActionResult> Delete(int id)
		{
			await _sucursalesService.DeleteAsync(id);
			return RedirectToAction(nameof(Index));
		}
	}
}