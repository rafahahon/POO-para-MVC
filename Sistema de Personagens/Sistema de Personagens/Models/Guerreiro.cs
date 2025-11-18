using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_de_Personagens.Models
{
    public class Guerreiro : Personagem
    {
        public Guerreiro() { }

        public Guerreiro(string NomeConstrutor, int NivelConstrutor) : base(NomeConstrutor, NivelConstrutor) { }

        public override int CalcularPoder()
        {
           return Nivel * 10;
        }
    }
}