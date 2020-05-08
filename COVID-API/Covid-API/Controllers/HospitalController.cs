using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Business.Interfaces;
using Covid_API.Interfaces;
using DataBase.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Covid_API.Controllers
{
    /// <summary>
    /// Gateway para a gestão de hospitais
    /// </summary>
    [Route("api/hospital")]
    [ApiController]
    public class HospitalController : ControllerBase, IHospital
    {
        private IHospitalServices _hospitalServices;

        /// <summary>
        /// Contrutor com dependency injection
        /// </summary>
        /// <param name="hospitalServices"></param>
        public HospitalController(IHospitalServices hospitalServices)
        {
            _hospitalServices = hospitalServices;
        }

        /// <summary>
        /// Endpoint para a criação de um hospital
        /// </summary>
        /// <param name="hospital">Objeto para gravar na base de dados</param>
        /// <param name="ct"></param>
        /// <returns>View do hospital criado</returns>
        [HttpPost]
        [Route("")]
        public async Task<DataBase.ViewModels.Hospital> CreateAsync(
            [FromBody] DataBase.Models.Hospital hospital,
            CancellationToken ct
        )
        {
            return await _hospitalServices.CreateAsync(hospital, ct);
        }

        /// <summary>
        /// Endpoint para a eliminação de um hospital
        /// </summary>
        /// <param name="id">Identificador do hosppital a eliminar</param>
        /// <param name="ct"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}")]
        public async Task DeleteAsync(
            [FromRoute] int id,
            CancellationToken ct
        )
        {
            await _hospitalServices.DeleteAsync(id,ct);
        }

        /// <summary>
        /// Endpoint para a obtenção de uma lista de hospitais
        /// </summary>
        /// <param name="ct"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        public async Task<ICollection<DataBase.ViewModels.Hospital>> GetAllAsync(CancellationToken ct)
        {
            return await _hospitalServices.GetAllAsync(ct);
        }

        /// <summary>
        /// Endpoint para a obtenção de um hospital por Id
        /// </summary>
        /// <param name="id">Identificador do hospital</param>
        /// <param name="ct"></param>
        /// <returns>View do hospital</returns>
        [HttpGet]
        [Route("{id}")]
        public async Task<DataBase.ViewModels.Hospital> GetByIdAsync(
            [FromRoute] int id,
            CancellationToken ct
        )
        {
            return await _hospitalServices.GetByIdAsync(id, ct);
        }

        /// <summary>
        /// Endpoint para a atualização de um hospital
        /// </summary>
        /// <param name="id">Identificador do hospital</param>
        /// <param name="hospital">Dados do hospital para atualizacao</param>
        /// <param name="ct"></param>
        /// <returns>View do hospital atualizado</returns>
        [HttpPut]
        [Route("{id}")]
        public async Task<DataBase.ViewModels.Hospital> UpdateAsync(
            [FromRoute] int id,
            [FromBody] DataBase.Models.Hospital hospital,
            CancellationToken ct
        )
        {
            return await _hospitalServices.UpdateAsync(id, hospital, ct);
        }
    }
}