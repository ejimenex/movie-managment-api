namespace MovieApi.DataAccess.Repository.Abstract;
public interface IBaseRepository<T>
{
    IQueryable<T> FindAll();
    IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
    bool Exist(Expression<Func<T, bool>> expression);
    Task<T> GetOne(int Id);
    Task<int> Create(T entity);
    Task<T> Update(T entity);
    Task Delete(int Id);

}