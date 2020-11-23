using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sabores.Models;

namespace Sabores.Controllers
{
    public class UsuariosController : Controller
    {
        private SaboresCTX ctx;

        public UsuariosController(SaboresCTX _ctx)
        {
            ctx = _ctx;
        }
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Index()
        {

            return Ok(await ctx.Usuarios.Include("Roles.Rol").ToListAsync());

        }
    }
}
