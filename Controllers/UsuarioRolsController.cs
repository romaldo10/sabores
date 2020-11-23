using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sabores.Models;

namespace Sabores.Controllers
{
    public class UsuarioRolsController : Controller
    {
        private readonly SaboresCTX _context;

        public UsuarioRolsController(SaboresCTX context)
        {
            _context = context;
        }

        // GET: UsuarioRols
        public async Task<IActionResult> Index()
        {
            var saboresCTX = _context.UsuarioRol.Include(u => u.Rol);
            return View(await saboresCTX.ToListAsync());
        }

        // GET: UsuarioRols/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarioRol = await _context.UsuarioRol
                .Include(u => u.Rol)
                .FirstOrDefaultAsync(m => m.IdUsuario == id);
            if (usuarioRol == null)
            {
                return NotFound();
            }

            return View(usuarioRol);
        }

        // GET: UsuarioRols/Create
        public IActionResult Create()
        {
            ViewData["IdRol"] = new SelectList(_context.Roles, "IdRol", "IdRol");
            return View();
        }

        // POST: UsuarioRols/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdUsuario,IdRol")] UsuarioRol usuarioRol)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usuarioRol);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdRol"] = new SelectList(_context.Roles, "IdRol", "IdRol", usuarioRol.IdRol);
            return View(usuarioRol);
        }

        // GET: UsuarioRols/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarioRol = await _context.UsuarioRol.FindAsync(id);
            if (usuarioRol == null)
            {
                return NotFound();
            }
            ViewData["IdRol"] = new SelectList(_context.Roles, "IdRol", "IdRol", usuarioRol.IdRol);
            return View(usuarioRol);
        }

        // POST: UsuarioRols/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdUsuario,IdRol")] UsuarioRol usuarioRol)
        {
            if (id != usuarioRol.IdUsuario)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuarioRol);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioRolExists(usuarioRol.IdUsuario))
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
            ViewData["IdRol"] = new SelectList(_context.Roles, "IdRol", "IdRol", usuarioRol.IdRol);
            return View(usuarioRol);
        }

        // GET: UsuarioRols/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarioRol = await _context.UsuarioRol
                .Include(u => u.Rol)
                .FirstOrDefaultAsync(m => m.IdUsuario == id);
            if (usuarioRol == null)
            {
                return NotFound();
            }

            return View(usuarioRol);
        }

        // POST: UsuarioRols/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usuarioRol = await _context.UsuarioRol.FindAsync(id);
            _context.UsuarioRol.Remove(usuarioRol);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioRolExists(int id)
        {
            return _context.UsuarioRol.Any(e => e.IdUsuario == id);
        }
    }
}
