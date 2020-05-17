using Business.Interfaces;
using DataBase.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business
{
    public class UtilizadoresServices : IUtilizadoresServices
    {
        public Task<Utilizadores> CreateAsync(Utilizadores utilizador, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task<Utilizadores> GetByIdAsync(int id, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task<Utilizadores> UpdateAsync(int id, Utilizadores utilizador, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task<string> ValidateLoginAsync(string username, string password, CancellationToken ct)
        {
            throw new NotImplementedException();
        }
    }
}
