using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sistema_de_PersonagensDBFirst.Data;
using Sistema_de_PersonagensDBFirst.Models;

namespace Sistema_de_PersonagensDBFirst.Controllers
{
    public class PersonagemController : Controller
    {
        private readonly AppDbContext _context;

        public PersonagemController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Personagem
        public async Task<IActionResult> Index()
        {
            return View(await _context.TabelaPersonagems.ToListAsync());
        }

        // GET: Personagem/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tabelaPersonagem = await _context.TabelaPersonagems
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tabelaPersonagem == null)
            {
                return NotFound();
            }

            return View(tabelaPersonagem);
        }

        // GET: Personagem/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Personagem/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Nivel,Tipo")] TabelaPersonagem tabelaPersonagem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tabelaPersonagem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tabelaPersonagem);
        }

        // GET: Personagem/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tabelaPersonagem = await _context.TabelaPersonagems.FindAsync(id);
            if (tabelaPersonagem == null)
            {
                return NotFound();
            }
            return View(tabelaPersonagem);
        }

        // POST: Personagem/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Nivel,Tipo")] TabelaPersonagem tabelaPersonagem)
        {
            if (id != tabelaPersonagem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tabelaPersonagem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TabelaPersonagemExists(tabelaPersonagem.Id))
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
            return View(tabelaPersonagem);
        }

        // GET: Personagem/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tabelaPersonagem = await _context.TabelaPersonagems
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tabelaPersonagem == null)
            {
                return NotFound();
            }

            return View(tabelaPersonagem);
        }

        // POST: Personagem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tabelaPersonagem = await _context.TabelaPersonagems.FindAsync(id);
            if (tabelaPersonagem != null)
            {
                _context.TabelaPersonagems.Remove(tabelaPersonagem);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TabelaPersonagemExists(int id)
        {
            return _context.TabelaPersonagems.Any(e => e.Id == id);
        }
    }
}
