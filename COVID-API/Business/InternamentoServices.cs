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
        public Task<Internamento> CreateAsync(Internamento internamento, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Serviço para a remoção de um internamento
        /// </summary>
        /// <param name="id">Identificador do internamento</param>
        /// <param name="ct">Cancellation Token - chamada asincrona</param>
        public Task DeleteAsync(int id, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Serviço para a lista de internamentos
        /// </summary>
        /// <param name="ct">Cancellation Token - chamada asincrona</param>
        /// <returns>Lista de internamentos</returns>
        public Task<ICollection<Internamento>> GetAllAsync(CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Serviço para a obtenção de um internamento
        /// </summary>
        /// <param name="id">Identificador do internamento</param>
        /// <param name="ct">Cancellation Token - chamada asincrona</param>
        /// <returns>View do internamento</returns>
        public Task<Internamento> GetByIdAsync(int id, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Serviço para a atualização dos dados de um internamento
        /// </summary>
        /// <param name="id">Identificador do internamento</param>
        /// <param name="internamento">Dados do internamento para gravar</param>
        /// <param name="ct">Cancellation Token - chamada asincrona</param>
        /// <returns>View do internamento</returns>
        public Task<Internamento> UpdateAsync(int id, Internamento internamento, CancellationToken ct)
        {
            throw new NotImplementedException();
        }
    }
}
