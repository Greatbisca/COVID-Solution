using DataBase.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataBase.Repository
{
    public class TestesRepository : IRepository<Teste>
    {
        public Task<Teste> CreateAsync(Teste entity, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Teste entity, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Teste>> GetAllAsync(CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task<Teste> GetAsync(int id, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task<Teste> UpdateAsync(Teste entity, CancellationToken ct)
        {
            throw new NotImplementedException();
        }
    }
}
