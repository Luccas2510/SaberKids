using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SaberKids.Models;
using SaberKids.Repositorios.Interfaces;

namespace SaberKids.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurmaMateriaController : ControllerBase
    {
        private readonly ITurmaMateriaRepositorio _turmamateriaRepositorio;

        public TurmaMateriaController(ITurmaMateriaRepositorio turmamateriaRepositorio)
        {
            _turmamateriaRepositorio = turmamateriaRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<TurmaMateriaModel>>> BuscarTodasTurmasMaterias()
        {
            List<TurmaMateriaModel> turmasmaterias = await _turmamateriaRepositorio.BuscarTodasTurmasMaterias();
            return Ok(turmasmaterias);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TurmaMateriaModel>> BuscarPorId(int id)
        {
            TurmaMateriaModel turmamateria = await _turmamateriaRepositorio.BuscarPorId(id);
            return Ok(turmamateria);
        }

        [HttpPost]

        public async Task<ActionResult<TurmaMateriaModel>> Adicionar([FromBody] TurmaMateriaModel turmamateriaModel)
        {
            TurmaMateriaModel turmamateria = await _turmamateriaRepositorio.Adicionar(turmamateriaModel);
            return Ok(turmamateria);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TurmaMateriaModel>> Atualizar(int id, [FromBody] TurmaMateriaModel turmamateriaModel)
        {
            turmamateriaModel.Id = id;
            TurmaMateriaModel turmamateria = await _turmamateriaRepositorio.Atualizar(turmamateriaModel, id);
            return Ok(turmamateria);
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<TurmaMateriaModel>> Apagar(int id)
        {
            bool apagado = await _turmamateriaRepositorio.Apagar(id);
            return Ok(apagado);
        }
    }
}
