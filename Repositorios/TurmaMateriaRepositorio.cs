using Microsoft.EntityFrameworkCore;
using SaberKids.Data;
using SaberKids.Models;
using SaberKids.Repositorios.Interfaces;

namespace SaberKids.Repositorios
{
    public class TurmaMateriaRepositorio : ITurmaMateriaRepositorio
    {
        private readonly SaberKidsDbContext _dbContext;

        public TurmaMateriaRepositorio(SaberKidsDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<TurmaMateriaModel> Adicionar(TurmaMateriaModel turmamateria)
        {
            await _dbContext.TurmasMaterias.AddAsync(turmamateria);
            await _dbContext.SaveChangesAsync();

            return turmamateria;
        }

        public async Task<bool> Apagar(int id)
        {
            TurmaMateriaModel turmamateriaPorId = await BuscarPorId(id);

            if (turmamateriaPorId == null)
            {
                throw new Exception($"As turmas das matérias do seguinte Id: {id} não foram encontradas");
            }

            _dbContext.TurmasMaterias.Remove(turmamateriaPorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<TurmaMateriaModel> Atualizar(TurmaMateriaModel turmamateria, int id)
        {
            TurmaMateriaModel turmamateriaPorId = await BuscarPorId(id);

            if (turmamateriaPorId == null)
            {
                throw new Exception($"As turmas das matérias do seguinte Id: {id} não foram encontradas");
            }

            turmamateriaPorId.TurmaId = turmamateria.TurmaId;
            turmamateriaPorId.MateriaId = turmamateria.MateriaId;

            _dbContext.TurmasMaterias.Update(turmamateriaPorId);
            await _dbContext.SaveChangesAsync();

            return turmamateriaPorId;
        }

        public async Task<TurmaMateriaModel> BuscarPorId(int id)
        {
            return await _dbContext.TurmasMaterias.Include(x => x.Turma).Include(y => y.Materia).FirstOrDefaultAsync(z => z.Id == id);
        }

        public async Task<List<TurmaMateriaModel>> BuscarTodasTurmasMaterias()
        {
            return await _dbContext.TurmasMaterias.ToListAsync();
        }
    }
}
