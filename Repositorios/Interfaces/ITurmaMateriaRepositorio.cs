using SaberKids.Models;

namespace SaberKids.Repositorios.Interfaces
{
    public interface ITurmaMateriaRepositorio
    {
        Task<List<TurmaMateriaModel>> BuscarTodasTurmasMaterias();
        Task<TurmaMateriaModel> BuscarPorId(int id);
        Task<TurmaMateriaModel> Adicionar(TurmaMateriaModel turmamateria);
        Task<TurmaMateriaModel> Atualizar(TurmaMateriaModel turmamateria, int id);
        Task<bool> Apagar(int id);
    }
}
