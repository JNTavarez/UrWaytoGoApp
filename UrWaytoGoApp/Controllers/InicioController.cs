using Microsoft.AspNetCore.Mvc;

using UrWaytoGoApp.Models;
using UrWaytoGoApp.Recursos;
using UrWaytoGoApp.Servicios.Contrato;

using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace UrWaytoGoApp.Controllers
{
    public class InicioController : Controller
    {
        private readonly IUsuarioService _usuarioServico;

        public InicioController(IUsuarioService usuarioServico)
        {
            _usuarioServico = usuarioServico;
        }
        
        public IActionResult Registrarse()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registrarse(Usuario modelo)
        {
            modelo.PasswordUsuario = Utilidades.EncriptarClave(modelo.PasswordUsuario);

            Usuario usuarioCreado = await _usuarioServico.SaveUsuario(modelo);

            if (usuarioCreado.IdUsuario > 0)
                return RedirectToAction("IniciarSesion", "Inicio");

            ViewData["Mensaje"] = "No se pudo crear el usuario";
            return View();
        }

        public IActionResult IniciarSesion()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> IniciarSesion(string correo, string clave)
        {
            Usuario usuarioEncontrado = await _usuarioServico.GetUsuarios(correo, Utilidades.EncriptarClave(clave));

            if(usuarioEncontrado == null)
            {
                ViewData["Mensaje"] = "No se pudo encontrar el usuario";
                return View();
            }

            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, usuarioEncontrado.NombreUsuario)
            };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            AuthenticationProperties properties = new AuthenticationProperties()
            {
                AllowRefresh = true
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                properties);
                

            return RedirectToAction("Index", "Home");
        }
    }
}
