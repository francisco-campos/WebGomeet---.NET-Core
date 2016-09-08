using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebGomeet.Controllers
{    
    public class IntranetController : Controller
    {
        // GET: /<controller>/
        [AuthorizeAttribute]
        public IActionResult Index()
        {
            string currentUserName = User.Identity.Name;
            ViewData["Message"] = "Bienvenido " + currentUserName + ". este es inicio!";
            
            

            return View();
        }
    }
}
