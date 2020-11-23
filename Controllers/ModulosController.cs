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
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
        [Authorize]
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
