using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Member.Data.Management
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> Query();

        ICollection<T> GetAll();

        Task<ICollection<T>> GetAllAsync();

        T GetById(int id);

        Task<T> GetByIdAsync(int id);

        T GetByUniqueId(string id);

        Task<T> GetByUniqueIdAsync(string id);

        T Find(Expression<Func<T, bool>> match);

        Task<T> FindAsync(Expression<Func<T, bool>> match);

        ICollection<T> FindAll(Expression<Func<T, bool>> match);

        Task<ICollection<T>> FindAllAsync(Expression<Func<T, bool>> match);

        T Add(T entity);

        Task<T> AddAsync(T entity);
        Task<List<T>> AddRangeAsync(List<T> entities);

        T Update(T updated);

        Task<T> UpdateAsync(T updated);

        void Delete(T t);

        Task<int> DeleteAsync(T t);
    }
}
