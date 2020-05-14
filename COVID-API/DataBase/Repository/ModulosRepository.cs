using DataBase.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataBase.Repository
{
    public class ModulosRepository : IRepository<Modulos>
    {
        public Task<Modulos> CreateAsync(Modulos entity, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Modulos entity, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Modulos>> GetAllAsync(CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task<Modulos> GetAsync(int id, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task<Modulos> UpdateAsync(Modulos entity, CancellationToken ct)
        {
            throw new NotImplementedException();
        }
    }
}
