using FCG.Domain.Entities;
using FCG.Domain.Interfaces;

namespace FCG.Domain.interfaces

{
    public interface IUsuarioRepository : IRepository<UsuarioEntity>
    {
        Task<UsuarioEntity> ObterPorEmailAsync(string email);

    }
}