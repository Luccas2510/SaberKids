using Microsoft.EntityFrameworkCore;
using SaberKids.Data;
using SaberKids.Models;
using SaberKids.Repositorios.Interfaces;

namespace SaberKids.Repositorios
{
    public class TurmaRepositorio : ITurmaRepositorio
    {
        private readonly SaberKidsDbContext _dbContext;

        public TurmaRepositorio(SaberKidsDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<TurmaModel> Adicionar(TurmaModel turma)
        {
            await _dbContext.Turmas.AddAsync(turma);
            await _dbContext.SaveChangesAsync();

            return turma;
        }

        public async Task<bool> Apagar(int id)
        {
            TurmaModel turmaPorId = await BuscarPorId(id);

            if (turmaPorId == null)
            {
                throw new Exception($"Turma do Id: {id} não foi encontrada.");
            }

            _dbContext.Turmas.Remove(turmaPorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<TurmaModel> Atualizar(TurmaModel turma, int id)
        {
            TurmaModel turmaPorId = await BuscarPorId(id);

            if (turmaPorId == null)
            {
                throw new Exception($"Turma do Id: {id} não foi encontrada.");
            }

            turmaPorId.AnoEscolar = turma.AnoEscolar;

            _dbContext.Turmas.Update(turmaPorId);
            await _dbContext.SaveChangesAsync();

            return turmaPorId;
        }

        public async Task<TurmaModel> BuscarPorId(int id)
        {
            return await _dbContext.Turmas.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<TurmaModel>> BuscarTodasTurmas()
        {
            return await _dbContext.Turmas.ToListAsync();
        }
    }
}
