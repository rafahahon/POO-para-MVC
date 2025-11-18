using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sistema_de_AnimaisDBFirst.Data;
using Sistema_de_AnimaisDBFirst.Models;

namespace Sistema_de_AnimaisDBFirst.Controllers
{
    public class AnimalController : Controller
    {
        private readonly AppDbContext _context;

        public AnimalController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Animal
        public async Task<IActionResult> Index()
        {
            return View(await _context.TabelaAnimals.ToListAsync());
        }

        // GET: Animal/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tabelaAnimal = await _context.TabelaAnimals
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tabelaAnimal == null)
            {
                return NotFound();
            }

            return View(tabelaAnimal);
        }

        // GET: Animal/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Animal/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Tipo")] TabelaAnimal tabelaAnimal)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tabelaAnimal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tabelaAnimal);
        }

        // GET: Animal/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tabelaAnimal = await _context.TabelaAnimals.FindAsync(id);
            if (tabelaAnimal == null)
            {
                return NotFound();
            }
            return View(tabelaAnimal);
        }

        // POST: Animal/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Tipo")] TabelaAnimal tabelaAnimal)
        {
            if (id != tabelaAnimal.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tabelaAnimal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TabelaAnimalExists(tabelaAnimal.Id))
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
            return View(tabelaAnimal);
        }

        // GET: Animal/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tabelaAnimal = await _context.TabelaAnimals
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tabelaAnimal == null)
            {
                return NotFound();
            }

            return View(tabelaAnimal);
        }

        // POST: Animal/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tabelaAnimal = await _context.TabelaAnimals.FindAsync(id);
            if (tabelaAnimal != null)
            {
                _context.TabelaAnimals.Remove(tabelaAnimal);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TabelaAnimalExists(int id)
        {
            return _context.TabelaAnimals.Any(e => e.Id == id);
        }
    }
}
