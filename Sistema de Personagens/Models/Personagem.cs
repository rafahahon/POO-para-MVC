using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_de_Personagens.Models
{
    public abstract class Personagem
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public int Nivel { get; set; }

        public Personagem() { }

        public Personagem(string NomeConstrutor, int NivelConstrutor)
        {
            Nome = NomeConstrutor;
            Nivel = NivelConstrutor;
        }

        public abstract int CalcularPoder();
        public void ExibirStatus()
        {
            Console.WriteLine($"O(a): {Nome}, comecou no nivel: {Nivel} e tem o poder de: {CalcularPoder()}.");
        }
    }
}