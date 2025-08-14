using SaberKids.Models;

namespace SaberKids.Repositorios.Interfaces
{
    public interface IPagamentoRepositorio
    {
        Task<List<PagamentoModel>> BuscarTodosPagamentos();
        Task<PagamentoModel> BuscarPorId(int id);
        Task<PagamentoModel> Adicionar(PagamentoModel pagamento);
        Task<PagamentoModel> Atualizar(PagamentoModel pagamento, int id);
        Task<bool> Apagar(int id);
    }
}
