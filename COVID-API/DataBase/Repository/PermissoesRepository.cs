using DataBase.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataBase.Repository
{
    public class PermissoesRepository : IRepository<Permissoes>
    {
        public Task<Permissoes> CreateAsync(Permissoes entity, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Permissoes entity, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Permissoes>> GetAllAsync(CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task<Permissoes> GetAsync(int id, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task<Permissoes> UpdateAsync(Permissoes entity, CancellationToken ct)
        {
            throw new NotImplementedException();
        }
    }
}
