using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SaberKids.Models;
using SaberKids.Repositorios.Interfaces;

namespace SaberKids.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartaoPagamentoController : ControllerBase
    {
        private readonly ICartaoPagamentoRepositorio _cartaopagamentoRepositorio;

        public CartaoPagamentoController(ICartaoPagamentoRepositorio cartaopagamentoRepositorio)
        {
            _cartaopagamentoRepositorio = cartaopagamentoRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<CartaoPagamentoModel>>> BuscarTodosCartoesPagamentos()
        {
            List<CartaoPagamentoModel> cartoespagamentos = await _cartaopagamentoRepositorio.BuscarTodosCartoesPagamentos();
            return Ok(cartoespagamentos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CartaoPagamentoModel>> BuscarPorId(int id)
        {
            CartaoPagamentoModel cartaopagamento = await _cartaopagamentoRepositorio.BuscarPorId(id);
            return Ok(cartaopagamento);
        }

        [HttpPost]

        public async Task<ActionResult<CartaoPagamentoModel>> Adicionar([FromBody] CartaoPagamentoModel cartaopagamentoModel)
        {
            CartaoPagamentoModel cartaopagamento = await _cartaopagamentoRepositorio.Adicionar(cartaopagamentoModel);
            return Ok(cartaopagamento);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CartaoPagamentoModel>> Atualizar(int id, [FromBody] CartaoPagamentoModel cartaopagamentoModel)
        {
            cartaopagamentoModel.Id = id;
            CartaoPagamentoModel cartaopagamento = await _cartaopagamentoRepositorio.Atualizar(cartaopagamentoModel, id);
            return Ok(cartaopagamento);
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<CartaoPagamentoModel>> Apagar(int id)
        {
            bool apagado = await _cartaopagamentoRepositorio.Apagar(id);
            return Ok(apagado);
        }
    }
}
