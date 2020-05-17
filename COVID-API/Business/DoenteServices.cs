using Business.Interfaces;
using DataBase.Models;
using DataBase.Repository;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Business
{
    /// <summary>
    /// Lógica de negócio - Serviços para os doentes
    /// </summary>
    public class DoenteServices : IDoenteServices
    {
        private IRepository<Doente> _doenteRepository;

        /// <summary>
        /// Construtor com Dependency Injection
        /// </summary>
        /// <param name="doenteRepository"></param>
        public DoenteServices(IRepository<Doente> doenteRepository)
        {
            _doenteRepository = doenteRepository;
        }

        /// <summary>
        /// Serviço para a criação de doente
        /// </summary>
        /// <param name="doente">Objecto Doente para criação na base de dados</param>
        /// <param name="ct">Cancellation Token - chamada asincrona</param>
        /// <returns>View do doente criado</returns>
        public Task<Doente> CreateAsync(
            Doente doente, 
            CancellationToken ct
        )
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Serviço para a remoção de um doente
        /// </summary>
        /// <param name="id">Identificador do doente</param>
        /// <param name="ct">Cancellation Token - chamada asincrona</param>
        public Task DeleteAsync(
            int id, 
            CancellationToken ct
        )
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Serviço para a lista de doentes
        /// </summary>
        /// <param name="ct">Cancellation Token - chamada asincrona</param>
        /// <returns>Lista de doentes</returns>
        public Task<ICollection<Doente>> GetAllAsync(
            CancellationToken ct
        )
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Serviço para a obtenção de um doente
        /// </summary>
        /// <param name="id">Identificador do doente</param>
        /// <param name="ct">Cancellation Token - chamada asincrona</param>
        /// <returns>View do doente</returns>
        public Task<Doente> GetByIdAsync(
            int id, 
            CancellationToken ct
        )
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Serviço para a atualização dos dados de um doente
        /// </summary>
        /// <param name="id">Identificador do doente</param>
        /// <param name="doente">Dados do doente para gravar</param>
        /// <param name="ct">Cancellation Token - chamada asincrona</param>
        /// <returns>View do doente</returns>
        public Task<Doente> UpdateAsync(
            int id, 
            Doente doente, 
            CancellationToken ct
        )
        {
            throw new NotImplementedException();
        }
    }
}
