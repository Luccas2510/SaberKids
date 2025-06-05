using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SaberKids.Models;
using SaberKids.Repositorios.Interfaces;

namespace SaberKids.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurmaController : ControllerBase
    {
        private readonly ITurmaRepositorio _turmaRepositorio;

        public TurmaController(ITurmaRepositorio turmaRepositorio)
        {
            _turmaRepositorio = turmaRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<TurmaModel>>> BuscarTodasTurmas()
        {
            List<TurmaModel> turmas = await _turmaRepositorio.BuscarTodasTurmas();
            return Ok(turmas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TurmaModel>> BuscarPorId(int id)
        {
            TurmaModel turma = await _turmaRepositorio.BuscarPorId(id);
            return Ok(turma);
        }

        [HttpPost]

        public async Task<ActionResult<TurmaModel>> Adicionar([FromBody] TurmaModel turmaModel)
        {
            TurmaModel turma = await _turmaRepositorio.Adicionar(turmaModel);
            return Ok(turma);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TurmaModel>> Atualizar(int id, [FromBody] TurmaModel turmaModel)
        {
            turmaModel.Id = id;
            TurmaModel turma = await _turmaRepositorio.Atualizar(turmaModel, id);
            return Ok(turma);
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<TurmaModel>> Apagar(int id)
        {
            bool apagado = await _turmaRepositorio.Apagar(id);
            return Ok(apagado);
        }
    }
}
