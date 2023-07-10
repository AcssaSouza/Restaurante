using Microsoft.AspNetCore.Mvc;
using Restaurante.API.Domain;

namespace Restaurante.API.Controllers
{
    [ApiController]
    [Route("")]
    public class CardapioController : ControllerBase
    {
        [HttpGet("Cardapios")]
        public List<Cardapio> Get()
        {
            var listaCardapios = new List<Cardapio>();

            var cardapio = new Cardapio();

            cardapio.CardapioId = 1;
            cardapio.Nome = "Pizza";
            cardapio.Preço = 2;
            cardapio.Ingredientes = "Queijo e Azeitona";

            listaCardapios.Add(cardapio);

            return listaCardapios;
        }
    }
}
