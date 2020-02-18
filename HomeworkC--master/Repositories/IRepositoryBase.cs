using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Repositories
{
   public interface IRepositoryBase<T>
    {
        IQueryable<T> FindAll();
        IQueryable<T> GetOneByCondition(Expression<Func<T,bool>> expression);

        Task<List<T>> GetAllAsync();
        Task<T> GetOneByConditionAsync(Expression<Func<T, bool>> expression);
        Task CreateAsync(T entity);
        T Update(T entity);
        void Delete(T entity);
        void DeleteFlight(int id);
    }
}
