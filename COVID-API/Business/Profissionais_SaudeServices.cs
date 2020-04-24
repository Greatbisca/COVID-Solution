using Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business
{
    public class Profissionais_SaudeServices : IProfissionais_SaudeServices
    {
        public Task<DataBase.ViewModels.Profissionais_Saude> CreateAsync(DataBase.Models.Profissionais_Saude profissionais_saude, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<DataBase.ViewModels.Profissionais_Saude>> GetAllAsync(CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task<DataBase.ViewModels.Profissionais_Saude> GetByIdAsync(int id, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task<DataBase.ViewModels.Profissionais_Saude> UpdateAsync(int id, DataBase.Models.Profissionais_Saude profissionais_saude, CancellationToken ct)
        {
            throw new NotImplementedException();
        }
    }
}
