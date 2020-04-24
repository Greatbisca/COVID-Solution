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
    [Route("api/[permissoes]")]
    [ApiController]
    public class PermissoesController : ControllerBase, IPermissoes
    {
        private IPermissoesServices _permissoesServices;

        /// <summary>
        /// Construtor com dependency injection
        /// </summary>
        /// <param name="permissoesServices"></param>
        public PermissoesController(IPermissoesServices permissoesServices)
        {
            _permissoesServices = permissoesServices;
        }

        /// <summary>
        /// Endpoint para a criação de uma permissao
        /// </summary>
        /// <param name="permissoes">Objecto para gravar na base de dados</param>
        /// <param name="ct"></param>
        /// <returns>View da permissao criada</returns>
        [HttpPost]
        [Route("")]
        public Task<DataBase.ViewModels.Permissoes> Create(
            [FromBody] DataBase.Models.Permissoes permissoes,
            CancellationToken ct
        )
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Endpoint para a eliminação de uma permissao
        /// </summary>
        /// <param name="id">Identificador da permissao a eliminar</param>
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
        /// Endpoint para a obtenção da lista de permissoes
        /// </summary>
        /// <param name="ct"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        public Task<ICollection<DataBase.ViewModels.Permissoes>> GetAll(CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Endpoint para a obtenção de uma permissao por Id
        /// </summary>
        /// <param name="id">Identificador da permissao</param>
        /// <param name="ct"></param>
        /// <returns>View da permissao</returns>
        [HttpGet]
        [Route("{id}")]
        public Task<DataBase.ViewModels.Permissoes> GetById(
            [FromRoute] int id,
            CancellationToken ct
        )
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Endpoint para a atualização de uma permissao 
        /// </summary>
        /// <param name="id">Indentificador de uma permissao</param>
        /// <param name="permissoes">Dados da permissao para atualização</param>
        /// <param name="ct"></param>
        /// <returns>View da permissao atualizada</returns>
        [HttpPut]
        [Route("{id}")]
        public Task<DataBase.ViewModels.Permissoes> Update(
            [FromRoute] int id,
            [FromBody] DataBase.Models.Permissoes permissoes,
            CancellationToken ct
        )
        {
            throw new NotImplementedException();
        }
    }
}