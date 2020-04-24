using Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business
{
    public class InternamentoServices : IInternamentoServices
    {
        public Task<DataBase.ViewModels.Internamento> CreateAsync(DataBase.Models.Internamento internamento, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<DataBase.ViewModels.Internamento>> GetAllAsync(CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task<DataBase.ViewModels.Internamento> GetByIdAsync(int id, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task<DataBase.ViewModels.Internamento> UpdateAsync(int id, DataBase.Models.Internamento internamento, CancellationToken ct)
        {
            throw new NotImplementedException();
        }
    }
}
