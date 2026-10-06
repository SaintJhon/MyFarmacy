using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using SistemaFarmacia.Models;
using System.Collections.Generic;
using System.Linq;

namespace SistemaFarmacia.Controllers
{
    public class ProductosController : Controller
    {
        private static List<Producto> listaProductos = new List<Producto>()
        {
            new Producto { Id = 1, Codigo = "P001", Nombre = "Paracetamol", Descripcion = "Analgesico" }
        };

        public IActionResult Index()
        {
            string rol = HttpContext.Session.GetString("RolUsuario") ?? "Cliente";
            ViewBag.Rol = rol;

            return View(listaProductos);
        }

        [HttpPost]
        public IActionResult Registrar(Producto prod)
        {
            prod.Id = listaProductos.Count > 0 ? listaProductos.Max(p => p.Id) + 1 : 1;
            listaProductos.Add(prod);
            return RedirectToAction("Index");
        }

        public IActionResult Eliminar(int id)
        {
            var prod = listaProductos.FirstOrDefault(p => p.Id == id);
            if (prod != null)
            {
                listaProductos.Remove(prod);
            }
            return RedirectToAction("Index");
        }
    }
}