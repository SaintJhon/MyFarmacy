using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace SistemaFarmacia.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string correo, string password)
        {
            // Validacion
            if (correo == "admin@farmacia.com" && password == "123")
            {
                HttpContext.Session.SetString("Rol", "Administrador");
                return RedirectToAction("Index", "Productos");
            }
            else if (correo == "empleado@farmacia.com" && password == "123")
            {
                HttpContext.Session.SetString("Rol", "Empleado");
                return RedirectToAction("Index", "Productos");
            }
            else if (correo == "cliente@farmacia.com" && password == "123")
            {
                HttpContext.Session.SetString("Rol", "Cliente");
                return RedirectToAction("Index", "Productos");
            }

            ViewBag.Error = "Datos incorrectos";
            return View("Index");
        }
    }
}