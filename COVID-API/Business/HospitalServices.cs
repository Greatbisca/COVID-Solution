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
        public async Task<Hospital> CreateAsync(Hospital hospital, CancellationToken ct)
        {
            try
            {
                return await _hospitalRepository.CreateAsync(hospital, ct);
            } catch(Exception e)
            {
                throw new Exception("Ocorreu um erro na criação do hospital.", e);
            }
        }

        /// <summary>
        /// Serviço para a remoçao de um hospital
        /// </summary>
        /// <param name="id">Identificador do hospital</param>
        /// <param name="ct">Cancellation Token - chamada asincrona</param>
        /// <returns></returns>
        public async Task DeleteAsync(int id, CancellationToken ct)
        {
            try
            {
                var hospital = await _hospitalRepository.GetAsync(id, ct);
                await _hospitalRepository.DeleteAsync(hospital, ct);
            }
            catch (Exception e)
            {
                throw new Exception("Ocorreu um erro na eliminação do hospital.", e);
            }
        }

        /// <summary>
        /// Serviço para a lista de hospitais
        /// </summary>
        /// <param name="ct"> Cancellation Token - chamada asincrona </param>
        /// <returns>Lista de hospitais</returns>
        public async Task<ICollection<Hospital>> GetAllAsync(CancellationToken ct)
        {
            try
            {
                return await _hospitalRepository.GetAllAsync(ct);
            }
            catch (Exception e)
            {
                throw new Exception("Ocorreu um erro na obtenção da lista de hospitais.", e);
            }
        }

        /// <summary>
        /// Serviço para a obtençao de um hospital
        /// </summary>
        /// <param name="id">Identificador do hospital</param>
        /// <param name="ct">Cancellation Token - chamada asincrona</param>
        /// <returns>View do hospital</returns>
        public async Task<Hospital> GetByIdAsync(int id, CancellationToken ct)
        {
            try
            {
                return await _hospitalRepository.GetAsync(id, ct);
            }
            catch (Exception e)
            {
                throw new Exception("Ocorreu um erro na obtenção do hospital.", e);
            }
        }

        /// <summary>
        /// Serviço para a atualização dos dados de um hospital
        /// </summary>
        /// <param name="id">Identificador do hospital</param>
        /// <param name="hospital">Dados do hospital para gravar</param>
        /// <param name="ct">Cancellation Token - chamada asincrona</param>
        /// <returns>View do Hospital</returns>
        public async Task<Hospital> UpdateAsync(int id, Hospital hospital, CancellationToken ct)
        {
            try
            {
                var hospitalObject = await _hospitalRepository.GetAsync(id, ct);
                hospitalObject.Distrito = hospital.Distrito;
                hospitalObject.Nome = hospital.Nome;

                return await _hospitalRepository.UpdateAsync(hospitalObject, ct);
            }
            catch (Exception e)
            {
                throw new Exception("Ocorreu um erro na obtenção do hospital.", e);
            }
        }
    }
}
