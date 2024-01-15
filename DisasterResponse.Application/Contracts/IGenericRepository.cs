using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DisasterResponse.Application.Contracts
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T>  GetByIdAsync(int id);
        Task<IReadOnlyList<T>> ListAllAsync();
        Task<bool> IsValidIdAsync(int id);
        
        Task<T> AddAsync(T entity);
        void UpdateAsync(T entity);
        void DeleteAsync(T entity);
    }
}
