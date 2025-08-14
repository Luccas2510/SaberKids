using Microsoft.EntityFrameworkCore;
using SaberKids.Data;
using SaberKids.Models;
using SaberKids.Repositorios.Interfaces;

namespace SaberKids.Repositorios
{
    public class PagamentoRepositorio : IPagamentoRepositorio
    {
        private readonly SaberKidsDbContext _dbContext;

        public PagamentoRepositorio(SaberKidsDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<PagamentoModel> Adicionar(PagamentoModel pagamento)
        {
            await _dbContext.Pagamentos.AddAsync(pagamento);
            await _dbContext.SaveChangesAsync();

            return pagamento;
        }

        public async Task<bool> Apagar(int id)
        {
            PagamentoModel pagamentoPorId = await BuscarPorId(id);

            if (pagamentoPorId == null)
            {
                throw new Exception($"Pagamento do Id: {id} não foi encontrado.");
            }

            _dbContext.Pagamentos.Remove(pagamentoPorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<PagamentoModel> Atualizar(PagamentoModel pagamento, int id)
        {
            PagamentoModel pagamentoPorId = await BuscarPorId(id);

            if (pagamentoPorId == null)
            {
                throw new Exception($"Pagamento do Id: {id} não foi encontrado.");
            }

            pagamentoPorId.Anual = pagamento.Anual;
            pagamentoPorId.Mensal = pagamento.Mensal;

            _dbContext.Pagamentos.Update(pagamentoPorId);
            await _dbContext.SaveChangesAsync();

            return pagamentoPorId;
        }

        public async Task<PagamentoModel> BuscarPorId(int id)
        {
            return await _dbContext.Pagamentos.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<PagamentoModel>> BuscarTodosPagamentos()
        {
            return await _dbContext.Pagamentos.ToListAsync();
        }
    }
}
