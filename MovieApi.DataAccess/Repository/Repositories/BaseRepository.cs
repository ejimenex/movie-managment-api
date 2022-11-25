



using MovieApi.DataAccess.Repository.Abstract;

namespace MovieApi.DataAccess.Repository.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseModel, new()
    {
        protected MovieApiDataContext context { get; set; }

        protected readonly DbSet<T> entities;
        protected BaseRepository(MovieApiDataContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }

        public virtual async Task<int> Create(T entity)
        {
            
                entity.CreatedDate = DateTime.Now;
                entity.IsDeleted = false;                
                var result = entities.Add(entity);
                await this.context.SaveChangesAsync();
                return Convert.ToInt32(result.Property("Id").CurrentValue.ToString());
                      

        }

      
        public virtual async Task Delete(int Id)
        {
            var entity = await GetOne(Id);
            entity.IsDeleted = true;
            entity.ModifiedDate = DateTime.Now;
            await this.Update(entity);
        }
      
        public virtual IQueryable<T> FindAll()
        {
            var result = entities.OrderByDescending(c => c.Id).AsNoTracking();
            return result;
        }

        public virtual IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.context.Set<T>().Where(expression).AsNoTracking();
        }

        public virtual async Task<T> GetOne(int Id) => await context.Set<T>().AsNoTracking().FirstOrDefaultAsync(c => c.Id == Id);


        public virtual async Task<T> Update(T entity)
        {
            entity.ModifiedDate = DateTime.Now;
            this.context.Entry(entity).State = EntityState.Modified;
            await this.context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<bool> Exist(Expression<Func<T, bool>> expression) => (await this.context.Set<T>().AnyAsync(expression));

       
    }
}
