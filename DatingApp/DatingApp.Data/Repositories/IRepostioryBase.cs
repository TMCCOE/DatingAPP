using System.Linq.Expressions;

namespace DatingApp.Data.Repositories
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> FindAll();
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
        void Create(T entity);
        void CreateRange(T[] entities);
        void Update(T entity);
        void UpdateRange(T[] entitie);
        void Delete(T entity);
        void DeleteRange(T[] entitie);
    }
}
