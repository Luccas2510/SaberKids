using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SaberKids.Models;
using SaberKids.Repositorios.Interfaces;

namespace SaberKids.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursoController : ControllerBase
    {
        private readonly ICursoRepositorio _cursoRepositorio;

        public CursoController(ICursoRepositorio cursoRepositorio)
        {
            _cursoRepositorio = cursoRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<CursoModel>>> BuscarTodosCursos()
        {
            List<CursoModel> cursos = await _cursoRepositorio.BuscarTodosCursos();
            return Ok(cursos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CursoModel>> BuscarPorId(int id)
        {
            CursoModel curso = await _cursoRepositorio.BuscarPorId(id);
            return Ok(curso);
        }

        [HttpPost]

        public async Task<ActionResult<CursoModel>> Adicionar([FromBody] CursoModel cursoModel)
        {
            CursoModel curso = await _cursoRepositorio.Adicionar(cursoModel);
            return Ok(curso);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CursoModel>> Atualizar(int id, [FromBody] CursoModel cursoModel)
        {
            cursoModel.Id = id;
            CursoModel curso = await _cursoRepositorio.Atualizar(cursoModel, id);
            return Ok(curso);
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<CursoModel>> Apagar(int id)
        {
            bool apagado = await _cursoRepositorio.Apagar(id);
            return Ok(apagado);
        }
    }
}
