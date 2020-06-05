using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Business.Interfaces;
using Covid_API.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Covid_API.Controllers
{
    [Route("api/utilizadores")]
    [ApiController]
    public class UtilizadoresController : ControllerBase, IUtilizadores
    {
        private IUtilizadoresServices _utilizadoresServices;

        /// <summary>
        /// Construtor com dependency injection
        /// </summary>
        /// <param name="utilizadoresServices"></param>
        public UtilizadoresController(IUtilizadoresServices utilizadoresServices)
        {
            _utilizadoresServices = utilizadoresServices;
        }

        /// <summary>
        /// Endpoint para o login de um utilizador
        /// </summary>
        /// <param name="login">Request com o username e password</param>
        /// <param name="ct"></param>
        /// <returns>Token de autenticação</returns>
        [HttpPost]
        [Route("")]
        public async Task<string> LoginAsync(
            [FromBody] DataBase.Models.LoginRequestModel login,
            CancellationToken ct
        )
        {
            return await _utilizadoresServices.ValidateLoginAsync(login.Username, login.Password, ct);
        }
    }
}