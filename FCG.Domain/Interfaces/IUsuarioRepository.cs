using FCG.Domain.Entities;

namespace FCG.Domain.Interfaces
{
    public interface IUsuarioRepository : IRepository<UsuarioEntity>
    {
        Task<UsuarioEntity?> ObterPorEmailAsync(string email);
        Task<bool> EmailJaCadastradoAsync(string email);
    }
}