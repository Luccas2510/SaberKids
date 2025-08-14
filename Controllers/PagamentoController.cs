using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SaberKids.Models;
using SaberKids.Repositorios.Interfaces;

namespace SaberKids.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagamentoController : ControllerBase
    {
        private readonly IPagamentoRepositorio _pagamentoRepositorio;

        public PagamentoController(IPagamentoRepositorio pagamentoRepositorio)
        {
            _pagamentoRepositorio = pagamentoRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<PagamentoModel>>> BuscarTodosPagamentos()
        {
            List<PagamentoModel> pagamentos = await _pagamentoRepositorio.BuscarTodosPagamentos();
            return Ok(pagamentos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PagamentoModel>> BuscarPorId(int id)
        {
            PagamentoModel pagamento = await _pagamentoRepositorio.BuscarPorId(id);
            return Ok(pagamento);
        }

        [HttpPost]

        public async Task<ActionResult<PagamentoModel>> Adicionar([FromBody] PagamentoModel pagamentoModel)
        {
            PagamentoModel pagamento = await _pagamentoRepositorio.Adicionar(pagamentoModel);
            return Ok(pagamento);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PagamentoModel>> Atualizar(int id, [FromBody] PagamentoModel pagamentoModel)
        {
            pagamentoModel.Id = id;
            PagamentoModel pagamento = await _pagamentoRepositorio.Atualizar(pagamentoModel, id);
            return Ok(pagamento);
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<PagamentoModel>> Apagar(int id)
        {
            bool apagado = await _pagamentoRepositorio.Apagar(id);
            return Ok(apagado);
        }
    }
}
