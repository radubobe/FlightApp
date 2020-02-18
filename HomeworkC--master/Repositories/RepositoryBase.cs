using ConsoleApp2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Repositories
{
    public abstract class RepositoryBase<T>:IRepositoryBase<T> where T:class
    {
        protected Models.AppContext Context;
        public RepositoryBase(Models.AppContext appContext)
        { this.Context = appContext; }
        public async Task CreateAsync(T entity)
        {
           await Context.Set<T>().AddAsync(entity);
           await Context.SaveChangesAsync();
        }


        public IQueryable<T> FindAll()
        {
            return this.Context.Set<T>().AsNoTracking();
        }

        public IQueryable<T> GetOneByCondition(Expression<Func<T, bool>> expression)
        {
            return this.Context.Set<T>().Where(expression).AsNoTracking();
        }
       





        public T Update(T entity)
        {
            var result = Context.Set<T>().Update(entity).Entity;
            Context.SaveChanges();
            return result;
        }

        public void Delete(T entity)
        {
            this.Context.Set<T>().Remove(entity);
            Context.SaveChanges();
        }
        public  void DeleteFlight(int id)
        { 
            Flight fli= this.Context.Flight.FirstOrDefault(x => x.Id == id);
            this.Context.Remove(fli);
            Context.SaveChanges();
        }
        public async Task<List<T>> GetAllAsync()
        {
            return await Context.Set<T>().ToListAsync();
        }
        

        public async Task<T> GetOneByConditionAsync(Expression<Func<T, bool>> expression)
        {
            return await Context.Set<T>().FirstOrDefaultAsync(expression);
        }
    }
}
