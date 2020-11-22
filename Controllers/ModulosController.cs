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
        [Authorize(Roles ="Cliente")]
        public IActionResult Cliente()
        {
            return Content("<h1>Cliente</h1>");
        }
        [Authorize(Roles = "Administrador")]
        public IActionResult Administrador()
        {
            return Content("<h1>Cliente</h1>");
        }
    }
}
