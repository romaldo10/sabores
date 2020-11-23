using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Sabores.Controllers
{     [Authorize]
    public class ModulosController : Controller
    {
   
        public IActionResult Index()
        {
            return View();
        }
     
        public IActionResult Reservaciones()
        {
            return View();
        }

        [Authorize(Roles = "Administrador")]
        public IActionResult Administrador()
        {
            return View();
        }
    }
}
