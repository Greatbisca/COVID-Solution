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
    /// <summary>
    /// Gateway para a gestão de doentes
    /// </summary>
    [Route("api/doente")]
    [ApiController]
    public class DoenteController : ControllerBase, IDoente
    {
        private IDoenteServices _doenteServices;

        /// <summary>
        /// Construtor com dependency injection
        /// </summary>
        /// <param name="doenteServices"></param>
        public DoenteController(IDoenteServices doenteServices)
        {
            _doenteServices = doenteServices;
        }

        /// <summary>
        /// Endpoint para a criação de um doente
        /// </summary>
        /// <param name="doente">Objecto para gravar na base de dados</param>
        /// <param name="ct"></param>
        /// <returns>View do doente criado</returns>
        [HttpPost]
        [Route("")]
        public async Task<DataBase.ViewModels.Doente> CreateAsync(
            [FromBody] DataBase.Models.Doente doente, 
            CancellationToken ct
        )
        {
            return await _doenteServices.CreateAsync(doente, ct);
        }

        /// <summary>
        /// Endpoint para a eliminação de um doente
        /// </summary>
        /// <param name="id">Identificador do doente a eliminar</param>
        /// <param name="ct"></param>
        [HttpDelete]
        [Route("{id}")]
        public async Task DeleteAsync(
            [FromRoute] int id, 
            CancellationToken ct
        )
        {
            await _doenteServices.DeleteAsync(id, ct);
        }

        /// <summary>
        /// Endpoint para a obtenção da lista de doentes
        /// </summary>
        /// <param name="ct"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        public async Task<ICollection<DataBase.ViewModels.Doente>> GetAllAsync(CancellationToken ct)
        {
            return await _doenteServices.GetAllAsync(ct);
        }

        /// <summary>
        /// Endpoint para a obtenção de um doente por Id
        /// </summary>
        /// <param name="id">Identificador do doente</param>
        /// <param name="ct"></param>
        /// <returns>View do doente</returns>
        [HttpGet]
        [Route("{id}")]
        public async Task<DataBase.ViewModels.Doente> GetByIdAsync(
            [FromRoute] int id, 
            CancellationToken ct
        )
        {
            return await _doenteServices.GetByIdAsync(id,ct);
        }

        /// <summary>
        /// Endpoint para a atualização de um doente
        /// </summary>
        /// <param name="id">Identificador de um doente</param>
        /// <param name="doente">Dados do doente para atualização</param>
        /// <param name="ct"></param>
        /// <returns>View do doente atualizado</returns>
        [HttpPut]
        [Route("{id}")]
        public async Task<DataBase.ViewModels.Doente> UpdateAsync(
            [FromRoute] int id, 
            [FromBody] DataBase.Models.Doente doente, 
            CancellationToken ct
        )
        {
            return await _doenteServices.UpdateAsync(id, doente, ct);
        }
    }
}