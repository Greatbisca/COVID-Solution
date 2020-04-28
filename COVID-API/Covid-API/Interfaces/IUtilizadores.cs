using DataBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Covid_API.Interfaces
{
    //Interface do Gateway dos Utilizadores
    public interface IUtilizadores
    {
        /// <summary>
        /// Endpoint para o login de um utilizador
        /// </summary>
        /// <param name="login">Request com o username e password</param>
        /// <param name="ct"></param>
        /// <returns>Token de autenticação</returns>
        Task<string> LoginAsync(LoginRequestModel login, CancellationToken ct);

    }
}
