using Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business
{
    /// <summary>
    /// Lógica de negócio - Serviços para os hospitais
    /// </summary>
    public class HospitalServices : IHospitalServices
    {
        /// <summary>
        /// Serviço para a criação de hospital
        /// </summary>
        /// <param name="hospital"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        public Task<DataBase.ViewModels.Hospital> CreateAsync(DataBase.Models.Hospital hospital, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<DataBase.ViewModels.Hospital>> GetAllAsync(CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task<DataBase.ViewModels.Hospital> GetByIdAsync(int id, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task<DataBase.ViewModels.Hospital> UpdateAsync(int id, DataBase.Models.Hospital hospital, CancellationToken ct)
        {
            throw new NotImplementedException();
        }
    }
}
