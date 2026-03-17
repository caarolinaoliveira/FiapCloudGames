
namespace FCG.Infrastructure.Context
{
    
    public class FcgDbContext : DbContext
    {
        public FcgDbContext(DbContextOptions<FcgDbContext> options) : base(options)
        {
        }

        public DbSet<UsuarioEntity> Usuarios { get; set; }
        public DbSet<JogoEntity> Jogos { get; set; }
        public DbSet<BibliotecaUsuarioEntity> Bibliotecas { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(FcgDbContext).Assembly);
        }
        
    }
}