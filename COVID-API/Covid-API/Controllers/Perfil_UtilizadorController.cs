using System;
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
    [Route("api/[perfil_utilizador]")]
    [ApiController]
    public class Perfil_UtilizadorController : ControllerBase, IPerfil_Utilizador
    {
        private IPerfil_UtilizadoresServices _perfil_utilizadorServices;

        /// <summary>
        /// Endpoint para a obtenção de um perfil utilizador por Id
        /// </summary>
        /// <param name="perfil_utilizadorServices"></param>
        public Perfil_UtilizadorController(IPerfil_UtilizadoresServices perfil_utilizadorServices)
        {
            _perfil_utilizadorServices = perfil_utilizadorServices;
        }

        /// <summary>
        /// Endpoint para a criação de um perfil utilizador 
        /// </summary>
        /// <param name="perfil_utilizador">Identificador do perfil utilizador</param>
        /// <param name="ct"></param>
        /// <returns>View do perfil utilizador</returns>
        [HttpPost]
        [Route("")]
        public async Task<DataBase.ViewModels.Perfil_Utilizador> CreateAsync(
            [FromBody] DataBase.Models.Perfil_Utilizador perfil_utilizador,
            CancellationToken ct
        )
        {
            var result = await _perfil_utilizadorServices.CreateAsync(perfil_utilizador, ct);
            return result.ToViewModel();
        }

        /// <summary>
        /// Endpoint para a eliminação de um perfil utilizador
        /// </summary>
        /// <param name="id">Identificador do perfil utilizador a eliminar</param>
        /// <param name="ct"></param>
        [HttpDelete]
        [Route("{id}")]
        public async Task DeleteAsync(
            [FromRoute] int id,
            CancellationToken ct
        )
        {
            await _perfil_utilizadorServices.DeleteAsync(id, ct);
        }

        /// <summary>
        /// Endpoint para a obtenção da lista de perfil utilizador
        /// </summary>
        /// <param name="ct"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        public async Task<ICollection<DataBase.ViewModels.Perfil_Utilizador>> GetAllAsync(CancellationToken ct)
        {
            var result = await _perfil_utilizadorServices.GetAllAsync(ct);
            return result.ToViewModel();
        }

        /// <summary>
        /// Endpoint para a obtenção de um perfil utilizador por Id
        /// </summary>
        /// <param name="id">Identificador do perfil utilizador</param>
        /// <param name="ct"></param>
        /// <returns>View do perfil utilizador</returns>
        [HttpGet]
        [Route("{id}")]
        public async Task<DataBase.ViewModels.Perfil_Utilizador> GetByIdAsync(
            [FromRoute] int id,
            CancellationToken ct
        )
        {
            var result = await _perfil_utilizadorServices.GetByIdAsync(id, ct);
            return result.ToViewModel();
        }

        /// <summary>
        /// Endpoint para a atualização de um perfil utilizador
        /// </summary>
        /// <param name="id">Identificador de um perfil utilizador</param>
        /// <param name="doente">Dados do perfil utilizador para atualização</param>
        /// <param name="ct"></param>
        /// <returns>View do perfil utilizador actualizado</returns>
        [HttpPut]
        [Route("{id}")]
        public async Task<DataBase.ViewModels.Perfil_Utilizador> UpdateAsync(
            [FromRoute] int id,
            [FromBody] DataBase.Models.Perfil_Utilizador perfil_utilizador,
            CancellationToken ct
        )
        {
            var result = await _perfil_utilizadorServices.UpdateAsync(id, perfil_utilizador, ct);
            return result.ToViewModel();
        }
    }
}