using Microsoft.EntityFrameworkCore;
using SaberKids.Data;
using SaberKids.Models;
using SaberKids.Repositorios.Interfaces;

namespace SaberKids.Repositorios
{
    public class MateriaRepositorio : IMateriaRepositorio
    {
        private readonly SaberKidsDbContext _dbContext;

        public MateriaRepositorio(SaberKidsDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<MateriaModel> Adicionar(MateriaModel materia)
        {
            await _dbContext.Materias.AddAsync(materia);
            await _dbContext.SaveChangesAsync();

            return materia;
        }

        public async Task<bool> Apagar(int id)
        {
            MateriaModel materiaPorId = await BuscarPorId(id);

            if (materiaPorId == null)
            {
                throw new Exception($"As matérias do seguinte Id: {id} não foram encontradas");
            }

            _dbContext.Materias.Remove(materiaPorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<MateriaModel> Atualizar(MateriaModel materia, int id)
        {
            MateriaModel materiaPorId = await BuscarPorId(id);

            if (materiaPorId == null)
            {
                throw new Exception($"As matérias do seguinte Id: {id} não foram encontradas");
            }

            materiaPorId.Nome = materia.Nome;
            materiaPorId.Descricao = materia.Descricao;

            _dbContext.Materias.Update(materiaPorId);
            await _dbContext.SaveChangesAsync();

            return materiaPorId;
        }

        public async Task<MateriaModel> BuscarPorId(int id)
        {
            return await _dbContext.Materias.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<MateriaModel>> BuscarTodasMaterias()
        {
            return await _dbContext.Materias.ToListAsync();
        }
    }
}
