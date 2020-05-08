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
        private ITesteServices _testeServices;

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
        public async Task<DataBase.ViewModels.Teste> CreateAsync(
            [FromBody] DataBase.Models.Teste teste,
            CancellationToken ct
        )
        {
            return await _testeServices.CreateAsync(teste, ct);
        }

        /// <summary>
        /// Endpoint para a eliminação de um teste
        /// </summary>
        /// <param name="id">Identificador do teste a eliminar</param>
        /// <param name="ct"></param>
        [HttpDelete]
        [Route("{id}")]
        public async Task DeleteAsync(
            [FromRoute] int id,
            CancellationToken ct
        )
        {
            await _testeServices.DeleteAsync(id, ct);
        }

        /// <summary>
        /// Endpoint para a obtenção da lista de testes
        /// </summary>
        /// <param name="ct"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        public async Task<ICollection<DataBase.ViewModels.Teste>> GetAllAsync(CancellationToken ct)
        {
            return await _testeServices.GetAllAsync(ct);
        }

        /// <summary>
        /// Endpoint para a obtenção de um teste por Id
        /// </summary>
        /// <param name="id">Identificador do teste</param>
        /// <param name="ct"></param>
        /// <returns>View do doente</returns>
        [HttpGet]
        [Route("{id}")]
        public async Task<DataBase.ViewModels.Teste> GetByIdAsync(
            [FromRoute] int id,
            CancellationToken ct
        )
        {
            return await _testeServices.GetByIdAsync(id, ct);
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
        public async Task<DataBase.ViewModels.Teste> UpdateAsync(
            [FromRoute] int id,
            [FromBody] DataBase.Models.Teste teste,
            CancellationToken ct
        )
        {
            return await _testeServices.UpdateAsync(id, teste, ct);
        }

    }
}