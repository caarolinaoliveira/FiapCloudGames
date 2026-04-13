using FCG.Infrastructure.Context;
using FCG.Domain.Entities;
using FCG.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace FCG.Infrastructure.Repository
{
    public class UsuarioRepository: Repository<UsuarioEntity>, IUsuarioRepository
    {
        public UsuarioRepository(FcgDbContext db) : base(db)
        {
        }
        public async Task<UsuarioEntity> ObterPorEmailAsync(string email)
        {
            return await DbSet.AsNoTracking()
                .FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<bool> EmailJaCadastradoAsync(string email)
        {
            return await DbSet.AnyAsync(u => u.Email == email);
        }

        public async Task DeletarAsync(UsuarioEntity usuario)
        {
            DbSet.Remove(usuario);
            await SaveChangesAsync();
        }
    }
}