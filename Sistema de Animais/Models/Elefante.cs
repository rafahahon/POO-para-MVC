namespace Sistema_de_Animais.Models
{
    public class Elefante : Animal
    {
        public Elefante() { }

        public Elefante(string NomeConstrutor) : base(NomeConstrutor) { }

        public override string EmitirSom()
        {
            return "Barrito!";
        }
        public override string TipoAlimentacao()
        {
            return "Herbivoro!";
        }
    }
}