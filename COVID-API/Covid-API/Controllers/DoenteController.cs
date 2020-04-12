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
        public Task<DataBase.ViewModels.Doente> Create(
            [FromBody] DataBase.Models.Doente doente, 
            CancellationToken ct
        )
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Endpoint para a eliminação de um doente
        /// </summary>
        /// <param name="id">Identificador do doente a eliminar</param>
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
        /// Endpoint para a obtenção da lista de doentes
        /// </summary>
        /// <param name="ct"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        public Task<ICollection<DataBase.ViewModels.Doente>> GetAll(CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Endpoint para a obtenção de um doente por Id
        /// </summary>
        /// <param name="id">Identificador do doente</param>
        /// <param name="ct"></param>
        /// <returns>View do doente</returns>
        [HttpGet]
        [Route("{id}")]
        public Task<DataBase.ViewModels.Doente> GetById(
            [FromRoute] int id, 
            CancellationToken ct
        )
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Endpoint para a actualização de um doente
        /// </summary>
        /// <param name="id">Identificador de um doente</param>
        /// <param name="doente">Dados do doente para actualização</param>
        /// <param name="ct"></param>
        /// <returns>View do doente actualizado</returns>
        [HttpPut]
        [Route("{id}")]
        public Task<DataBase.ViewModels.Doente> Update(
            [FromRoute] int id, 
            [FromBody] DataBase.Models.Doente doente, 
            CancellationToken ct
        )
        {
            throw new NotImplementedException();
        }
    }
}