using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Business.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Covid_API.Controllers
{
    [Route("api/[utilizadores]")]
    [ApiController]
    public class UtilizadoresController : ControllerBase
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
        /// Endpoint para a criação de um utilizador
        /// </summary>
        /// <param name="utilizadores">Objeto oara gravar na base de dados</param>
        /// <param name="ct"></param>
        /// <returns>View do utilizador criado</returns>
        [HttpPost]
        [Route("")]
        public Task<DataBase.ViewModels.Utilizadores> Create(
            [FromBody] DataBase.Models.Utilizadores utilizadores,
            CancellationToken ct
        )
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Endpoint para a eliminação de um utilizador
        /// </summary>
        /// <param name="id">Identificador do utilizador a eliminar</param>
        /// <param name="ct"></param>
        [HttpDelete]
        [Route("{id}")]
        public Task Delete(
            [FromRoute] int id,
            CancellationToken ct
        )
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Endpoint para a obtenção da lista de utilizadores
        /// </summary>
        /// <param name="ct"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        public Task<ICollection<DataBase.ViewModels.Utilizadores>> GetAll(CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Endpoint para a obtenção de um utilizador por Id
        /// </summary>
        /// <param name="id">Identificador do utilizador</param>
        /// <param name="ct"></param>
        /// <returns>View do doente</returns>
        [HttpGet]
        [Route("{id}")]
        public Task<DataBase.ViewModels.Utilizadores> GetById(
            [FromRoute] int id,
            CancellationToken ct
        )
        {
            throw new NotImplementedException();
        }


        /// <summary>
        ///  Endpoint para a atualização de um utilizador
        /// </summary>
        /// <param name="id">Identificador de um utilizador</param>
        /// <param name="utilizadores">Dados do utilizador para atualização</param>
        /// <param name="ct"></param>
        /// <returns>View do utillizador atualizado</returns>
        [HttpPut]
        [Route("{id}")]
        public Task<DataBase.ViewModels.Utilizadores> Update(
            [FromRoute] int id,
            [FromBody] DataBase.Models.Utilizadores utilizadores,
            CancellationToken ct
        )
        {
            throw new NotImplementedException();
        }

    }
}