using Microsoft.EntityFrameworkCore;
using SaberKids.Data;
using SaberKids.Models;
using SaberKids.Repositorios.Interfaces;

namespace SaberKids.Repositorios
{
    public class CursoRepositorio : ICursoRepositorio
    {
        private readonly SaberKidsDbContext _dbContext;

        public CursoRepositorio(SaberKidsDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<CursoModel> Adicionar(CursoModel curso)
        {
            await _dbContext.Cursos.AddAsync(curso);
            await _dbContext.SaveChangesAsync();

            return curso;
        }

        public async Task<bool> Apagar(int id)
        {
            CursoModel cursoPorId = await BuscarPorId(id);

            if (cursoPorId == null)
            {
                throw new Exception($"Curso do Id: {id} não foi encontrado.");
            }

            _dbContext.Cursos.Remove(cursoPorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<CursoModel> Atualizar(CursoModel curso, int id)
        {
            CursoModel cursoPorId = await BuscarPorId(id);

            if (cursoPorId == null)
            {
                throw new Exception($"Curso do Id: {id} não foi encontrado.");
            }

            cursoPorId.TurmaId = curso.TurmaId;
            cursoPorId.UsuarioId = curso.UsuarioId;
            cursoPorId.Nome = curso.Nome;
            cursoPorId.Descricao = curso.Descricao;

            _dbContext.Cursos.Update(cursoPorId);
            await _dbContext.SaveChangesAsync();

            return cursoPorId;
        }

        public async Task<CursoModel> BuscarPorId(int id)
        {
            return await _dbContext.Cursos.Include(x => x.Usuario).Include(y => y.Turma).FirstOrDefaultAsync(z => z.Id == id);
        }

        public async Task<List<CursoModel>> BuscarTodosCursos()
        {
            return await _dbContext.Cursos.ToListAsync();
        }

    }
}
