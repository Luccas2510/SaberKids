using Microsoft.EntityFrameworkCore;
using SaberKids.Data;
using SaberKids.Models;
using SaberKids.Repositorios.Interfaces;

namespace SaberKids.Repositorios
{
    public class CartaoRepositorio : ICartaoRepositorio
    {
        private readonly SaberKidsDbContext _dbContext;

        public CartaoRepositorio(SaberKidsDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<CartaoModel> Adicionar(CartaoModel cartao)
        {
            await _dbContext.Cartoes.AddAsync(cartao);
            await _dbContext.SaveChangesAsync();

            return cartao;
        }

        public async Task<bool> Apagar(int id)
        {
            CartaoModel cartaoPorId = await BuscarPorId(id);

            if (cartaoPorId == null)
            {
                throw new Exception($"Cartão do Id: {id} não foi encontrado.");
            }

            _dbContext.Cartoes.Remove(cartaoPorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<CartaoModel> Atualizar(CartaoModel cartao, int id)
        {
            CartaoModel cartaoPorId = await BuscarPorId(id);

            if (cartaoPorId == null)
            {
                throw new Exception($"Cartão do Id: {id} não foi encontrado.");
            }

            cartaoPorId.NomeCartao = cartao.NomeCartao;
            cartaoPorId.NumeroCartao = cartao.NumeroCartao;
            cartaoPorId.BandeiraCartao = cartao.BandeiraCartao;
            cartaoPorId.Descricao = cartao.Descricao;
            cartaoPorId.BandeiraCartao = cartao.BandeiraCartao;
            cartaoPorId.CodeCartao = cartao.CodeCartao;
            cartaoPorId.DataVenci = cartao.DataVenci;
            cartaoPorId.TipoCartao = cartao.TipoCartao;

            _dbContext.Cartoes.Update(cartaoPorId);
            await _dbContext.SaveChangesAsync();

            return cartaoPorId;
        }

        public async Task<CartaoModel> BuscarPorId(int id)
        {
            return await _dbContext.Cartoes.FirstOrDefaultAsync(x => x.Id == id);

        }

        public async Task<List<CartaoModel>> BuscarTodosCartoes()
        {
            return await _dbContext.Cartoes.ToListAsync();
        }
    }
}
