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
    [Route("api/[modulos]")]
    [ApiController]
    public class ModulosController : ControllerBase, IModulos
    {
        private IModulosServices _modulosServices;

        /// <summary>
        ///  Construtor com dependency injection
        /// </summary>
        /// <param name="modulosServices"></param>
        public ModulosController(IModulosServices modulosServices)
        {
            _modulosServices = modulosServices;
        }

        /// <summary>
        /// Endpoint para a criação de um modulos
        /// </summary>
        /// <param name="modulos">Objecto para gravar na base de dados</param>
        /// <param name="ct"></param>
        /// <returns>View do modulo criado</returns>
        [HttpPost]
        [Route("")]
        public Task<DataBase.ViewModels.Modulos> Create(
            [FromBody] DataBase.Models.Modulos modulos,
            CancellationToken ct
        )
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Endpoint para a eliminação de um modulo
        /// </summary>
        /// <param name="id">Objeto para gravar na base de dados</param>
        /// <param name="ct"></param>
        /// <returns>View do modulo criado</returns>
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
        /// Endpoint para a obtenção da lista de modulos
        /// </summary>
        /// <param name="ct"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        public Task<ICollection<DataBase.ViewModels.Modulos>> GetAll(CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Endpoint para a obtenção de um modulo por Id
        /// </summary>
        /// <param name="id">Identificador do modulo</param>
        /// <param name="ct"></param>
        /// <returns>View do doente</returns>
        [HttpGet]
        [Route("{id}")]
        public Task<DataBase.ViewModels.Modulos> GetById(
            [FromRoute] int id,
            CancellationToken ct
        )
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Endpoint para a atualização de um modulo
        /// </summary>
        /// <param name="id">Identificador de um modulo</param>
        /// <param name="doente">Dados do modulo para atualização</param>
        /// <param name="ct"></param>
        /// <returns>View do modulo actualizado</returns>
        [HttpPut]
        [Route("{id}")]
        public Task<DataBase.ViewModels.Modulos> Update(
            [FromRoute] int id,
            [FromBody] DataBase.Models.Modulos modulos,
            CancellationToken ct
        )
        {
            throw new NotImplementedException();
        }
    }
}