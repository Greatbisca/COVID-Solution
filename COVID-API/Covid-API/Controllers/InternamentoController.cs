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
    /// Gateway para a gestao de hospitais
    /// </summary>
    [Route("api/internamento")]
    [ApiController]
    public class InternamentoController : ControllerBase, IInternamento
    {
        private IInternamentoServices _internamentoServices;

        /// <summary>
        /// Construtor com dependency injection
        /// </summary>
        /// <param name="internamentoServices"></param>
        public InternamentoController(IInternamentoServices internamentoServices)
        {
            _internamentoServices = internamentoServices;
        }

        /// <summary>
        /// Endpoint para a criação de um internamento
        /// </summary>
        /// <param name="internamento">Objecto para gravar na base de dados</param>
        /// <param name="ct"></param>
        /// <returns>View do internamento criado</returns>
        [HttpPost]
        [Route("")]
        public async Task<DataBase.ViewModels.Internamento> CreateAsync(
            [FromBody] DataBase.Models.Internamento internamento,
            CancellationToken ct
        )
        {
            return await _internamentoServices.CreateAsync(internamento, ct);
        }

        /// <summary>
        /// Endpoint para a eliminação de um internamento
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
            await _internamentoServices.DeleteAsync(id, ct);
        }

        /// <summary>
        /// Endpoint para a obtenção da lista de internamentos
        /// </summary>
        /// <param name="ct"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        public async Task<ICollection<DataBase.ViewModels.Internamento>> GetAllAsync(CancellationToken ct)
        {
            return await _internamentoServices.GetAllAsync(ct);
        }

        /// <summary>
        /// Endpoint para a obtenção de um internamento por Id
        /// </summary>
        /// <param name="id">Identificador do internamento</param>
        /// <param name="ct"></param>
        /// <returns>View do internamento</returns>
        [HttpGet]
        [Route("{id}")]
        public async Task<DataBase.ViewModels.Internamento> GetByIdAsync(
            [FromRoute] int id,
            CancellationToken ct
        )
        {
            return await _internamentoServices.GetByIdAsync(id, ct);
        }

        /// <summary>
        /// Endpoint para a atualização de um internamento
        /// </summary>
        /// <param name="id">Identificador de um internamento</param>
        /// <param name="internamento">Dados do internamento para actualização</param>
        /// <param name="ct"></param>
        /// <returns>View do internamento actualizado</returns>
        [HttpPut]
        [Route("{id}")]
        public async Task<DataBase.ViewModels.Internamento> UpdateAsync(
            [FromRoute] int id,
            [FromBody] DataBase.Models.Internamento internamento,
            CancellationToken ct
        )
        {
            return await _internamentoServices.UpdateAsync(id, internamento, ct);
        }
    }
}