using Dapper;
using Microsoft.AspNetCore.Mvc;
using Restaurante.API.Domain;
using System.Data.SqlClient;

namespace Restaurante.API.Controllers
{
    [ApiController]
    [Route("")]
    public class CardapioController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public CardapioController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet("Cardapios")]
        public Task<List<Cardapio>> Get()
        {
            var listaCardapios = ObterCardapios();

            return listaCardapios;
        }

        [HttpGet("Cardapios/{id}")]
        public async Task<Cardapio> GetById(int id)
        {
            var cardapio = await ObterCardapioPorId(id);
            return cardapio;
        }

        private async Task<List<Cardapio>> ObterCardapios() 
        {
            using var connection = new SqlConnection(_configuration["ConnectionStrings:DBRestaurante"]);
            var result = await connection.QueryAsync<Cardapio>("Select * From Cardapio");
            var cardapios = result.ToList();

            return cardapios;
        }
        
        private async Task<Cardapio> ObterCardapioPorId(int id)
        {
            using var connection = new SqlConnection(_configuration["ConnectionStrings:DBRestaurante"]);
            var parametro = new DynamicParameters();
            parametro.Add("@CardapioId", id);
            var result = await connection.QueryFirstOrDefaultAsync<Cardapio>("Select * From Cardapio where CardapioId = @CardapioId", parametro);
            
            return result;
        }
    }
}
