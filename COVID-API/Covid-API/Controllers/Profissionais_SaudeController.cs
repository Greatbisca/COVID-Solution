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
    [Route("api/[profissional_saude]")]
    [ApiController]
    public class Profissionais_SaudeController : ControllerBase, IProfissionais_Saude
    {
        private IProfissionais_SaudeServices _profissionais_saudeServices;

        /// <summary>
        /// Construtor com dependency injection
        /// </summary>
        /// <param name="profissionais_saudeServices"></param>
        public Profissionais_SaudeController(IProfissionais_SaudeServices profissionais_saudeServices)
        {
            _profissionais_saudeServices = profissionais_saudeServices;
        }

        /// <summary>
        /// Endpoint para a criação de um profissional saude
        /// </summary>
        /// <param name="profissionais_saude">Objeto para gravar na base de dados</param>
        /// <param name="ct"></param>
        /// <returns>View do profissional saude criado</returns>
        [HttpPost]
        [Route("")]
        public async Task<DataBase.ViewModels.Profissionais_Saude> CreateAsync(
            [FromBody] DataBase.Models.Profissionais_Saude profissionais_saude,
            CancellationToken ct
        )
        {
            return await _profissionais_saudeServices.CreateAsync(profissionais_saude, ct);
        }

        /// <summary>
        /// Endpoint para a eliminação de um profissional saude
        /// </summary>
        /// <param name="id">Identificador do profissional de saude a eliminar</param>
        /// <param name="ct"></param>
        [HttpDelete]
        [Route("{id}")]
        public async Task DeleteAsync(
            [FromRoute] int id,
            CancellationToken ct
        )
        {
            await _profissionais_saudeServices.DeleteAsync(id, ct);
        }

        /// <summary>
        /// Endpoint para a obtenção da lista de profissionais de saude
        /// </summary>
        /// <param name="ct"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        public async Task<ICollection<DataBase.ViewModels.Profissionais_Saude>> GetAllAsync(CancellationToken ct)
        {
            return await _profissionais_saudeServices.GetAllAsync(ct);
        }

        /// <summary>
        /// Endpoint para a obtenção de um profissional de saude por Id
        /// </summary>
        /// <param name="id">Identificador do profissional de saude</param>
        /// <param name="ct"></param>
        /// <returns>View do profissional de saude</returns>
        [HttpGet]
        [Route("{id}")]
        public async Task<DataBase.ViewModels.Profissionais_Saude> GetByIdAsync(
            [FromRoute] int id,
            CancellationToken ct
        )
        {
            return await _profissionais_saudeServices.GetByIdAsync(id, ct);
        }

        /// <summary>
        /// Endpoint para a atualização de um profissional de saude
        /// </summary>
        /// <param name="id">Identificador de um profssional de saude</param>
        /// <param name="profissionais_saude">Dados do profissional de saude para atualização</param>
        /// <param name="ct"></param>
        /// <returns>View do profissional de saude atualizado</returns>
        [HttpPut]
        [Route("{id}")]
        public async Task<DataBase.ViewModels.Profissionais_Saude> UpdateAsync(
            [FromRoute] int id,
            [FromBody] DataBase.Models.Profissionais_Saude profissionais_saude,
            CancellationToken ct
        )
        {
            return await _profissionais_saudeServices.UpdateAsync(id, profissionais_saude, ct);
        }
    }
}