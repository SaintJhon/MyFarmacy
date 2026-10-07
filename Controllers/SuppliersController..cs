using Microsoft.AspNetCore.Mvc;
using SistemaFarmacia.Models;
using SistemaFarmacia.Services.Abstractions;

namespace SistemaFarmacia.Controllers
{
    public class SuppliersController : Controller
    {
        private readonly ISupplierService _supplierService;

        public SuppliersController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        // READ
        public IActionResult Index()
        {
            var suppliers = _supplierService.GetAll();

            return View(suppliers);
        }

        // CREATE - Show form
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // CREATE - Save supplier
        [HttpPost]
        public IActionResult Create(Supplier supplier)
        {
            if (!ModelState.IsValid)
            {
                return View(supplier);
            }

            var created = _supplierService.Create(supplier);

            if (!created)
            {
                ModelState.AddModelError(
                    "Nit",
                    "A supplier with this NIT already exists."
                );

                return View(supplier);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}