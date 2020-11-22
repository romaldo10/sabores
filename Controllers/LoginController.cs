using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using Sabores.Helper;
using Sabores.Models;
using Sabores.Models.ViewModel;

namespace Sabores.Controllers
{
    public class LoginController : Controller
    {
        private SaboresCTX ctx;

        public LoginController(SaboresCTX _ctx)
        {
            ctx = _ctx;
        }
        public IActionResult Index()
        {
     
                return View();
          
        }

        [BindProperty]
        public UsuarioVM Usuario { get; set; }
        public async Task<IActionResult> Login()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.SelectMany(x => x.Value.Errors.Select(y => y.ErrorMessage)).ToList());
            }
            else
            {
                var result = await ctx.Usuarios.Include("Roles.Rol").Where(x => x.Nombre == Usuario.Nombre).SingleOrDefaultAsync();
                if (result == null)
                {
                    return NotFound(new JObject() {
                        { "StatusCode", 404 },
                         { "Message", ", debes registrarte primero." }
                    });
                }
                else
                {
                    
                    if (HashHelper.CheckHash(Usuario.Clave, result.Clave, result.Sal))
                    {
                        if (result.Roles.Count == 0)
                        {
                            var response = new JObject() {
                            { "StatusCode", 403 },
                            { "Message", ", el usuario no tiene permisos" }
                        };
                            return StatusCode(403, response);
                        }
                        //crear sesion
                        var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Name, ClaimTypes.Role);
                        identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, result.IdUsuario.ToString()));
                        identity.AddClaim(new Claim(ClaimTypes.Name, result.Nombre));
                        identity.AddClaim(new Claim(ClaimTypes.Email, "romaldobermudez@gmail.com"));
                        identity.AddClaim(new Claim("Dato", "Valor"));

                        //Cargar roles a cookie

                        foreach (var Rol in result.Roles)
                        {
                            identity.AddClaim(new Claim(ClaimTypes.Role, Rol.Rol.Descripcion));
                        }
                        var principal = new ClaimsPrincipal(identity);
                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal,
                        new AuthenticationProperties { ExpiresUtc = DateTime.Now.AddDays(2), IsPersistent = true });
                      
                        return Redirect("/Modulos");
                    }
                    else
                    {
                        var response = new JObject() {
                            { "StatusCode", 403 },
                            { "Message", ", el usuario o la contraseña no es válida." }
                        };
                        return StatusCode(403, response);
                    }
                }
            }
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/Login");
        }
    }
}