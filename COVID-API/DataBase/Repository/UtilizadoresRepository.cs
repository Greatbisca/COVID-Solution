using DataBase.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataBase.Repository
{
    public class UtilizadoresRepository : IRepository<Utilizadores>
    {
        public Task<Utilizadores> CreateAsync(Utilizadores entity, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Utilizadores entity, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Utilizadores>> GetAllAsync(CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task<Utilizadores> GetAsync(int id, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task<Utilizadores> UpdateAsync(Utilizadores entity, CancellationToken ct)
        {
            throw new NotImplementedException();
        }
    }
}
