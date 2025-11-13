using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Sistema_de_Personagens.Data;
using Sistema_de_Personagens.Models;

namespace Sistema_de_Personagens.Controllers
{
    public class PersonagemController : Controller
    {
        private readonly AppDbContext _context;

        public PersonagemController(AppDbContext contextConstrutor)
        {
            _context = contextConstrutor;
        }

        public async Task<IActionResult> Index()
        {
            var lista = await _context.TabelaPersonagem.ToListAsync();

            return View(lista);
        }

        [HttpGet]
        public IActionResult Criar() => View();

        [HttpPost]
        public async Task<IActionResult> Criar(string NomeConstrutor, int NivelConstrutor, string TipoConstrutor)
        {
            Personagem? novoPersonagem = null;

            if(TipoConstrutor == "Mago")
            {
                novoPersonagem = new Mago(NomeConstrutor, NivelConstrutor);
            }
            else if(TipoConstrutor == "Guerreiro")
            {
                novoPersonagem = new Guerreiro(NomeConstrutor, NivelConstrutor);
            }
            else
            {
                return BadRequest("Tipo de curso invalido.");
            }

            _context.TabelaPersonagem.Add(novoPersonagem);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Deletar(int Id)
        {
            var curso = await _context.TabelaPersonagem.FindAsync(Id);

            if(curso == null) return NotFound();

            _context.TabelaPersonagem.Remove(curso);

            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}