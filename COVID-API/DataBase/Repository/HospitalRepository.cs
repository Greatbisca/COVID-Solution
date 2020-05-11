using DataBase.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataBase.Repository
{
    public class HospitalRepository : IRepository<Hospital>
    {
        public Task<Hospital> CreateAsync(Hospital entity, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Hospital entity, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Hospital>> GetAllAsync(CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task<Hospital> GetAsync(int id, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task<Hospital> UpdateAsync(Hospital entity, CancellationToken ct)
        {
            throw new NotImplementedException();
        }
    }
}
