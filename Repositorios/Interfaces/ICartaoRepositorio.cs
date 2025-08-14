using SaberKids.Models;

namespace SaberKids.Repositorios.Interfaces
{
    public interface ICartaoRepositorio
    {
        Task<List<CartaoModel>> BuscarTodosCartoes();
        Task<CartaoModel> BuscarPorId(int id);
        Task<CartaoModel> Adicionar(CartaoModel cartao);
        Task<CartaoModel> Atualizar(CartaoModel cartao, int id);
        Task<bool> Apagar(int id);
    }
}
