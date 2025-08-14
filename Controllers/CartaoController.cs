using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SaberKids.Models;
using SaberKids.Repositorios.Interfaces;

namespace SaberKids.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartaoController : ControllerBase
    {
        private readonly ICartaoRepositorio _cartaoRepositorio;

        public CartaoController(ICartaoRepositorio cartaoRepositorio)
        {
            _cartaoRepositorio = cartaoRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<CartaoModel>>> BuscarTodosCartoes()
        {
            List<CartaoModel> cartoes = await _cartaoRepositorio.BuscarTodosCartoes();
            return Ok(cartoes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CartaoModel>> BuscarPorId(int id)
        {
            CartaoModel cartao = await _cartaoRepositorio.BuscarPorId(id);
            return Ok(cartao);
        }

        [HttpPost]

        public async Task<ActionResult<CartaoModel>> Adicionar([FromBody] CartaoModel cartaoModel)
        {
            CartaoModel cartao = await _cartaoRepositorio.Adicionar(cartaoModel);
            return Ok(cartao);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CartaoModel>> Atualizar(int id, [FromBody] CartaoModel cartaoModel)
        {
            cartaoModel.Id = id;
            CartaoModel cartao = await _cartaoRepositorio.Atualizar(cartaoModel, id);
            return Ok(cartao);
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<CartaoModel>> Apagar(int id)
        {
            bool apagado = await _cartaoRepositorio.Apagar(id);
            return Ok(apagado);
        }
    }
}
