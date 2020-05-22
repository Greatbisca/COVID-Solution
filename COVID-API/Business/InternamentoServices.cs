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
    /// Logica do Negocio - Serviços para os internamentos
    /// </summary>
    public class InternamentoServices : IInternamentoServices
    {
        private IRepository<Internamento> _internamentoRepository;

        /// <summary>
        /// Construtor com Dependency Injection
        /// </summary>
        /// <param name="internamentoRepository"></param>
        public InternamentoServices(IRepository<Internamento> internamentoRepository)
        {
            _internamentoRepository = internamentoRepository;
        }

        /// <summary>
        /// Serviço para a criação de internamento
        /// </summary>
        /// <param name="internamento">Objeto Internamento para a criação na base de dados</param>
        /// <param name="ct">Cancellation Token - chamada asincrona</param>
        /// <returns>View do internamento</returns>
        public async Task<Internamento> CreateAsync(Internamento internamento, CancellationToken ct)
        {
            try
            {
                return await _internamentoRepository.CreateAsync(internamento, ct);
            }
            catch (Exception e)
            {
                throw new Exception("Ocorreu um erro na criação do internamento.", e);
            }
        }

        /// <summary>
        /// Serviço para a remoção de um internamento
        /// </summary>
        /// <param name="id">Identificador do internamento</param>
        /// <param name="ct">Cancellation Token - chamada asincrona</param>
        public async Task DeleteAsync(int id, CancellationToken ct)
        {
            try
            {
                var internamento = await _internamentoRepository.GetAsync(id, ct);
                await _internamentoRepository.DeleteAsync(internamento, ct);
            }
            catch (Exception e)
            {
                throw new Exception("Ocorreu um erro na eliminação do internamento.", e);
            }
        }

        /// <summary>
        /// Serviço para a lista de internamentos
        /// </summary>
        /// <param name="ct">Cancellation Token - chamada asincrona</param>
        /// <returns>Lista de internamentos</returns>
        public async Task<ICollection<Internamento>> GetAllAsync(CancellationToken ct)
        {
            try
            {
                return await _internamentoRepository.GetAllAsync(ct);
            }
            catch (Exception e)
            {
                throw new Exception("Ocorreu um erro na obtenção da lista de internamentos.", e);
            }
        }

        /// <summary>
        /// Serviço para a obtenção de um internamento
        /// </summary>
        /// <param name="id">Identificador do internamento</param>
        /// <param name="ct">Cancellation Token - chamada asincrona</param>
        /// <returns>View do internamento</returns>
        public async Task<Internamento> GetByIdAsync(int id, CancellationToken ct)
        {
            try
            {
                return await _internamentoRepository.GetAsync(id, ct);
            }
            catch (Exception e)
            {
                throw new Exception("Ocorreu um erro na obtenção do internamento.", e);
            }
        }

        /// <summary>
        /// Serviço para a atualização dos dados de um internamento
        /// </summary>
        /// <param name="id">Identificador do internamento</param>
        /// <param name="internamento">Dados do internamento para gravar</param>
        /// <param name="ct">Cancellation Token - chamada asincrona</param>
        /// <returns>View do internamento</returns>
        public async Task<Internamento> UpdateAsync(int id, Internamento internamento, CancellationToken ct)
        {
            try
            {
                var internamentoObject = await _internamentoRepository.GetAsync(id, ct);
                internamentoObject.Data_Alta = internamento.Data_Alta;
                internamentoObject.Data_Internamento = internamento.Data_Internamento;
                internamento.Id_Doente = internamento.Id_Doente;
                internamento.Id_Hospital = internamento.Id_Hospital;

                return await _internamentoRepository.UpdateAsync(internamentoObject, ct);
            }
            catch (Exception e)
            {
                throw new Exception("Ocorreu um erro na actualização do internamento.", e);
            }
        }
    }
}
