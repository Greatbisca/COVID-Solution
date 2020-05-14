using DataBase.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataBase.Repository
{
    public class Profissionais_SaudeRepository : IRepository<Profissionais_Saude>
    {
        public Task<Profissionais_Saude> CreateAsync(Profissionais_Saude entity, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Profissionais_Saude entity, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Profissionais_Saude>> GetAllAsync(CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task<Profissionais_Saude> GetAsync(int id, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task<Profissionais_Saude> UpdateAsync(Profissionais_Saude entity, CancellationToken ct)
        {
            throw new NotImplementedException();
        }
    }
}
