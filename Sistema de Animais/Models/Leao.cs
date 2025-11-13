namespace Sistema_de_Animais.Models
{
    public class Leao : Animal
    {
        public Leao() { }

        public Leao(string NomeConstrutor) : base(NomeConstrutor) { }

        public override string EmitirSom()
        {
            return "RUGIDO!";
        }
        public override string TipoAlimentacao()
        {
            return "Carnivoro!";
        }
    }
}