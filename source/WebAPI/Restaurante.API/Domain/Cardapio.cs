namespace Restaurante.API.Domain
{
    public class Cardapio
    {
        public int CardapioId { get; set; }
        public string Nome { get; set; }
        public double Preço { get; set; }
        public string Ingredientes { get; set; }

    }
}
