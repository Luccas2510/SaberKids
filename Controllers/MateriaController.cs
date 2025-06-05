using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SaberKids.Models;
using SaberKids.Repositorios.Interfaces;

namespace SaberKids.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MateriaController : ControllerBase
    {
        private readonly IMateriaRepositorio _materiaRepositorio;

        public MateriaController(IMateriaRepositorio materiaRepositorio)
        {
            _materiaRepositorio = materiaRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<MateriaModel>>> BuscarTodasMaterias()
        {
            List<MateriaModel> materias = await _materiaRepositorio.BuscarTodasMaterias();
            return Ok(materias);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MateriaModel>> BuscarPorId(int id)
        {
            MateriaModel materia = await _materiaRepositorio.BuscarPorId(id);
            return Ok(materia);
        }

        [HttpPost]

        public async Task<ActionResult<MateriaModel>> Adicionar([FromBody] MateriaModel materiaModel)
        {
            MateriaModel materia = await _materiaRepositorio.Adicionar(materiaModel);
            return Ok(materia);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<MateriaModel>> Atualizar(int id, [FromBody] MateriaModel materiaModel)
        {
            materiaModel.Id = id;
            MateriaModel materia = await _materiaRepositorio.Atualizar(materiaModel, id);
            return Ok(materia);
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<MateriaModel>> Apagar(int id)
        {
            bool apagado = await _materiaRepositorio.Apagar(id);
            return Ok(apagado);
        }
    }
}
