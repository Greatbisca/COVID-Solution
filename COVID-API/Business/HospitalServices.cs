using Business.Interfaces;
using DataBase.Models;
using DataBase.Repository;
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

        private IRepository<Hospital> _hospitalRepository;
        public HospitalServices(IRepository<Hospital> hospitalRepository)
        {
            _hospitalRepository = hospitalRepository;
        }
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

        /// <summary>
        /// Serviço para a remoçao de um hospital
        /// </summary>
        /// <param name="id">Identificador do hospital</param>
        /// <param name="ct">Cancellation Token - chamada asincrona</param>
        /// <returns></returns>
        public Task DeleteAsync(int id, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Serviço para a lista de hospitais
        /// </summary>
        /// <param name="ct"> Cancellation Token - chamada asincrona </param>
        /// <returns>Lista de hospitais</returns>
        public Task<ICollection<DataBase.ViewModels.Hospital>> GetAllAsync(CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Serviço para a obtençao de um hospital
        /// </summary>
        /// <param name="id">Identificador do hospital</param>
        /// <param name="ct">Cancellation Token - chamada asincrona</param>
        /// <returns>View do hospital</returns>
        public Task<DataBase.ViewModels.Hospital> GetByIdAsync(int id, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Serviço para a atualização dos dados de um hospital
        /// </summary>
        /// <param name="id">Identificador do hospital</param>
        /// <param name="hospital">Dados do hospital para gravar</param>
        /// <param name="ct">Cancellation Token - chamada asincrona</param>
        /// <returns>View do Hospital</returns>
        public Task<DataBase.ViewModels.Hospital> UpdateAsync(int id, DataBase.Models.Hospital hospital, CancellationToken ct)
        {
            throw new NotImplementedException();
        }
    }
}
