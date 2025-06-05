using Microsoft.EntityFrameworkCore;
using SaberKids.Data;
using SaberKids.Models;
using SaberKids.Repositorios.Interfaces;

namespace SaberKids.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly SaberKidsDbContext _dbContext;

        public UsuarioRepositorio(SaberKidsDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<UsuarioModel> Adicionar(UsuarioModel usuario)
        {
            await _dbContext.Usuarios.AddAsync(usuario);
            await _dbContext.SaveChangesAsync();

            return usuario;
        }

        public async Task<bool> Apagar(int id)
        {
            UsuarioModel usuarioPorId = await BuscarPorId(id);

            if (usuarioPorId == null)
            {
                throw new Exception($"Usuario do Id: {id} não foi encontrado.");
            }

            _dbContext.Usuarios.Remove(usuarioPorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<UsuarioModel> Atualizar(UsuarioModel usuario, int id)
        {
            UsuarioModel usuarioPorId = await BuscarPorId(id);

            if (usuarioPorId == null)
            {
                throw new Exception($"Usuario do Id: {id} não encontrado.");
            }

            usuarioPorId.NomeResp = usuario.NomeResp;
            usuarioPorId.NomeAluno = usuario.NomeAluno;
            usuarioPorId.Email = usuario.Email;
            usuarioPorId.Senha = usuario.Senha;
            usuarioPorId.CPF = usuario.CPF;

            _dbContext.Usuarios.Update(usuarioPorId);
            await _dbContext.SaveChangesAsync();

            return usuarioPorId;
        }

        public async Task<UsuarioModel> BuscarPorId(int id)
        {
            return await _dbContext.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<UsuarioModel>> BuscarTodosUsuarios()
        {
            return await _dbContext.Usuarios.ToListAsync();
        }
    }
}
