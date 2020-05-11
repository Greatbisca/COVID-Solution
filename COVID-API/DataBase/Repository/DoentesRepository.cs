using DataBase.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataBase.Repository
{
    public class DoentesRepository : IRepository<Doente>
    {
        public Task<Doente> CreateAsync(Doente entity, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Doente entity, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Doente>> GetAllAsync(CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task<Doente> GetAsync(int id, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task<Doente> UpdateAsync(Doente entity, CancellationToken ct)
        {
            throw new NotImplementedException();
        }
    }
}
