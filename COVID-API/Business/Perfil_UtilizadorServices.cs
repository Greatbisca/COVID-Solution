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
    public class Perfil_UtilizadorServices : IPerfil_UtilizadoresServices
    {
        private IRepository<Perfil_Utilizador> _perfil_utilizadorRepository;

        /// <summary>
        /// Construtor do Dependency Injection
        /// </summary>
        /// <param name="perfil_utilizadorRepository"></param>
        public Perfil_UtilizadorServices(IRepository<Perfil_Utilizador> perfil_utilizadorRepository)
        {
            _perfil_utilizadorRepository = perfil_utilizadorRepository;
        }

        /// <summary>
        /// Serviço para a criação de Perfil Utilizador
        /// </summary>
        /// <param name="perfil_utilizador">Objeto Perfil Utilizador para a criação na base de dados</param>
        /// <param name="ct">Cancellation Token - chamada asincrona</param>
        /// <returns>View do Perfil Utilizador</returns>
        public Task<Perfil_Utilizador> CreateAsync(Perfil_Utilizador perfil_utilizador, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Serviço para a remoçao do Perfil Utilizador
        /// </summary>
        /// <param name="id">Identificador do Perfil Utilizador</param>
        /// <param name="ct">Cancellation Token - chamada asincrona</param>
        public Task DeleteAsync(int id, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Serviço para a lista de Perfil Utilizadores
        /// </summary>
        /// <param name="ct">Cancellation Token - chamada asincrona</param>
        /// <returns>Lista de Perfil Utilizadores</returns>
        public Task<ICollection<Perfil_Utilizador>> GetAllAsync(CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Serviço para a obtençao do Perfil Utilizador
        /// </summary>
        /// <param name="id">Identificador do Perfil Utilizador</param>
        /// <param name="ct">Cancellation Token - chamada asincrona</param>
        /// <returns>View do Perfil Utilzador</returns>
        public Task<Perfil_Utilizador> GetByIdAsync(int id, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Serviço para a atualizaçao dos dados de um perfil utilizador
        /// </summary>
        /// <param name="id">Identificador do perfil utilizador</param>
        /// <param name="perfil_utilizador">Dados do perfil utilizador para gravar</param>
        /// <param name="ct">Cancellation Token - chamada asincrona</param>
        /// <returns>View do perfil utilizador</returns>
        public Task<Perfil_Utilizador> UpdateAsync(int id, Perfil_Utilizador perfil_utilizador, CancellationToken ct)
        {
            throw new NotImplementedException();
        }
    }
}
