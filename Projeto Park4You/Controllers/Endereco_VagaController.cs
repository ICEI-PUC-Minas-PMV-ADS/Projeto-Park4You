using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Projeto_Park4You.Models;

namespace Projeto_Park4You.Controllers
{
    public class Endereco_VagaController : Controller
    {
        private readonly AppDbContext _context;

        public Endereco_VagaController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Endereco_Vaga
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.endereco_Vagas.Include(e => e.cadast_Usuario);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Endereco_Vaga/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.endereco_Vagas == null)
            {
                return NotFound();
            }

            var endereco_Vaga = await _context.endereco_Vagas
                .Include(e => e.cadast_Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (endereco_Vaga == null)
            {
                return NotFound();
            }

            return View(endereco_Vaga);
        }

        // GET: Endereco_Vaga/Create
        public IActionResult Create()
        {
            ViewData["UsuarioId"] = new SelectList(_context.cadast_Usuario, "Id", "CPF");
            return View();
        }

        // POST: Endereco_Vaga/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CEP,Logradouro,Numero,Complemento,Bairro,Cidade,UF,Data,QuantVagas,Valor,Tipo,UsuarioId")] Endereco_Vaga endereco_Vaga)
        {
            if (ModelState.IsValid)
            {
                _context.Add(endereco_Vaga);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UsuarioId"] = new SelectList(_context.cadast_Usuario, "Id", "CPF", endereco_Vaga.UsuarioId);
            return View(endereco_Vaga);
        }

        // GET: Endereco_Vaga/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.endereco_Vagas == null)
            {
                return NotFound();
            }

            var endereco_Vaga = await _context.endereco_Vagas.FindAsync(id);
            if (endereco_Vaga == null)
            {
                return NotFound();
            }
            ViewData["UsuarioId"] = new SelectList(_context.cadast_Usuario, "Id", "CPF", endereco_Vaga.UsuarioId);
            return View(endereco_Vaga);
        }

        // POST: Endereco_Vaga/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CEP,Logradouro,Numero,Complemento,Bairro,Cidade,UF,Data,QuantVagas,Valor,Tipo,UsuarioId")] Endereco_Vaga endereco_Vaga)
        {
            if (id != endereco_Vaga.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(endereco_Vaga);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Endereco_VagaExists(endereco_Vaga.Id))
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
            ViewData["UsuarioId"] = new SelectList(_context.cadast_Usuario, "Id", "CPF", endereco_Vaga.UsuarioId);
            return View(endereco_Vaga);
        }

        // GET: Endereco_Vaga/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.endereco_Vagas == null)
            {
                return NotFound();
            }

            var endereco_Vaga = await _context.endereco_Vagas
                .Include(e => e.cadast_Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (endereco_Vaga == null)
            {
                return NotFound();
            }

            return View(endereco_Vaga);
        }

        // POST: Endereco_Vaga/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.endereco_Vagas == null)
            {
                return Problem("Entity set 'AppDbContext.endereco_Vagas'  is null.");
            }
            var endereco_Vaga = await _context.endereco_Vagas.FindAsync(id);
            if (endereco_Vaga != null)
            {
                _context.endereco_Vagas.Remove(endereco_Vaga);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Endereco_VagaExists(int id)
        {
          return _context.endereco_Vagas.Any(e => e.Id == id);
        }
    }
}
