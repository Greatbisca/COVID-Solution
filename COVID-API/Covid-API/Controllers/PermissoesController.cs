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
        public async Task<DataBase.ViewModels.Permissoes> CreateAsync(
            [FromBody] DataBase.Models.Permissoes permissoes,
            CancellationToken ct
        )
        {
            return await _permissoesServices.CreateAsync(permissoes, ct);
        }

        /// <summary>
        /// Endpoint para a eliminação de uma permissao
        /// </summary>
        /// <param name="id">Identificador da permissao a eliminar</param>
        /// <param name="ct"></param>
        [HttpDelete]
        [Route("{id}")]
        public async Task DeleteAsync(
            [FromRoute] int id,
            CancellationToken ct
        )
        {
            await _permissoesServices.DeleteAsync(id, ct);
        }

        /// <summary>
        /// Endpoint para a obtenção da lista de permissoes
        /// </summary>
        /// <param name="ct"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        public async Task<ICollection<DataBase.ViewModels.Permissoes>> GetAllAsync(CancellationToken ct)
        {
            return await _permissoesServices.GetAllAsync(ct);
        }

        /// <summary>
        /// Endpoint para a obtenção de uma permissao por Id
        /// </summary>
        /// <param name="id">Identificador da permissao</param>
        /// <param name="ct"></param>
        /// <returns>View da permissao</returns>
        [HttpGet]
        [Route("{id}")]
        public async Task<DataBase.ViewModels.Permissoes> GetByIdAsync(
            [FromRoute] int id,
            CancellationToken ct
        )
        {
            return await _permissoesServices.GetByIdAsync(id, ct);
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
        public async Task<DataBase.ViewModels.Permissoes> UpdateAsync(
            [FromRoute] int id,
            [FromBody] DataBase.Models.Permissoes permissoes,
            CancellationToken ct
        )
        {
            return await _permissoesServices.UpdateAsync(id, permissoes, ct);
        }
    }
}