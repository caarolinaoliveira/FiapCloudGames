namespace FCG.Infrastructure.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        protected readonly MeuDbContext Db ;
        protected readonly DbSet<TEntity> DbSet;


        protected Repository(MeuDbContext db)
        {
            Db = db;
            DbSet = db.Set<TEntity>();
        }
        
        public virtual async Task<TEntity> ObterPorId(Guid id)
        {
            return await DbSet.FindAsync(id);
        }
        public virtual async Task<IEnumerable<TEntity>> ObterTodos()
        {
            return await DbSet..AsNoTracking().ToListAsync();
        }
        public async Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
        }
        public virtual async Task Adicionar(TEntity entity)
        {
            DbSet.Add(entity);
            await SaveChanges();
        }

        public virtual async Task Atualizar(TEntity entity)
        {
            DbSet.Update(entity);
            await SaveChanges();
        }
        public virtual async Task Remover(Guid id)
        {
            var entity = DbSet.Local.FirstOrDefault(e => e.Id == id) ?? DbSet.Find(id);
            
            if (entity != null)
            {
                DbSet.Remove(entity);
                await SaveChanges();
            }
        }

        protected async Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync();
        }
        public void Dispose()
        {
            Db?.Dispose();
        }

        
    }
}