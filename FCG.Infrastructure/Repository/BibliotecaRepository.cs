using FCG.Domain.Entities;
using FCG.Domain.Interfaces;
using FCG.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace FCG.Infrastructure.Repository
{
    public class BibliotecaRepository : Repository<BibliotecaUsuarioEntity>, IBibliotecaRepository
    {
        public BibliotecaRepository(FcgDbContext db) : base(db)
        {
        }

        public async Task<IEnumerable<BibliotecaUsuarioEntity>> ObterPorUsuarioIdAsync(Guid usuarioId)
        {
            return await DbSet.AsNoTracking()
                .Include(b => b.Jogo)
                .Where(b => b.UsuarioId == usuarioId)
                .ToListAsync();
        }

        public async Task<bool> UsuarioPossuiJogoAsync(Guid usuarioId, Guid jogoId)
        {
            return await DbSet.AnyAsync(b => b.UsuarioId == usuarioId && b.JogoId == jogoId);
        }

        public async Task RemoverJogoDaBibliotecaAsync(Guid usuarioId, Guid jogoId)
        {
            var bibliotecaEntry = await DbSet.FirstOrDefaultAsync(b => b.UsuarioId == usuarioId && b.JogoId == jogoId);
            if (bibliotecaEntry != null)
            {
                DbSet.Remove(bibliotecaEntry);
                await SaveChangesAsync();
            }
        }
    }
}