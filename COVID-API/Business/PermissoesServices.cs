using Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business
{
    public class PermissoesServices : IPermissoesServices
    {
        public Task<DataBase.ViewModels.Permissoes> CreateAsync(DataBase.Models.Permissoes permissoes, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<DataBase.ViewModels.Permissoes>> GetAllAsync(CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task<DataBase.ViewModels.Permissoes> GetByIdAsync(int id, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task<DataBase.ViewModels.Permissoes> UpdateAsync(int id, DataBase.Models.Permissoes permissoes, CancellationToken ct)
        {
            throw new NotImplementedException();
        }
    }
}
