using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sabores.Models;

namespace Sabores.Controllers
{
    public class MenusController : Controller
    {
        private readonly SaboresCTX _context;

        public MenusController(SaboresCTX context)
        {
            _context = context;
        }

        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Menus.ToListAsync());
        }

        [Authorize]
        public async Task<IActionResult> Cliente()
        {
            return View(await _context.Menus.ToListAsync());
        }
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menus = await _context.Menus
                .FirstOrDefaultAsync(m => m.IdMenu == id);
            if (menus == null)
            {
                return NotFound();
            }

            return View(menus);
        }

        [Authorize(Roles = "Administrador")]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Administrador")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdMenu,Descripcion,Categoria,Precio")] Menus menus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(menus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(menus);
        }
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menus = await _context.Menus.FindAsync(id);
            if (menus == null)
            {
                return NotFound();
            }
            return View(menus);
        }

        [Authorize(Roles = "Administrador")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdMenu,Descripcion,Categoria,Precio")] Menus menus)
        {
            if (id != menus.IdMenu)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(menus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MenusExists(menus.IdMenu))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(menus);
        }

        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menus = await _context.Menus
                .FirstOrDefaultAsync(m => m.IdMenu == id);
            if (menus == null)
            {
                return NotFound();
            }

            return View(menus);
        }

        [Authorize(Roles = "Administrador")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var menus = await _context.Menus.FindAsync(id);
            _context.Menus.Remove(menus);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [Authorize(Roles = "Administrador")]
        private bool MenusExists(int id)
        {
            return _context.Menus.Any(e => e.IdMenu == id);
        }
    }
}
