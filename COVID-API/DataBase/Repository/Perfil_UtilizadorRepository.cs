using DataBase.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataBase.Repository
{
    public class Perfil_UtilizadorRepository : IRepository<Perfil_Utilizador>
    {
        public Task<Perfil_Utilizador> CreateAsync(Perfil_Utilizador entity, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Perfil_Utilizador entity, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Perfil_Utilizador>> GetAllAsync(CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task<Perfil_Utilizador> GetAsync(int id, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task<Perfil_Utilizador> UpdateAsync(Perfil_Utilizador entity, CancellationToken ct)
        {
            throw new NotImplementedException();
        }
    }
}
