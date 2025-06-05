using SaberKids.Models;

namespace SaberKids.Repositorios.Interfaces
{
    public interface IMateriaRepositorio
    {
        Task<List<MateriaModel>> BuscarTodasMaterias();
        Task<MateriaModel> BuscarPorId(int id);
        Task<MateriaModel> Adicionar(MateriaModel materia);
        Task<MateriaModel> Atualizar(MateriaModel materia, int id);
        Task<bool> Apagar(int id);
    }
}
