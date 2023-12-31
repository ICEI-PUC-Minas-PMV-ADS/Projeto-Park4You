﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Projeto_Park4You.Models;

namespace Projeto_Park4You.Controllers
{
    public class cadast_UsuarioController : Controller
    {
        private readonly AppDbContext _context;

        public cadast_UsuarioController(AppDbContext context)
        {
            _context = context;
        }

        // GET: cadast_Usuario
        public async Task<IActionResult> Index()
        {
              return View(await _context.cadast_Usuario.ToListAsync());
        }

        // GET: cadast_Usuario/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.cadast_Usuario == null)
            {
                return NotFound();
            }

            var cadast_Usuario = await _context.cadast_Usuario
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cadast_Usuario == null)
            {
                return NotFound();
            }

            return View(cadast_Usuario);
        }

        // GET: cadast_Usuario/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: cadast_Usuario/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CPF,Nome,Email,Senha,Telefone")] cadast_Usuario cadast_Usuario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cadast_Usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cadast_Usuario);
        }

        // GET: cadast_Usuario/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.cadast_Usuario == null)
            {
                return NotFound();
            }

            var cadast_Usuario = await _context.cadast_Usuario.FindAsync(id);
            if (cadast_Usuario == null)
            {
                return NotFound();
            }
            return View(cadast_Usuario);
        }

        // POST: cadast_Usuario/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CPF,Nome,Email,Senha,Telefone")] cadast_Usuario cadast_Usuario)
        {
            if (id != cadast_Usuario.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cadast_Usuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!cadast_UsuarioExists(cadast_Usuario.Id))
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
            return View(cadast_Usuario);
        }

        // GET: cadast_Usuario/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.cadast_Usuario == null)
            {
                return NotFound();
            }

            var cadast_Usuario = await _context.cadast_Usuario
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cadast_Usuario == null)
            {
                return NotFound();
            }

            return View(cadast_Usuario);
        }

        // POST: cadast_Usuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.cadast_Usuario == null)
            {
                return Problem("Entity set 'AppDbContext.cadast_Usuario'  is null.");
            }
            var cadast_Usuario = await _context.cadast_Usuario.FindAsync(id);
            if (cadast_Usuario != null)
            {
                _context.cadast_Usuario.Remove(cadast_Usuario);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool cadast_UsuarioExists(int id)
        {
          return _context.cadast_Usuario.Any(e => e.Id == id);
        }
    }
}
