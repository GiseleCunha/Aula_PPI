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
    public class AfiliadosController : Controller
    {
        private readonly Aula10_relacionamento1toNContext _context;

        public AfiliadosController(Aula10_relacionamento1toNContext context)
        {
            _context = context;
        }

        // GET: Afiliados
        public async Task<IActionResult> Index()
        {
            return View(await _context.Afiliado.ToListAsync());
        }

        // GET: Afiliados/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var afiliado = await _context.Afiliado
                .FirstOrDefaultAsync(m => m.Id == id);
            if (afiliado == null)
            {
                return NotFound();
            }

            return View(afiliado);
        }

        // GET: Afiliados/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Afiliados/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome")] Afiliado afiliado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(afiliado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(afiliado);
        }

        // GET: Afiliados/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var afiliado = await _context.Afiliado.FindAsync(id);
            if (afiliado == null)
            {
                return NotFound();
            }
            return View(afiliado);
        }

        // POST: Afiliados/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Nome")] Afiliado afiliado)
        {
            if (id != afiliado.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(afiliado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AfiliadoExists(afiliado.Id))
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
            return View(afiliado);
        }

        // GET: Afiliados/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var afiliado = await _context.Afiliado
                .FirstOrDefaultAsync(m => m.Id == id);
            if (afiliado == null)
            {
                return NotFound();
            }

            return View(afiliado);
        }

        // POST: Afiliados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var afiliado = await _context.Afiliado.FindAsync(id);
            _context.Afiliado.Remove(afiliado);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AfiliadoExists(long id)
        {
            return _context.Afiliado.Any(e => e.Id == id);
        }
    }
}
