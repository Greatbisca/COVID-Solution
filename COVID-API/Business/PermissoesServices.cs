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
    public class PermissoesServices : IPermissoesServices
    {
        private IRepository<Permissoes> _permissoesRepository;

        /// <summary>
        /// Construtor com Dependency Injection
        /// </summary>
        /// <param name="permissoesRepository"></param>
        public PermissoesServices(IRepository<Permissoes> permissoesRepository)
        {
            _permissoesRepository = permissoesRepository;
        }

        /// <summary>
        /// Serviço para a criação de permissao
        /// </summary>
        /// <param name="permissoes">Objeto Permissao para a criaçao na base de dados</param>
        /// <param name="ct">Cancellation Token - chamada asincrona</param>
        /// <returns>View da permissao criada</returns>
        public Task<DataBase.ViewModels.Permissoes> CreateAsync(DataBase.Models.Permissoes permissoes, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Serviço para a remoçao de uma permissao
        /// </summary>
        /// <param name="id">Identificador da permissao</param>
        /// <param name="ct">Cancellation Token - chamada asincrona</param>
        /// <returns></returns>
        public Task DeleteAsync(int id, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Serviço para a lista de permissoes
        /// </summary>
        /// <param name="ct">Cancellation Token - chamada asincrona</param>
        /// <returns>Lista de permissoes</returns>
        public Task<ICollection<DataBase.ViewModels.Permissoes>> GetAllAsync(CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Serviço para a obtençao de uma permissao
        /// </summary>
        /// <param name="id">Identificador da permissao</param>
        /// <param name="ct">Cancellation Token - chamada asincrona</param>
        /// <returns>View da permissao</returns>
        public Task<DataBase.ViewModels.Permissoes> GetByIdAsync(int id, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Serviço para a atualização de dados de uma permiçao
        /// </summary>
        /// <param name="id">Identificador da permissao</param>
        /// <param name="permissoes">Dados da permissao para gravar</param>
        /// <param name="ct">Cancellation Token - chamada asincrona</param>
        /// <returns>View da permissao</returns>
        public Task<DataBase.ViewModels.Permissoes> UpdateAsync(int id, DataBase.Models.Permissoes permissoes, CancellationToken ct)
        {
            throw new NotImplementedException();
        }
    }
}
