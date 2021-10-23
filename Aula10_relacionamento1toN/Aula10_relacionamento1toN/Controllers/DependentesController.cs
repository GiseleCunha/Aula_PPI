using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Aula10_relacionamento1toN.Data;
using Aula10_relacionamento1toN.Models;

namespace Aula10_relacionamento1toN.Controllers
{
    public class DependentesController : Controller
    {
        private readonly Aula10_relacionamento1toNContext _context;

        public DependentesController(Aula10_relacionamento1toNContext context)
        {
            _context = context;
        }

        // GET: Dependentes
        public async Task<IActionResult> Index()
        {
            var aula10_relacionamento1toNContext = _context.Dependente.Include(d => d.Responsavel);
            return View(await aula10_relacionamento1toNContext.ToListAsync());
        }

        // GET: Dependentes/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dependente = await _context.Dependente
                .Include(d => d.Responsavel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dependente == null)
            {
                return NotFound();
            }

            return View(dependente);
        }

        // GET: Dependentes/Create
        public IActionResult Create()
        {
            ViewData["ResponsavelId"] = new SelectList(_context.Afiliado, "Id", "Nome");
            return View();
        }

        // POST: Dependentes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,ResponsavelId")] Dependente dependente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dependente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ResponsavelId"] = new SelectList(_context.Afiliado, "Id", "Nome", dependente.ResponsavelId);
            return View(dependente);
        }

        // GET: Dependentes/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dependente = await _context.Dependente.FindAsync(id);
            if (dependente == null)
            {
                return NotFound();
            }
            ViewData["ResponsavelId"] = new SelectList(_context.Afiliado, "Id", "Nome", dependente.ResponsavelId);
            return View(dependente);
        }

        // POST: Dependentes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Nome,ResponsavelId")] Dependente dependente)
        {
            if (id != dependente.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dependente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DependenteExists(dependente.Id))
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
            ViewData["ResponsavelId"] = new SelectList(_context.Afiliado, "Id", "Nome", dependente.ResponsavelId);
            return View(dependente);
        }

        // GET: Dependentes/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dependente = await _context.Dependente
                .Include(d => d.Responsavel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dependente == null)
            {
                return NotFound();
            }

            return View(dependente);
        }

        // POST: Dependentes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var dependente = await _context.Dependente.FindAsync(id);
            _context.Dependente.Remove(dependente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DependenteExists(long id)
        {
            return _context.Dependente.Any(e => e.Id == id);
        }
    }
}
