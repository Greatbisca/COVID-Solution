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
    [Route("api/[teste]")]
    [ApiController]
    public class TesteController : ControllerBase, ITestes
    {
        private ITestes _testeServices;

       /// <summary>
       /// Contrutor com dependency injection
       /// </summary>
       /// <param name="testeServices"></param>
        public TesteController(ITesteServices testeServices)
        {
            _testeServices = testeServices;
        }

        /// <summary>
        ///  Endpoint para a criação de um teste
        /// </summary>
        /// <param name="teste"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("")]
        public Task<DataBase.ViewModels.Teste> Create(
            [FromBody] DataBase.Models.Teste teste,
            CancellationToken ct
        )
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Endpoint para a eliminação de um teste
        /// </summary>
        /// <param name="id">Identificador do teste a eliminar</param>
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
        /// Endpoint para a obtenção da lista de testes
        /// </summary>
        /// <param name="ct"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        public Task<ICollection<DataBase.ViewModels.Teste>> GetAll(CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Endpoint para a obtenção de um teste por Id
        /// </summary>
        /// <param name="id">Identificador do teste</param>
        /// <param name="ct"></param>
        /// <returns>View do doente</returns>
        [HttpGet]
        [Route("{id}")]
        public Task<DataBase.ViewModels.Teste> GetById(
            [FromRoute] int id,
            CancellationToken ct
        )
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Endpoint para a atualização de um doente
        /// </summary>
        /// <param name="id">Identificador de um teste</param>
        /// <param name="teste">Dados do teste para atualização</param>
        /// <param name="ct"></param>
        /// <returns>View do teste atualizado</returns>
        [HttpPut]
        [Route("{id}")]
        public Task<DataBase.ViewModels.Teste> Update(
            [FromRoute] int id,
            [FromBody] DataBase.Models.Teste teste,
            CancellationToken ct
        )
        {
            throw new NotImplementedException();
        }

    }
}