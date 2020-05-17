using DataBase.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    /// <summary>
    /// Lógica de negócio - Serviço para os Utilizadores 
    /// </summary>
    public interface IUtilizadoresServices
    {
        /// <summary>
        /// Serviço para a validação de um utilizador por username e password
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="ct"></param>
        /// <returns>Token de autenticação</returns>
        Task<string> ValidateLoginAsync(string username, string password, CancellationToken ct);

        /// <summary>
        /// Serviço para a criação de um utilizador
        /// </summary>
        /// <param name="utilizador"></param>
        /// <param name="ct"></param>
        /// <returns>Objecto Criado</returns>
        Task<Utilizadores> CreateAsync(Utilizadores utilizador, CancellationToken ct);

        /// <summary>
        /// Serviço para a actualização de um utilizador
        /// </summary>
        /// <param name="id"></param>
        /// <param name="utilizador"></param>
        /// <param name="ct"></param>
        /// <returns>Objecto actualizado</returns>
        Task<Utilizadores> UpdateAsync(int id, Utilizadores utilizador, CancellationToken ct);

        /// <summary>
        /// Serviço para a obtenção de um utilizador por Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ct"></param>
        /// <returns>Objecto pesquisado</returns>
        Task<Utilizadores> GetByIdAsync(int id, CancellationToken ct);

        /// <summary>
        /// Serviço para a remoção de um utilizador
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ct"></param>
        Task DeleteAsync(int id, CancellationToken ct);
    }
}
