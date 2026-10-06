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
            string rol = "";

            if (correo == "admin@farmacia.com" && password == "1234")
            {
                rol = "Administrador";
            }
            else if (correo == "empleado@farmacia.com" && password == "abcd")
            {
                rol = "Empleado";
            }
            else if (correo == "cliente@farmacia.com" && password == "0000")
            {
                rol = "Cliente";
            }
            else
            {
                ViewBag.Error = "Correo o contrasenia incorrectos";
                return View("Index");
            }

            HttpContext.Session.SetString("RolUsuario", rol);
            HttpContext.Session.SetString("CorreoUsuario", correo);

            return RedirectToAction("Index", "Productos");
        }
    }
}