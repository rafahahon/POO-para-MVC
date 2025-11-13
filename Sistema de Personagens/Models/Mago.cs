using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_de_Personagens.Models
{
    public class Mago : Personagem
    {
        public Mago() { }

        public Mago(string NomeConstrutor, int NivelConstrutor) : base(NomeConstrutor, NivelConstrutor) { }

        public override int CalcularPoder()
        {
           return Nivel * 8 + 20;
        }
    }
}