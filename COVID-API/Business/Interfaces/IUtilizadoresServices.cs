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
    }
}
