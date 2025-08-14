using Microsoft.EntityFrameworkCore;
using SaberKids.Data;
using SaberKids.Models;
using SaberKids.Repositorios.Interfaces;

namespace SaberKids.Repositorios
{
    public class CartaoPagamentoRepositorio : ICartaoPagamentoRepositorio
    {
        private readonly SaberKidsDbContext _dbContext;

        public CartaoPagamentoRepositorio(SaberKidsDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<CartaoPagamentoModel> Adicionar(CartaoPagamentoModel cartaopagamento)
        {
            await _dbContext.CartoesPagamentos.AddAsync(cartaopagamento);
            await _dbContext.SaveChangesAsync();

            return cartaopagamento;
        }

        public async Task<bool> Apagar(int id)
        {
            CartaoPagamentoModel cartaopagamentoPorId = await BuscarPorId(id);

            if (cartaopagamentoPorId == null)
            {
                throw new Exception($"Pagamento de cartão do Id: {id} não foi encontrado.");
            }

            _dbContext.CartoesPagamentos.Remove(cartaopagamentoPorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<CartaoPagamentoModel> Atualizar(CartaoPagamentoModel cartaopagamento, int id)
        {
            CartaoPagamentoModel cartaopagamentoPorId = await BuscarPorId(id);

            if (cartaopagamentoPorId == null)
            {
                throw new Exception($"Pagamento de cartão do Id: {id} não foi encontrado.");
            }

            cartaopagamentoPorId.CartaoId = cartaopagamento.CartaoId;
            cartaopagamentoPorId.PagamentoId = cartaopagamento.PagamentoId;

            _dbContext.CartoesPagamentos.Update(cartaopagamentoPorId);
            await _dbContext.SaveChangesAsync();

            return cartaopagamentoPorId;
        }

        public async Task<CartaoPagamentoModel> BuscarPorId(int id)
        {
            return await _dbContext.CartoesPagamentos.Include(x => x.Cartao).Include(y => y.Pagamento).FirstOrDefaultAsync(z => z.Id == id);
        }

        public async Task<List<CartaoPagamentoModel>> BuscarTodosCartoesPagamentos()
        {
            return await _dbContext.CartoesPagamentos.ToListAsync();
        }
    }
}
