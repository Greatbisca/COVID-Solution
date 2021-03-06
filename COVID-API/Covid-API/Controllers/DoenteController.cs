﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Business.Interfaces;
using Covid_API.Interfaces;
using Covid_API.Mappings;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Covid_API.Controllers
{
    /// <summary>
    /// Gateway para a gestão de doentes
    /// </summary>
    [Route("api/doente")]
    [Produces("application/json")]
    [ApiController]
    public class DoenteController : ControllerBase, IDoente
    {
        private IDoenteServices _doenteServices;
        private IUtilizadoresServices _utilizadoresServices;

        /// <summary>
        /// Construtor com dependency injection
        /// </summary>
        /// <param name="doenteServices"></param>
        public DoenteController(IDoenteServices doenteServices, IUtilizadoresServices utilizadoresServices)
        {
            _doenteServices = doenteServices;
            _utilizadoresServices = utilizadoresServices;
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
            [FromBody] DataBase.RequestModel.DoenteRequest doente, 
            CancellationToken ct
        )
        {
            var result = await _doenteServices.CreateAsync(doente, ct);
            var utilizador = await _utilizadoresServices.GetByIdAsync(result.Id_Utilizador, ct);

            return result.ToViewModel(utilizador);
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
            var result = await _doenteServices.GetAllAsync(ct);
            var resultList = new List<DataBase.ViewModels.Doente>();

            foreach (var doente in result)
            {
                var utilizador = await _utilizadoresServices.GetByIdAsync(doente.Id_Utilizador, ct);
                resultList.Add(doente.ToViewModel(utilizador));
            }

            return resultList;
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
            var result = await _doenteServices.GetByIdAsync(id,ct);
            var utilizador = await _utilizadoresServices.GetByIdAsync(result.Id_Utilizador, ct);

            return result.ToViewModel(utilizador);
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
            [FromBody] DataBase.RequestModel.DoenteRequest doente, 
            CancellationToken ct
        )
        {
            var result = await _doenteServices.UpdateAsync(id, doente, ct);
            var utilizador = await _utilizadoresServices.GetByIdAsync(result.Id_Utilizador, ct);

            return result.ToViewModel(utilizador);
        }
    }
}