using Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business
{
    public class TesteServices : ITesteServices
    {
        public Task<DataBase.ViewModels.Teste> CreateAsync(DataBase.Models.Teste teste, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<DataBase.ViewModels.Teste>> GetAllAsync(CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task<DataBase.ViewModels.Teste> GetByIdAsync(int id, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task<DataBase.ViewModels.Teste> UpdateAsync(int id, DataBase.Models.Teste teste, CancellationToken ct)
        {
            throw new NotImplementedException();
        }
    }
}
