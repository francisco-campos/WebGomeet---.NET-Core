using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Authentication;
using Microsoft.AspNetCore.Mvc;
using WebGomeet.Models;

namespace WebGomeet.Controllers
{
    [AllowAnonymousAttribute]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Accion"] = "Registro";

            return View();
        }

        public IActionResult Registro()
        {
            ViewData["Accion"] = "Registro";
            return View("Index");
        }

        public IActionResult Login()
        {
            ViewData["Accion"] = "Login";
            return View("Index");
        }

        public IActionResult Forbidden()
        {
            ViewData["Accion"] = "Login";
            return View("Index");
        }

        [HttpPostAttribute]
        [ValidateAntiForgeryTokenAttribute]
        public IActionResult Registro([BindAttribute( "Nombre,Email,Clave" )] RegistroModels model) 
        {
            if(ModelState.IsValid)
            {
                var _db = new GoMeetContext();
                
                var user = new Usuario();
                user.Nombre = model.Nombre;
                user.Email = model.Email;
                user.Clave = model.Clave;
                user.InstitucionId = 3;

                _db.Usuarios.Add(user);
                _db.SaveChanges();

                return RedirectToAction("/Intranet");
            }
            
            return View("Index");
        }


        [HttpPostAttribute]
        [ValidateAntiForgeryTokenAttribute]
        public IActionResult Login([BindAttribute("Email", "Clave")] LoginModels model)
        {
            if(ModelState.IsValid)
            {
                var db = new GoMeetContext();
                var usuario = db.Usuarios.Where(o => o.Email == model.Email
                                                && o.Clave == model.Clave).FirstOrDefault();

                if(usuario != null)
                {
                    var claims = new List<Claim>();
                    claims.Add(new Claim(
                        ClaimTypes.Name, usuario.Nombre, 
                        ClaimValueTypes.String, 
                        string.Empty));

                    var userIdentity = new ClaimsIdentity("SuperSecureLogin");
                    userIdentity.AddClaims(claims);
                    var userPrincipal = new ClaimsPrincipal(userIdentity);

                    HttpContext.Authentication.SignInAsync("Cookie", userPrincipal,
                    new AuthenticationProperties
                    {
                        ExpiresUtc = DateTime.UtcNow.AddMinutes(20),
                        IsPersistent = false,
                        AllowRefresh = false
                    });

                    return RedirectToAction("Index","Intranet");
                }
            }

            return RedirectToAction("Login","Home");
        }

  
    }
}
