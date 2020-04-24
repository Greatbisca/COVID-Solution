using Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business
{
    class UtilizadoresServices : IUtilizadoresServices
    {
        public Task<DataBase.ViewModels.Utilizadores> CreateAsync(DataBase.Models.Utilizadores utilizadores, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<DataBase.ViewModels.Utilizadores>> GetAllAsync(CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task<DataBase.ViewModels.Utilizadores> GetByIdAsync(int id, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task<DataBase.ViewModels.Utilizadores> UpdateAsync(int id, DataBase.Models.Utilizadores utilizadores, CancellationToken ct)
        {
            throw new NotImplementedException();
        }
    }
}
