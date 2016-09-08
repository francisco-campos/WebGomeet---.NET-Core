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
    public class RegistroController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }

        public IActionResult Maestro()
        {
            return View("Index");
        }

        public IActionResult Usuario()
        {
            return View("Index");
        }
    }
}
