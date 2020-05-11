using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataBase.Repository
{
    public interface IRepository<T>
    {
       
            Task<T> CreateAsync(T entity, CancellationToken ct);
            Task<T> UpdateAsync(T entity, CancellationToken ct);
            Task<T> GetAsync(int id, CancellationToken ct);
            Task<ICollection<T>> GetAllAsync(CancellationToken ct);
            Task DeleteAsync(T entity, CancellationToken ct);
        
    }
}
