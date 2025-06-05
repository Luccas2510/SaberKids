using SaberKids.Models;

namespace SaberKids.Repositorios.Interfaces
{
    public interface ITurmaRepositorio
    {
        Task<List<TurmaModel>> BuscarTodasTurmas();
        Task<TurmaModel> BuscarPorId(int id);
        Task<TurmaModel> Adicionar(TurmaModel turma);
        Task<TurmaModel> Atualizar(TurmaModel turma, int id);
        Task<bool> Apagar(int id);
    }
}
