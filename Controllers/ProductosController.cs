using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using SistemaFarmacia.Models;
using System.Collections.Generic;
using System.Linq;

namespace SistemaFarmacia.Controllers
{
    public class ProductosController : Controller
    {
        // Lista estática vacía para ingresar los productos exclusivamente desde la web
        private static List<Producto> listaProductos = new List<Producto>();

        public IActionResult Index()
        {
            string rol = HttpContext.Session.GetString("Rol");

            if (string.IsNullOrEmpty(rol))
            {
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Rol = rol;
            return View(listaProductos);
        }

        [HttpPost]
        public IActionResult Registrar(string codigo, string nombre, string descripcion)
        {
            string rol = HttpContext.Session.GetString("Rol");

            if (rol != "Administrador" && rol != "Empleado")
            {
                return RedirectToAction("Index");
            }

            if (!string.IsNullOrEmpty(nombre))
            {
                int nuevoId = listaProductos.Count > 0 ? listaProductos.Max(p => p.Id) + 1 : 1;
                listaProductos.Add(new Producto
                {
                    Id = nuevoId,
                    Codigo = codigo ?? $"P00{nuevoId}",
                    Nombre = nombre,
                    Descripcion = descripcion
                });
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Eliminar(int id)
        {
            string rol = HttpContext.Session.GetString("Rol");

            if (rol == "Administrador")
            {
                var producto = listaProductos.FirstOrDefault(p => p.Id == id);
                if (producto != null)
                {
                    listaProductos.Remove(producto);
                }
            }

            return RedirectToAction("Index");
        }
    }
}