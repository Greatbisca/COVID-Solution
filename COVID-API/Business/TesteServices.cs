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
    /// Logica do Negocio - Serviços para os teste
    /// </summary>
    public class TesteServices : ITesteServices
    {
        private IRepository<Teste> _testeRepository;

        /// <summary>
        /// Construtor com Dependency Injection
        /// </summary>
        /// <param name="testeRepository"></param>
        public TesteServices(IRepository<Teste> testeRepository)
        {
            _testeRepository = testeRepository;
        }

        /// <summary>
        /// Serviço para a criação do teste
        /// </summary>
        /// <param name="teste">Objeto Teste para a criação na base de dados</param>
        /// <param name="ct">Cancellation Token - chamada asincrona</param>
        /// <returns>View do teste criado</returns>
        public Task<DataBase.ViewModels.Teste> CreateAsync(DataBase.Models.Teste teste, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Serviço para a remoção de um teste
        /// </summary>
        /// <param name="id">Identificador do teste</param>
        /// <param name="ct">Cancellation Token - chamada asincrona</param>
        public Task DeleteAsync(int id, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Serviço para a lista de testes
        /// </summary>
        /// <param name="ct">Cancellation Token - chamada asincrona</param>
        /// <returns>Lista de Testes</returns>
        public Task<ICollection<DataBase.ViewModels.Teste>> GetAllAsync(CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Serviço para a obtenção de um teste
        /// </summary>
        /// <param name="id">Identificador de um teste</param>
        /// <param name="ct">Cancellation Token - chamada asincrona</param>
        /// <returns>View do teste</returns>
        public Task<DataBase.ViewModels.Teste> GetByIdAsync(int id, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Serviço para o atualização dos dados de um teste
        /// </summary>
        /// <param name="id">Identificador do teste</param>
        /// <param name="teste">Dados do teste para gravar</param>
        /// <param name="ct">Cancellation Token - chamada asincrona</param>
        /// <returns>View do teste</returns>
        public Task<DataBase.ViewModels.Teste> UpdateAsync(int id, DataBase.Models.Teste teste, CancellationToken ct)
        {
            throw new NotImplementedException();
        }
    }
}
