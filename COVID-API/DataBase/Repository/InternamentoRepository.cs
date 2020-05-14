using DataBase.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataBase.Repository
{
    public class InternamentoRepository : IRepository<Internamento>
    {
        public Task<Internamento> CreateAsync(Internamento entity, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Internamento entity, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Internamento>> GetAllAsync(CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task<Internamento> GetAsync(int id, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task<Internamento> UpdateAsync(Internamento entity, CancellationToken ct)
        {
            throw new NotImplementedException();
        }
    }
}
