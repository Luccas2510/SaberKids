using SaberKids.Models;

namespace SaberKids.Repositorios.Interfaces
{
    public interface ICartaoPagamentoRepositorio
    {
        Task<List<CartaoPagamentoModel>> BuscarTodosCartoesPagamentos();
        Task<CartaoPagamentoModel> BuscarPorId(int id);
        Task<CartaoPagamentoModel> Adicionar(CartaoPagamentoModel cartaopagamento);
        Task<CartaoPagamentoModel> Atualizar(CartaoPagamentoModel cartaopagamento, int id);
        Task<bool> Apagar(int id);
    }
}
