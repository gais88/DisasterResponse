using DisasterResponse.Application.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisasterResponse.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly AppDbContext _dbContext;

        public GenericRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual  async Task<T> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }
        public virtual async Task<bool> IsValidIdAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id) != null ? true:false;
        }

        public virtual async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public virtual async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);

            return entity;
        }

        public void UpdateAsync(T entity)
        {
           
            _dbContext.Entry(entity).State = EntityState.Modified;
            
           
        }

        public void  DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
        }

       
    }
}
